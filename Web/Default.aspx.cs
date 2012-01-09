using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Nehnre.DataAccess.Common;
using Nehnre.DataAccess.Po;
using Nehnre.DataAccess.Dao;

namespace Nehnre.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BrandIdea po = new BrandIdea();
            po.biType = "type";
            po.biContent = "content";
            BrandIdeaDAO dao = new BrandIdeaDAO();
            dao.insert(po);
        }
    }
}
