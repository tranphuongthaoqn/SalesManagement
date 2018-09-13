using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SalesManagement.FORM.ThietLapBanDau
{
    public partial class UCNhaCungCap : UserControl
    {
        public UCNhaCungCap()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmNhaCungCap frm = new FrmNhaCungCap();
            frm.ShowDialog();
        }
    }
}
