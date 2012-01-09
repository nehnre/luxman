using System.Data;
using System.Text;
using System;
using System.Text.RegularExpressions;
namespace Nehnre.DataAccess.Common
{

    public class JsonCommon
    {
        public string GetJson(DataSet ds)
        {
            StringBuilder json = new StringBuilder();
            json.Append("{");
            Regex regComma = new Regex(@"\,$");
            string tempString = "";
            foreach (DataTable dt in ds.Tables)
            {
                json.Append("\"" + dt.TableName + "\":[");
                foreach (DataRow dr in dt.Rows)
                {
                    json.Append("{");
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (i > 0)
                        {
                            json.Append(",");
                        }
                        json.Append("\"" + dt.Columns[i].ColumnName + "\":\"" + replaceSpicalCharacter(Convert.ToString(dr[i])) + "\"");
                    }
                    json.Append("},");
                }
                tempString = regComma.Replace(json.ToString(),"");
                json.Length = 0;
                json.Append(tempString);
                json.Append("],");
            }
            tempString = regComma.Replace(json.ToString(), "");
            json.Length = 0;
            json.Append(tempString);
            json.Append("}");
            return json.ToString();
        }

        private string replaceSpicalCharacter(string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                str = str.Replace("\n", "\\n");
                str = str.Replace("\r", "\\r");
                str = str.Replace("\"", "\\\"");
            }
            return str;
        }
        public static string ds2json(DataSet ds)
        {
            return new JsonCommon().GetJson(ds);
        }
    }
}
