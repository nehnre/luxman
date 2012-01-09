using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

using System.IO;

namespace Nehnre.Web.Common
{
	public class FileHelper
	{
		public const string Default_Upload_Folder_Temp = "/Upload/Temp/";
        public const string Default_Pic_Forder = "/Upload/Pics/";
		public static string GetServerFileName(string filename, FileNamingType nametype)
		{
			string fileName = null;	
			string extension = Path.GetExtension(filename);
			switch (nametype)
			{
				case FileNamingType.Distinct:
					fileName = Path.GetDirectoryName(filename) + Path.GetFileName(filename);
					int index = 1;
					while (File.Exists(fileName))
					{
						fileName = Path.Combine(Path.GetDirectoryName(filename), Path.GetFileNameWithoutExtension(filename) + "(" + index.ToString() + ")" + extension);
						index++;
					}
					break;
				case FileNamingType.Random:
					fileName = Path.Combine(Path.GetDirectoryName(filename), DateTime.Now.Ticks.ToString() + extension);
					break;
				case FileNamingType.Guid:
					fileName = Path.Combine(Path.GetDirectoryName(filename), Guid.NewGuid().ToString() + extension);
					break;
				case FileNamingType.None:
					fileName = Path.Combine(Path.GetDirectoryName(filename), Path.GetFileName(filename));
					break;
			}

			return fileName;
		}

		/// <summary>
		/// 获取文件的二进制流
		/// </summary>
		public static byte[] GetBinaryFile(string filename)
		{
			try
			{
				byte[] bs;
				using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
				{

					using (BinaryReader br = new BinaryReader(fs))
					{
						bs = br.ReadBytes((int)fs.Length);
					}

				}
				return bs;
			}
			catch
			{
				throw;
			}
		}


        public static void MoveTo(string fromPath, string toPath)
        {
            FileInfo fi = new FileInfo(fromPath);
            fi.MoveTo(toPath);
        }
	}


/// <summary>
/// 文件名保存类型
/// </summary>
public enum FileNamingType
{
	Distinct,
	Random,
	Guid,
	None
}
}
