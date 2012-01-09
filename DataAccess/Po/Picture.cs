using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nehnre.DataAccess.Po
{
    public class Picture
    {
        private string _picId = string.Empty;

        private string _picName = string.Empty;

        private string _picPath = string.Empty;

        private string _picExtension = string.Empty;

        private string _picDescrip = string.Empty;

        private string _picTableName = string.Empty;

        private string _picTableId = string.Empty;

        public string picId
        {
            get { return _picId; }
            set { _picId = value; }
        }


        public string picName
        {
            get { return _picName; }
            set { _picName = value; }
        }

        public string picPath
        {
            get { return _picPath; }
            set { _picPath = value; }
        }

        public string picExtension
        {
            get { return _picExtension; }
            set { _picExtension = value; }
        }

        public string picDescrip
        {
            get { return _picDescrip; }
            set { _picDescrip = value; }
        }

        public string picTableName
        {
            get { return _picTableName; }
            set { _picTableName = value; }
        }

        public string picTableId
        {
            get { return _picTableId; }
            set { _picTableId = value; }
        }
    }
}
