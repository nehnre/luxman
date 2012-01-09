using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using Nehnre.DataAccess.Po;
using Nehnre.DataAccess.Dao;
using System.Web.SessionState;

namespace Nehnre.Web.admin.ashx
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class login : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string method = context.Request.Params["method"];
            if ("login".Equals(method))
            {
                string usUserName = context.Request.Params["usUserName"];
                string usPassword = context.Request.Params["usPassword"];
                User user = new User();
                UserDAO dao = new UserDAO();
                user.usUserName = usUserName;
                user.usPassword = usPassword;
                DataSet ds = dao.select(user);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    context.Session["usUserName"] = usUserName;
                    string usId = (string)(ds.Tables[0].Rows[0][0]);
                    user.usId = usId;
                    dao.updateLastLogin(user);
                    context.Response.Write("{success:true}");
                }
                else
                {
                    context.Response.Write("{success:false,msg:'用户名密码错误！'}");
                }
            }
            else if ("check".Equals(method))
            {
                if (null == context.Session["usUserName"])
                {
                    context.Response.Write("parent.location.href='/admin/login.aspx';");
                }
            }
            else if ("logout".Equals(method))
            {
                context.Session["usUserName"] = null;
                context.Response.Redirect("/admin/login.aspx");
            }
            else if ("loadUser".Equals(method))
            {
                if (null == context.Session["usUserName"])
                {
                    context.Response.Write("location.href='/admin/login.aspx';");
                }
                else
                {
                    context.Response.Write(String.Format("$(function(){{$('#userName').html('{0}')}});", context.Session["usUserName"]));
                }
            }
            else if ("modPassword".Equals(method))
            {
                if (null == context.Session["usUserName"])
                {
                    context.Response.Write("{success:false,msg:'你还没有登录！'}");
                }
                else
                {
                    string oldPassword = context.Request.Params["oldPassword"];
                    string newPassowrd = context.Request.Params["newPassword"];
                    User user = new User();
                    UserDAO dao = new UserDAO();
                    user.usUserName = (string)context.Session["usUserName"];
                    user.usPassword = oldPassword;
                    DataSet ds = dao.select(user);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string usId = (string)(ds.Tables[0].Rows[0][0]);
                        user.usId = usId;
                        user.usPassword = newPassowrd;
                        dao.updatePassowrd(user);
                        context.Response.Write("{success:true,msg:'修改成功！'}");
                    }
                    else
                    {
                        context.Response.Write("{success:false,msg:'旧密码不正确！'}");
                    }

                }
                
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
