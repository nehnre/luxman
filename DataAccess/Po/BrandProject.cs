using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nehnre.DataAccess.Po
{
    public class BrandProject
    {
        private string _bpId = string.Empty;

        private string _bpType = string.Empty;

        private string _bpContent = string.Empty;

        public string bpId
        {
            get { return _bpId; }
            set { _bpId = value; }
        }

        public string bpType
        {
            get { return _bpType; }
            set { _bpType = value; }
        }

        public string bpContent
        {
            get { return _bpContent; }
            set { _bpContent = value; }
        }

    }
}
