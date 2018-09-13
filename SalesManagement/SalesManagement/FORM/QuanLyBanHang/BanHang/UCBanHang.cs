using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SalesManagement.FORM.QuanLyBanHang.BanHang
{
    public partial class UCBanHang : UserControl
    {
        public UCBanHang()
        {
            InitializeComponent();
        }

        private void txtMaVach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                txtMaVach.SelectAll();
                MessageBox.Show(txtMaVach.Text);
            }
        }
    }
}
