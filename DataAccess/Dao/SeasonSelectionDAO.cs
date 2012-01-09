using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nehnre.DataAccess.Po;
using System.Data;
using Nehnre.DataAccess.Common;

namespace Nehnre.DataAccess.Dao
{
    public class SeasonSelectionDAO
    {
        public int insert(SeasonSelection po)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into SeasonSelection values(");
            if (!String.IsNullOrEmpty(po.ssId))
            {
                sql.Append(String.Format("{0},", DbAccess.parse(po.ssId)));
            }
            else
            {
                sql.Append("newid(), ");
            }
            sql.Append(String.Format("{0},", DbAccess.parse(po.ssType1)));
            sql.Append(String.Format("{0},", DbAccess.parse(po.ssType2)));
            sql.Append(String.Format("{0},", DbAccess.parse(po.ssContent)));
            sql.Append("getdate(), getdate())");

            return DbAccess.executeUpdate(sql.ToString());
        }

        public int update(SeasonSelection po)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update SeasonSelection set ");
            sql.Append(String.Format("ss_type1={0},", DbAccess.parse(po.ssType1)));
            sql.Append(String.Format("ss_type2={0},", DbAccess.parse(po.ssType2)));
            sql.Append(String.Format("ss_content={0},", DbAccess.parse(po.ssContent)));
            sql.Append("ss_update_time=getdate()");
            sql.Append(String.Format(" where ss_id='{0}'", po.ssId));

            return DbAccess.executeUpdate(sql.ToString());
        }

        public DataSet select(SeasonSelection po)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from SeasonSelection where 1=1");
            if (!String.IsNullOrEmpty(po.ssType1))
            {
                sql.Append(String.Format(" and ss_type1={0}", DbAccess.parse(po.ssType1)));
            }

            if (!String.IsNullOrEmpty(po.ssType2))
            {
                sql.Append(String.Format(" and ss_type2={0}", DbAccess.parse(po.ssType2)));
            }

            if (!String.IsNullOrEmpty(po.ssContent))
            {
                sql.Append(String.Format(" and ss_content={0}", DbAccess.parse(po.ssContent)));
            }

            if (!String.IsNullOrEmpty(po.ssId))
            {
                sql.Append(String.Format(" and ss_id='{0}'", po.ssId));
            }

            sql.Append(" order by ss_update_time desc");

            return DbAccess.executeQuery(sql.ToString());

        }

        public int delete(SeasonSelection po)
        {
            string sql = String.Format("delete from SeasonSelection where ss_id='{0}'", po.ssId);

            return DbAccess.executeUpdate(sql);
        }
    }
}
