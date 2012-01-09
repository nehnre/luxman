using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nehnre.DataAccess.Po;
using System.Data;
using Nehnre.DataAccess.Common;

namespace Nehnre.DataAccess.Dao
{
    public class BrandStoreDAO
    {
        public int insert(BrandStore po)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into BrandStore values( ");
            if (!String.IsNullOrEmpty(po.bsId))
            {
                sql.Append(String.Format("{0},", DbAccess.parse(po.bsId)));
            }
            else
            {
                sql.Append("newid(), ");
            }
            sql.Append(String.Format("{0},", DbAccess.parse(po.bsCountry)));
            sql.Append(String.Format("{0},", DbAccess.parse(po.bsCity)));
            sql.Append(String.Format("{0},", DbAccess.parse(po.bsContent)));
            sql.Append("getdate(), getdate())");

            return DbAccess.executeUpdate(sql.ToString());
        }

        public int update(BrandStore po)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update BrandStore set ");
            sql.Append(String.Format("bs_country={0},", DbAccess.parse(po.bsCountry)));
            sql.Append(String.Format("bs_city={0},", DbAccess.parse(po.bsCity)));
            sql.Append(String.Format("bs_content={0},", DbAccess.parse(po.bsContent)));
            sql.Append("bs_update_time=getdate()");
            sql.Append(String.Format(" where bs_id='{0}'", po.bsId));

            return DbAccess.executeUpdate(sql.ToString());
        }

        public DataSet select(BrandStore po)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from BrandStore where 1=1");
            if (!String.IsNullOrEmpty(po.bsCountry))
            {
                sql.Append(String.Format(" and bs_country={0}", DbAccess.parse(po.bsCountry)));
            }

            if (!String.IsNullOrEmpty(po.bsCity))
            {
                sql.Append(String.Format(" and bs_city={0}", DbAccess.parse(po.bsCity)));
            }

            if (!String.IsNullOrEmpty(po.bsContent))
            {
                sql.Append(String.Format(" and bs_content={0}", DbAccess.parse(po.bsContent)));
            }

            if (!String.IsNullOrEmpty(po.bsId))
            {
                sql.Append(String.Format(" and bs_id='{0}'", po.bsId));
            }

            sql.Append(" order by bs_update_time desc");

            return DbAccess.executeQuery(sql.ToString());

        }

        public int delete(BrandStore po)
        {
            string sql = String.Format("delete from BrandStore where bs_id='{0}'", po.bsId);

            return DbAccess.executeUpdate(sql);
        }
    }
}
