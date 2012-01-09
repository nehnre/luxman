using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nehnre.DataAccess.Po;
using Nehnre.DataAccess.Common;
using System.Data;

namespace Nehnre.DataAccess.Dao
{
    public class BrandIdeaDAO
    {
        public int insert(BrandIdea po)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into BrandIdea values(newid(), ");
            sql.Append(String.Format("{0},", DbAccess.parse(po.biType)));
            sql.Append(String.Format("{0},", DbAccess.parse(po.biContent)));
            sql.Append("getdate(), getdate())");

            return DbAccess.executeUpdate(sql.ToString());
        }

        public int update(BrandIdea po)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update BrandIdea set ");
            sql.Append(String.Format("bi_type={0},", DbAccess.parse(po.biType)));
            sql.Append(String.Format("bi_content={0},", DbAccess.parse(po.biContent)));
            sql.Append("bi_update_time=getdate()");
            sql.Append(String.Format(" where bi_id='{0}'", po.biId));

            return DbAccess.executeUpdate(sql.ToString());
        }

        public DataSet select(BrandIdea po)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from BrandIdea where 1=1");
            if (!String.IsNullOrEmpty(po.biType))
            {
                sql.Append(String.Format(" and bi_type={0}", DbAccess.parse(po.biType)));
            }

            if (!String.IsNullOrEmpty(po.biContent))
            {
                sql.Append(String.Format(" and bi_content={0}", DbAccess.parse(po.biContent)));
            }

            if (!String.IsNullOrEmpty(po.biId))
            {
                sql.Append(String.Format(" and bi_id='{0}'", po.biId));
            }

            sql.Append(" order by bi_update_time desc");

            return DbAccess.executeQuery(sql.ToString());

        }

        public int delete(BrandIdea po)
        {
            string sql = String.Format("delete from BrandIdea where bi_id='{0}'", po.biId);

            return DbAccess.executeUpdate(sql);
        }

    }

}
