using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nehnre.DataAccess.Po;
using System.Data;
using Nehnre.DataAccess.Common;

namespace Nehnre.DataAccess.Dao
{
    public class BrandProjectDAO
    {
        public int insert(BrandProject po)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into BrandProject values( ");
            if (!String.IsNullOrEmpty(po.bpId))
            {
                sql.Append(String.Format("{0},", DbAccess.parse(po.bpId)));
            }
            else
            {
                sql.Append("newid(), ");
            }
            sql.Append(String.Format("{0},", DbAccess.parse(po.bpType)));
            sql.Append(String.Format("{0},", DbAccess.parse(po.bpContent)));
            sql.Append("getdate(), getdate())");

            return DbAccess.executeUpdate(sql.ToString());
        }

        public int update(BrandProject po)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update BrandProject set ");
            sql.Append(String.Format("bp_type={0},", DbAccess.parse(po.bpType))); 
            sql.Append(String.Format("bp_content={0},", DbAccess.parse(po.bpContent))); 
            sql.Append("bp_update_time=getdate()");
            sql.Append(String.Format(" where bp_id='{0}'", po.bpId));

            return DbAccess.executeUpdate(sql.ToString());
        }

        public DataSet select(BrandProject po)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from BrandProject where 1=1");
            if (!String.IsNullOrEmpty(po.bpType))
            {
                sql.Append(String.Format(" and bp_type={0}", DbAccess.parse(po.bpType)));
            }

            if (!String.IsNullOrEmpty(po.bpId))
            {
                sql.Append(String.Format(" and bp_id='{0}'", po.bpId));
            }

            sql.Append(" order by bp_update_time desc");

            return DbAccess.executeQuery(sql.ToString());

        }

        public int delete(BrandProject po)
        {
            string sql = String.Format("delete from BrandProject where bp_id='{0}'", po.bpId);

            return DbAccess.executeUpdate(sql);
        }

    }
}
