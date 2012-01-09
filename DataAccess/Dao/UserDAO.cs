using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nehnre.DataAccess.Po;
using System.Data;
using Nehnre.DataAccess.Common;

namespace Nehnre.DataAccess.Dao
{
    public class UserDAO
    {


        public int update(User po)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update [User] set ");
            sql.Append(String.Format("us_password={0},", DbAccess.parse(po.usPassword)));
            sql.Append(String.Format("us_true_name={0},", DbAccess.parse(po.usTrueName)));
            sql.Append("us_update_time=getdate()");
            sql.Append(String.Format(" where us_id='{0}'", po.usId));

            return DbAccess.executeUpdate(sql.ToString());
        }

        public int updatePassowrd(User po)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update [User] set ");
            sql.Append(String.Format("us_password={0},", DbAccess.parse(po.usPassword)));
            sql.Append("us_update_time=getdate()");
            sql.Append(String.Format(" where us_id='{0}'", po.usId));

            return DbAccess.executeUpdate(sql.ToString());

        }

        public int updateLastLogin(User po)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update [User] set us_last_login=getdate(), ");
            sql.Append("us_update_time=getdate()");
            sql.Append(String.Format(" where us_id='{0}'", po.usId));

            return DbAccess.executeUpdate(sql.ToString());
        }

        public DataSet select(User po)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from [User] where 1=1");
            if (!String.IsNullOrEmpty(po.usUserName))
            {
                sql.Append(String.Format(" and us_user_name={0}", DbAccess.parse(po.usUserName)));
            }

            if (!String.IsNullOrEmpty(po.usPassword))
            {
                sql.Append(String.Format(" and us_password={0}", DbAccess.parse(po.usPassword)));
            }

            return DbAccess.executeQuery(sql.ToString());

        }
    }
}
