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
    public partial class FrmSetup : Form
    {
        public FrmSetup()
        {
            InitializeComponent();
        }

        private void FrmSetup_Load(object sender, EventArgs e)
        {
            ClsConfig.LoadCfg();
            tbxScan1IP.Text = ClsConfig.Scaner1Ip;
            tbxScan2IP.Text = ClsConfig.Scaner2Ip;
            numScan1Port.Value = ClsConfig.Scaner1Port;
            numScan2Port.Value = ClsConfig.Scaner2Port;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ClsConfig.Scaner1Ip = tbxScan1IP.Text.Trim();
            ClsConfig.Scaner2Ip = tbxScan2IP.Text.Trim();
            ClsConfig.Scaner1Port = (int)numScan1Port.Value;
            ClsConfig.Scaner2Port = (int)numScan2Port.Value;
            ClsConfig.SaveCfg();
            this.Close();
        }
    }
}
