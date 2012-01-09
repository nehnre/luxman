using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nehnre.DataAccess.Po
{
    public class BrandIdea
    {
        private string _biId = string.Empty;

        private string _biType = string.Empty;

        private string _biContent = string.Empty;

        public string biId
        {
            get { return _biId; }
            set { _biId = value; }
        }

        public string biType
        {
            get { return _biType; }
            set { _biType = value; }
        }

        public string biContent
        {
            get { return _biContent; }
            set { _biContent = value; }
        }


    }
}
