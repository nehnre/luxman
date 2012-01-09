using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nehnre.DataAccess.Po
{
    public class User
    {

        private string _usId = string.Empty;

        private string _usUserName = string.Empty;

        private string _usPassword = string.Empty;

        private string _usTrueName = string.Empty;

        public string usId
        {
            get { return _usId; }
            set { _usId = value; }
        }

        public string usUserName
        {
            get { return _usUserName; }
            set { _usUserName = value; }
        }

        public string usPassword
        {
            get { return _usPassword; }
            set { _usPassword = value; }
        }

        public string usTrueName
        {
            get { return _usTrueName; }
            set { _usTrueName = value; }
        }
    }
}
