<%@ Page language="c#"%>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Configuration" %>
<%
	System.Web.HttpContext context = this.Context;
	context.Response.AddHeader("Prama","no-cache");
	context.Response.CacheControl="private";
	context.Response.Expires=0;

	context.Response.ContentType="text/html";

    string strsql = "select top 10 affairName from WS_AffairInstance ORDER BY applyDate DESC";
    //query方法
    string strCon = ConfigurationSettings.AppSettings["ConnectionString"];
    SqlConnection myConn = new SqlConnection(strCon);
    if (myConn.State.Equals(ConnectionState.Closed))
    {
        myConn.Open();
    }
    SqlDataAdapter da = new SqlDataAdapter(strsql, strCon);
    DataSet ds = new DataSet();
    da.Fill(ds);
    myConn.Close();
    
    //ds2json方法
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

                string str = Convert.ToString(dr[i]);
                //replaceSpicalCharacter
                if (!String.IsNullOrEmpty(str))
                {
                    str = str.Replace("\n", "\\n");
                    str = str.Replace("\r", "\\r");
                    str = str.Replace("\"", "\\\"");
                }
                
                
                json.Append("\"" + dt.Columns[i].ColumnName + "\":\"" + str + "\"");
            }
            json.Append("},");
        }
        tempString = regComma.Replace(json.ToString(), "");
        json.Length = 0;
        json.Append(tempString);
        json.Append("],");
    }
    tempString = regComma.Replace(json.ToString(), "");
    json.Length = 0;
    json.Append(tempString);
    json.Append("}");

    context.Response.Write(json);
%> 