using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DHN.Device
{
   public static class ClsMain
    {
       public static MTC.Scanner.Normal boxReader = new MTC.Scanner.Normal();
       public static MTC.Scanner.Normal CartonReader = new MTC.Scanner.Normal();
       public static bool IsRun = false;
       public static ClsModel.Carton carton = new ClsModel.Carton();

       /// <summary>
       /// 打开设备
       /// </summary>
       /// <returns></returns>
       public static bool _Open()
       {
           try
           {
               if (!boxReader._Open(ClsConfig.Scaner1Ip, ClsConfig.Scaner1Port))
               {
                   MTC.File.log._log("相机1打开失败！",true);
                   return false;
               }
               if (!CartonReader._Open(ClsConfig.Scaner2Ip, ClsConfig.Scaner2Port))
               {
                   MTC.File.log._log("相机2打开失败",true);
                   return false;
               }
               boxReader._StartJob();
               CartonReader._StartJob();
               boxReader.DataArrived += new MTC.Scanner.Normal.DataArrivedEventHandler(boxReader_DataArrived);
               CartonReader.DataArrived +=new MTC.Scanner.Normal.DataArrivedEventHandler(CartonReader_DataArrived);
               IsRun = true;
               MTC.File.log._log("成功启动设备...",true);
           }
           catch (Exception ex)
           {
               MTC.File.log._log("打开设备有误:"+ex.ToString(),true);
               return false;
           }     
           return IsRun;
       }
 
       /// <summary>
       /// 关闭设备
       /// </summary>
       /// <returns></returns>
       public static bool _Close()
       {
           try
           {
               boxReader._StopJob();
               boxReader._Close();
               CartonReader._StopJob();
               CartonReader._Close();
               boxReader.DataArrived -=new MTC.Scanner.Normal.DataArrivedEventHandler(boxReader_DataArrived);
               CartonReader.DataArrived -=new MTC.Scanner.Normal.DataArrivedEventHandler(CartonReader_DataArrived);
               IsRun = false;
               MTC.File.log._log("成功关闭设备...",true);
           }
           catch (Exception ex)
           {
               MTC.File.log._log("关闭设备有误："+ex.ToString(),true);
               return false;
           }
           return !IsRun;
       }

       /// <summary>
       /// 盒码相机事件
       /// </summary>
       /// <param name="data"></param>
       static void boxReader_DataArrived(string data)
       {
           carton.CodeList.Add(data);
           
       }

       /// <summary>
       /// 箱码相机事件
       /// </summary>
       /// <param name="data"></param>
       static void CartonReader_DataArrived(string data)
       {
           carton.CartonCode = data.Trim();
           
           carton = new ClsModel.Carton();
        
       }

       public static bool RecCarton(ClsModel.Carton carton)
       {
           for (int i = 0; i < carton.CodeList.Count; i++)
           {
              
           }

           return true;
       }





    }
}
