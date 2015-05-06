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
    public partial class FrmBatch : Form
    {
        public FrmBatch()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClsConfig.BatchID = tbxBatchID.Text.Trim();
            ClsConfig.ProductID = tbxProductID.Text.Trim();
            ClsConfig.ProductName = tbxProdName.Text.Trim();
            ClsConfig.ProduceDate = dTProdate.Value.ToString("yyyy-MM-dd");
            ClsConfig.SaveCfg();
            this.Close();
        }

        private void FrmBatch_Load(object sender, EventArgs e)
        {
            tbxBatchID.Text = ClsConfig.BatchID;
            tbxProductID.Text = ClsConfig.ProductID;
            tbxProdName.Text = ClsConfig.ProductName;
            dTProdate.Value =Convert.ToDateTime(ClsConfig.ProduceDate);
            
        }
    }
}
