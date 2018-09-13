using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SalesManagement.FORM.ThietLapBanDau
{
    public partial class FrmThongTinHangHoa : Form
    {
        #region ======================= Khởi tạo =======================
        public FrmThongTinHangHoa()
        {
            InitializeComponent();
        }
        #endregion

        #region ======================= Chức năng =======================
        #endregion

        #region ======================= Sự kiện =======================
        private void btnThemDonViTinh_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThemNhaCungCap_Click(object sender, EventArgs e)
        {
            FrmDanhSachDVT frm = new FrmDanhSachDVT();
            frm.ShowDialog();
        }

        private void btnThemDonViTinh2_Click(object sender, EventArgs e)
        {
            FrmDanhSachDVT frm = new FrmDanhSachDVT();
            frm.ShowDialog();
        }
        #endregion
    }
}
