using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DHN.Data
{
    public static class ClsData
    {
        public static void RecCarton(Device.ClsModel.Carton  carton)
        {
            ArrayList ListSql = new ArrayList() ;
            for (int i = 0; i < carton.CodeList.Count; i++)
            {
                string sql = "Insert into II_Code(IICode,IIICode,BatchID,CodeDate)Values('"+carton.CodeList[i]+"','"+carton.CartonCode+"','1234','"+DateTime.Now .ToString("yyyy-MM-dd HH:mm:ss:ffff")+"')";
                ListSql.Add(sql);
            }
            DbHelperSQLite.ExecuteSqlTran(ListSql);            
        }
    }
}
