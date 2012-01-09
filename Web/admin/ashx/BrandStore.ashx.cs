using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using Nehnre.DataAccess.Dao;
using Nehnre.DataAccess.Po;
using Nehnre.DataAccess.Common;
using Nehnre.Web.Common;

namespace Nehnre.Web.admin.ashx
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class brandstore : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string method = context.Request.Params["method"];
            if ("list".Equals(method))
            {
                string ajax = context.Request.Params["ajax"];

                BrandStoreDAO dao = new BrandStoreDAO();
                BrandStore bs = new BrandStore();
                bs.bsCountry = context.Request.Params["bsCountry"];
                bs.bsCity = context.Request.Params["bsCity"];
                DataSet ds = dao.select(bs);
                string result = "";
                if (String.IsNullOrEmpty(ajax))
                {
                    result = "_list = " + JsonCommon.ds2json(ds);
                }
                else
                {
                    result = JsonCommon.ds2json(ds);
                }
                context.Response.Write(result);
            }
            else if ("detail".Equals(method))
            {
                BrandStoreDAO dao = new BrandStoreDAO();
                BrandStore bs = new BrandStore();
                bs.bsId = context.Request.Params["bsId"];
                DataSet ds = dao.select(bs);
                string json = JsonCommon.ds2json(ds);


                PictureDAO picDao = new PictureDAO();
                Picture pic = new Picture();
                pic.picTableName = "BrandStore";
                pic.picTableId = bs.bsId;
                DataSet picDs = picDao.select(pic);
                string picJson = JsonCommon.ds2json(picDs);

                json = String.Format("[{0},{1}]", json, picJson);
                context.Response.Write(json);
            }
            else if ("save".Equals(method))
            {
                string bsContent = HttpUtility.UrlDecode((context.Request.Params["bsContent"]).Replace("@", "%"));
                string bsCountry = context.Request.Params["bsCountry"];
                string bsCity = context.Request.Params["bsCity"];
                string bsId = context.Request.Params["bsId"];
                BrandStoreDAO dao = new BrandStoreDAO();
                BrandStore bs = new BrandStore();
                bs.bsContent = bsContent;
                bs.bsCountry = bsCountry;
                bs.bsCity = bsCity;
                if (!String.IsNullOrEmpty(bsId))
                {
                    bs.bsId = bsId;
                    dao.update(bs);
                }
                else
                {
                    bs.bsId = Guid.NewGuid().ToString();
                    bsId = bs.bsId;
                    dao.insert(bs);
                }


                string pics = context.Request.Params["pics"];
                string disc = context.Request.Params["disc"];
                PictureDAO picDao = new PictureDAO();

                //删除要删除的图片
                string delPics = context.Request.Params["delPic"];
                if (!String.IsNullOrEmpty(delPics))
                {
                    string[] arrDelPics = delPics.Split(',');
                    for (int i = 0; i < arrDelPics.Length; i++)
                    {
                        Picture p = new Picture();
                        p.picId = arrDelPics[i];
                        picDao.delete(p);
                    }
                }
                if (!String.IsNullOrEmpty(pics))
                {
                    string[] arrPics = pics.Split(',');
                    string[] arrDisc = disc.Split(',');
                    for (int i = 0; i < arrPics.Length; i++)
                    {
                        string fileName = arrPics[i].Substring(arrPics[i].LastIndexOf("/") + 1);
                        string fromPath = context.Server.MapPath(arrPics[i]);
                        string toPath = context.Server.MapPath(FileHelper.Default_Pic_Forder + fileName);
                        FileHelper.MoveTo(fromPath, toPath);
                        Picture pic = new Picture();
                        pic.picTableId = bsId;
                        pic.picTableName = "BrandStore";
                        pic.picDescrip = arrDisc[i];
                        pic.picExtension = fileName.Substring(fileName.LastIndexOf(".") + 1);
                        pic.picName = fileName;
                        pic.picPath = FileHelper.Default_Pic_Forder + fileName;
                        picDao.insert(pic);
                    }
                }

            }
            else if ("delete".Equals(method))
            {
                string bsId = context.Request.Params["bsId"];
                BrandStoreDAO dao = new BrandStoreDAO();
                BrandStore bs = new BrandStore();
                bs.bsId = bsId;
                dao.delete(bs);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
