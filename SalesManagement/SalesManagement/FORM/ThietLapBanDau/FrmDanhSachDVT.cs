using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SalesManagement.FORM.ThietLapBanDau
{
    public partial class FrmDanhSachDVT : Form
    {
        #region ======================= Khởi tạo =======================
        public FrmDanhSachDVT()
        {
            InitializeComponent();
        }
        #endregion

        #region ======================= Chức năng =======================
        #endregion

        #region ======================= Sự kiện =======================
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            FrmThemDVT frm = new FrmThemDVT();
            frm.ShowDialog();
        }
        #endregion
    }
}
