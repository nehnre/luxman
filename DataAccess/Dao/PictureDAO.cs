using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nehnre.DataAccess.Po;
using Nehnre.DataAccess.Common;
using System.Data;

namespace Nehnre.DataAccess.Dao
{
    public class PictureDAO
    {
        public int insert(Picture po)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into Picture values(newid(), ");
            sql.Append(String.Format("{0},", DbAccess.parse(po.picName)));
            sql.Append(String.Format("{0},", DbAccess.parse(po.picPath)));
            sql.Append(String.Format("{0},", DbAccess.parse(po.picExtension)));
            sql.Append(String.Format("{0},", DbAccess.parse(po.picDescrip)));
            sql.Append(String.Format("{0},", DbAccess.parse(po.picTableName)));
            sql.Append(String.Format("{0},", DbAccess.parse(po.picTableId)));
            sql.Append("getdate(), getdate())");

            return DbAccess.executeUpdate(sql.ToString());
        }

        public int update(Picture po)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update Picture set ");
            sql.Append(String.Format("pic_name={0},", DbAccess.parse(po.picName)));
            sql.Append(String.Format("pic_path={0},", DbAccess.parse(po.picPath)));
            sql.Append(String.Format("pic_extension={0},", DbAccess.parse(po.picExtension)));
            sql.Append(String.Format("pic_descrip={0},", DbAccess.parse(po.picDescrip)));
            sql.Append(String.Format("pic_table_name={0},", DbAccess.parse(po.picTableName)));
            sql.Append(String.Format("pic_table_id={0},", DbAccess.parse(po.picTableId)));
            sql.Append("pic_update_time=getdate()");
            sql.Append(String.Format(" where pic_id='{0}'", po.picId));

            return DbAccess.executeUpdate(sql.ToString());
        }

        public DataSet select(Picture po)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from Picture where 1=1");
            if (!String.IsNullOrEmpty(po.picName))
            {
                sql.Append(String.Format(" and pic_name={0}", DbAccess.parse(po.picName)));
            }

            if (!String.IsNullOrEmpty(po.picPath))
            {
                sql.Append(String.Format(" and pic_path={0}", DbAccess.parse(po.picPath)));
            }

            if (!String.IsNullOrEmpty(po.picExtension))
            {
                sql.Append(String.Format(" and pic_extension={0}", DbAccess.parse(po.picExtension)));
            }

            if (!String.IsNullOrEmpty(po.picDescrip))
            {
                sql.Append(String.Format(" and pic_descrip={0}", DbAccess.parse(po.picDescrip)));
            }

            if (!String.IsNullOrEmpty(po.picTableName))
            {
                sql.Append(String.Format(" and pic_table_name={0}", DbAccess.parse(po.picTableName)));
            }

            if (!String.IsNullOrEmpty(po.picTableId))
            {
                sql.Append(String.Format(" and pic_table_id={0}", DbAccess.parse(po.picTableId)));
            }

            if (!String.IsNullOrEmpty(po.picId))
            {
                sql.Append(String.Format(" and pic_id='{0}'", po.picId));
            }

            sql.Append(" order by pic_update_time");

            return DbAccess.executeQuery(sql.ToString());

        }

        public int delete(Picture po)
        {
            string sql = "delete from Picture where ";
            if (!String.IsNullOrEmpty(po.picTableName) && ! String.IsNullOrEmpty(po.picTableId))
            {
                sql += String.Format(" pic_table_name='{0}'", po.picTableName);
                sql += String.Format(" and pic_table_id='{0}'", po.picTableId);
            }
            else
            {
                sql += String.Format(" pic_id='{0}'", po.picId);
            }

            return DbAccess.executeUpdate(sql);
        }

    }
}
