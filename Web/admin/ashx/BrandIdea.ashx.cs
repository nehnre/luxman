using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using Nehnre.DataAccess.Common;
using Nehnre.DataAccess.Dao;
using Nehnre.DataAccess.Po;

namespace Nehnre.Web.admin.ashx
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class brandidea : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string method = context.Request.Params["method"];
            if ("list".Equals(method))
            {
                string ajax = context.Request.Params["ajax"];
                BrandIdeaDAO dao = new BrandIdeaDAO();
                BrandIdea bi = new BrandIdea();
                bi.biType = context.Request.Params["biType"];
                DataSet ds = dao.select(bi);
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
                BrandIdeaDAO dao = new BrandIdeaDAO();
                BrandIdea bi = new BrandIdea();
                bi.biId = context.Request.Params["biId"];
                DataSet ds = dao.select(bi);
                string json = JsonCommon.ds2json(ds);
                context.Response.Write(json);
            }
            else if ("save".Equals(method))
            {
                string biContent = HttpUtility.UrlDecode((context.Request.Params["biContent"]).Replace("@", "%"));
                string biType = context.Request.Params["biType"];
                string biId = context.Request.Params["biId"];
                BrandIdeaDAO dao = new BrandIdeaDAO();
                BrandIdea bi = new BrandIdea();
                bi.biId = biId;
                bi.biContent = biContent;
                bi.biType = biType;
                dao.update(bi);
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
