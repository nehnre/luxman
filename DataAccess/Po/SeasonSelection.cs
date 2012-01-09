using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nehnre.DataAccess.Po
{
    public class SeasonSelection
    {
        private string _ssId = string.Empty;

        private string _ssType1 = string.Empty;

        private string _ssType2 = string.Empty;

        private string _ssContent = string.Empty;

        public string ssId
        {
            get { return _ssId; }
            set { _ssId = value; }
        }

        public string ssType1
        {
            get { return _ssType1; }
            set { _ssType1 = value; }
        }

        public string ssType2
        {
            get { return _ssType2; }
            set { _ssType2 = value; }
        }

        public string ssContent
        {
            get { return _ssContent; }
            set { _ssContent = value; }
        }


    }
}
