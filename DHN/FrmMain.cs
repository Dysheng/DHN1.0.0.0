using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DHN
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void TlsMnuExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lblboxSN_Click(object sender, EventArgs e)
        {

        }

        private void TlsMnuSetup_Click(object sender, EventArgs e)
        {
            FrmSetup fs = new FrmSetup();
            fs.ShowDialog();
        }

        private void TlsMnuData_Click(object sender, EventArgs e)
        {
            FrmUpload fu = new FrmUpload();
            fu.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName + " " + Application.ProductVersion;
            ClsConfig.LoadCfg();
            MTC.File.log._Open(listBoxLog);
            MTC.File.Alarm.Ini(tabControl2.TabPages,listBoxAlarm);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            btnRun.Enabled = false;
            if (btnRun.Text == "运行")
            {
                if (Device.ClsMain._Open())
                {
                    btnRun.Enabled = true;
                    btnRun.BackColor = Color.Red;
                    btnRun.Text = "停止";
                }
                else
                {
                    btnRun.BackColor = Color.LightGreen;
                    btnRun.Text = "运行";
                    btnRun.Enabled = true;
                }
            }
            else
            {
                if (Device.ClsMain._Close())
                {
                    btnRun.BackColor = Color.LightGreen;
                    btnRun.Text = "运行";
                }
                else
                {
                    btnRun.Enabled = true;
                    btnRun.BackColor = Color.Red;
                    btnRun.Text = "停止";
                }             
            }
            btnRun.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Device.ClsModel.Carton cc = new Device.ClsModel.Carton();
            cc.CodeList = new List<string>();
            cc.CartonCode = "1234567";
            for (int i = 0; i <100; i++)
            {
                cc.CodeList.Add(i.ToString().PadLeft(24,'k'));
            }
            Data.ClsData.RecCarton(cc);
            MTC.File.log._log("完成！",false);
        }

        private void TlsMnuBatch_Click(object sender, EventArgs e)
        {
            FrmBatch fb = new FrmBatch();
            fb.ShowDialog();
            lblInfo.Text = "批号："+ClsConfig.BatchID + "\r\n" +
             "产品ID："+ClsConfig.ProductID + "\r\n" +
             "产品名称："+ClsConfig.ProductName + "\r\n" +
              "生产日期："+ ClsConfig.ProduceDate;
        }
    }
}
