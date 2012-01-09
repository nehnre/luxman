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
    public class seasonselection : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string method = context.Request.Params["method"];
            if ("list".Equals(method))
            {
                string ajax = context.Request.Params["ajax"];

                SeasonSelectionDAO dao = new SeasonSelectionDAO();
                SeasonSelection ss = new SeasonSelection();
                ss.ssType1 = context.Request.Params["ssType1"];
                ss.ssType2 = context.Request.Params["ssType2"];
                DataSet ds = dao.select(ss);
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
                SeasonSelectionDAO dao = new SeasonSelectionDAO();
                SeasonSelection ss = new SeasonSelection();
                ss.ssId = context.Request.Params["ssId"];
                DataSet ds = dao.select(ss);
                string json = JsonCommon.ds2json(ds);


                PictureDAO picDao = new PictureDAO();
                Picture pic = new Picture();
                pic.picTableName = "SeasonSelection";
                pic.picTableId = ss.ssId;
                DataSet picDs = picDao.select(pic);
                string picJson = JsonCommon.ds2json(picDs);

                json = String.Format("[{0},{1}]", json, picJson);
                context.Response.Write(json);
            }
            else if ("save".Equals(method))
            {
                string ssContent = HttpUtility.UrlDecode((context.Request.Params["ssContent"]).Replace("@", "%"));
                string ssType1 = context.Request.Params["ssType1"];
                string ssType2 = context.Request.Params["ssType2"];
                string ssId = context.Request.Params["ssId"];
                SeasonSelectionDAO dao = new SeasonSelectionDAO();
                SeasonSelection ss = new SeasonSelection();
                ss.ssContent = ssContent;
                ss.ssType1 = ssType1;
                ss.ssType2 = ssType2;
                if (!String.IsNullOrEmpty(ssId))
                {
                    ss.ssId = ssId;
                    dao.update(ss);
                }
                else
                {
                    ss.ssId = Guid.NewGuid().ToString();
                    ssId = ss.ssId;
                    dao.insert(ss);
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
                        pic.picTableId = ssId;
                        pic.picTableName = "SeasonSelection";
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
                string ssId = context.Request.Params["ssId"];
                SeasonSelectionDAO dao = new SeasonSelectionDAO();
                SeasonSelection ss = new SeasonSelection();
                ss.ssId = ssId;
                dao.delete(ss);
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
