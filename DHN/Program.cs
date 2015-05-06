using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DHN
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        private static int RunningInstance() //检查程序的启动次数
        {
            System.Diagnostics.Process current;
            current = System.Diagnostics.Process.GetCurrentProcess();
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName(current.ProcessName);
            foreach (System.Diagnostics.Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    if (System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("/", @"\") == current.MainModule.FileName)
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }
        [STAThread]
        static void Main()
        {
            #region 检查是否重复启动
            if (RunningInstance() > 0)
            {
                MessageBox.Show("程序已经存在..");
                Application.Exit();
                return;
                //退出当前程序
            }
            #endregion

            string s1 = ClsGrandDog.ClsGrandDog.DogExistIs(ModSoftDog.ClsDES.SoftProductID);
            string s2 = ModSoftDog.ClsDES.GetSN(ModSoftDog.ClsDES.SoftProductID.PadLeft(8, '0'));
            if (s1 != s2)
            {
                System.Windows.Forms.MessageBox.Show("程序需要维护，请与供应商联系...", "警告信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                Application.Exit();
                return;
                //退出当前程序
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
 
            Application.Run(new FrmMain());
        }
    }
}
