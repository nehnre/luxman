using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;

using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
//using Bll.Common;
using System.Web.Caching;
using Nehnre.Web.Common;

//using System.Web.Script.Serialization;
namespace Nehnre.Web.Common
{
	/// <summary>
	/// Summary description for AjaxHandler
	/// </summary>
	public class AjaxHandler : IHttpHandler
	{
		
		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			context.Response.Charset = "utf-8";
			context.Response.Clear();
			try
			{
                string action = "uploadf";
				if (!string.IsNullOrEmpty(action))
				{
                    
					switch (action)
					{
						case "uploadf":// upload file to temp folder
							//检查临时文件过期处理
							TempUploadFileManage.CheckRunning();


							HttpFileCollection files = context.Request.Files;
							if (files != null && files.Count > 0)
							{
								string fileName = null;
								HttpPostedFile file = files[0];

                                string tmpVirtualPath = string.Format(@"{0}{1}/", FileHelper.Default_Upload_Folder_Temp, DateTime.Now.ToString("yyyy-MM-dd"));
                                //string tmpVirtualPath = FileHelper.Default_Upload_Folder_Temp;

								string tmpPath = context.Server.MapPath(tmpVirtualPath);


								//判断路径是否存在
								if (!Directory.Exists(tmpPath))
								{
									Directory.CreateDirectory(tmpPath);
								}


								fileName = FileHelper.GetServerFileName(Path.Combine(tmpPath, Path.GetFileName(file.FileName)), FileNamingType.Guid);

								file.SaveAs(fileName);
                                string fn = file.FileName.Substring(file.FileName.LastIndexOf("\\") + 1);
								string resultStr = string.Format("{0}{1};{2}", tmpVirtualPath, Path.GetFileName(fileName),fn);
								context.Response.Write(string.Format(@"{{ status : 'success', msg: '{0}'}}", resultStr));

							}

							break;

						case "delf":	//删除文件
							context.Response.ContentType = "application/json";
							context.Response.ContentEncoding = System.Text.Encoding.UTF8;
						
							//删除该文件
							if (!string.IsNullOrEmpty(context.Request.Params["path"]))
							{
								string oldpath = context.Server.MapPath(context.Request.Params["path"]);
								if (File.Exists(oldpath))
									File.Delete(oldpath);
							}
							context.Response.Write("{\"status\":\"success\",\"msg\":\"1\"}");
							break;
						default:
							break;
					}
				}



			}
			catch (Exception ex)
			{
				string s = @"{status : 'error', msg : '" + ex.Message.Replace("'", "\'").Replace("\r\n", " ") + @"'}";
				context.Response.Write(s);
			}
			finally
			{
				//if (File.Exists(fileName))
				//    File.Delete(fileName);
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

	/// <summary>
	/// 临时文件管理类 主要处理对过期的临时文件进行删除工作
	/// </summary>
	public static class TempUploadFileManage
	{

		private const int Default_KeepMinutes = 20;	//临时文件保存的时间
		private const string Default_ManageKey = "TempUploadFile_Manager"; //处理缓存对象的Key

		private static Cache _cache;
		private static string _tempfolderPath;
		static TempUploadFileManage()
		{
			if (_cache == null)
			{
				_cache = HttpContext.Current.Cache;
				_tempfolderPath = HttpContext.Current.Server.MapPath(FileHelper.Default_Upload_Folder_Temp);

			}
		}

		//检查临时文件删除工作是否进行，若否则开始该工作
		public static void CheckRunning()
		{
			if (_cache[Default_ManageKey] == null)
			{
				DeleteOldTempFile(DateTime.Now.AddMinutes(-1 * Default_KeepMinutes));
				_cache.Insert(Default_ManageKey, Default_ManageKey, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, Default_KeepMinutes, 0), CacheItemPriority.NotRemovable, new CacheItemRemovedCallback(DeleteTempUploadCallback));
			}
		}

		//删除临时文件
		public static void DeleteOldTempFile(DateTime beforeT)
		{
			try
			{
				DirectoryInfo pdir = new DirectoryInfo(_tempfolderPath);
				foreach (DirectoryInfo d in pdir.GetDirectories())
				{
					if (d.LastWriteTime < beforeT)
					{
						d.Delete(true);
					}
					else
					{
						foreach (FileInfo f in d.GetFiles())
						{
							if (f.CreationTime < beforeT)
							{
								f.Delete();
							}
						}
					}
				}
			}
			catch
			{
				//不作处理
			}
		}

		//缓存到期时删除临时文件
		private static void DeleteTempUploadCallback(string k, object v, CacheItemRemovedReason r)
		{
			//删除文件
			DeleteOldTempFile(DateTime.Now.AddMinutes(-1 * Default_KeepMinutes));

			//恢复该缓存开始新的循环
			_cache.Insert(k, v, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, Default_KeepMinutes, 0), CacheItemPriority.NotRemovable, new CacheItemRemovedCallback(DeleteTempUploadCallback));


		}
	}
}