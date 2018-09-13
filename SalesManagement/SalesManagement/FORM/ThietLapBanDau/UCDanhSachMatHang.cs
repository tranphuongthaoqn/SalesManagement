using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SalesManagement.FORM.ThietLapBanDau
{
    public partial class UCDanhSachMatHang : UserControl
    {
        #region ================== Khởi tạo ================== 
        public UCDanhSachMatHang()
        {
            InitializeComponent();
        }
        #endregion

        #region ================== Chức năng ==================

        #endregion

        #region ================== Sự kiện ==================
        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmThongTinHangHoa frm = new FrmThongTinHangHoa();
            frm.Show();
        }
        #endregion
    }
}
