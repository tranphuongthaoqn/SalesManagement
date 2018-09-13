using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SalesManagement.FORM.ThietLapBanDau
{
    public partial class UCDanhSachKhachHang : UserControl
    {
        public UCDanhSachKhachHang()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmKhachHang frm = new FrmKhachHang();
            frm.ShowDialog();
        }
    }
}
