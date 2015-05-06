using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace DHN
{
   
    public static class ClsConfig
    {


        #region 设备通讯参数
        public static string Scaner1Ip = "";
        public static int Scaner1Port =1234;
        public static string Scaner2Ip = "";
        public static int Scaner2Port = 1234;
        #endregion
        public static string Date = DateTime.Now.ToString("yyMMddHHmmss");
        public static string DataPath=AppDomain .CurrentDomain .BaseDirectory+@"\Data\DBInfo.db";

        public static string BatchID;
        public static string ProductID;
        public static string ProductName;
        public static string ProduceDate;

        public static void LoadCfg()
        {
            BatchID = ClsConfig.ReadCfg("Production", "BatchID", "1234567");
            ProductID = ClsConfig.ReadCfg("Production", "ProductID", "10001");
            ProductName = ClsConfig.ReadCfg("Production", "ProductName", "大华农动物药");
            ProduceDate = ClsConfig.ReadCfg("Production", "ProduceDate", "2015/05/04");

            Scaner1Ip = ClsConfig.ReadCfg("Device", "Scaner1Ip", "192.168.1.1");
            Scaner1Port = int.Parse(ClsConfig.ReadCfg("Device", "Scaner1Port", "1234"));
            Scaner2Ip = ClsConfig.ReadCfg("Device", "Scaner2Ip", "192.168.1.1");
            Scaner2Port = int.Parse(ClsConfig.ReadCfg("Device", "Scaner2Port", "1234"));
        }

        public static void SaveCfg()
        {
            ClsConfig.WriteCfg("Production", "BatchID", BatchID);
            ClsConfig.WriteCfg("Production", "ProductID", ProductID);
            ClsConfig.WriteCfg("Production", "ProductName", ProductName);
            ClsConfig.WriteCfg("Production", "ProduceDate", ProduceDate);

            ClsConfig.WriteCfg("Device", "Scaner1Ip", Scaner1Ip);
            ClsConfig.WriteCfg("Device", "Scaner1Port", Scaner1Port.ToString());
            ClsConfig.WriteCfg("Device", "Scaner2Ip", Scaner2Ip);
            ClsConfig.WriteCfg("Device", "Scaner2Port", Scaner2Port.ToString());
        }

        #region 公共方法

        [DllImport("kernel32.dll")]
        public static extern long WritePrivateProfileString(string section, string key, string value, string path);

        [DllImport("kernel32.dll")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filepath);

        public static string DefaultPath = AppDomain.CurrentDomain.BaseDirectory + @"/Config.ini";

        public static bool WriteCfg(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, DefaultPath);
            return true;
        } //修改配置文件

        public static string ReadCfg(string section, string key, string def)
        {
            StringBuilder temp = new StringBuilder();
            GetPrivateProfileString(section, key, def, temp, 255, DefaultPath);
            return temp.ToString(); ;
        }//读取配置文件
        #endregion 
    }
}
