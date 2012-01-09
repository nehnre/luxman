using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nehnre.DataAccess.Po
{
    public class BrandStore
    {
        private string _bsId = string.Empty;

        private string _bsCountry = string.Empty;

        private string _bsCity = string.Empty;

        private string _bsContent = string.Empty;

        public string bsId
        {
            get { return _bsId; }
            set { _bsId = value; }
        }

        public string bsCountry
        {
            get { return _bsCountry; }
            set { _bsCountry = value; }
        }

        public string bsCity
        {
            get { return _bsCity; }
            set { _bsCity = value; }
        }

        public string bsContent
        {
            get { return _bsContent; }
            set { _bsContent = value; }
        }
    }
}
