using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using N4_BITCM;
using System.Xml.Linq;
using System.IO;

namespace N4_BTCM
{
    public partial class UC_HoSoCaNhan: UserControl
    {
        private int userId = Login.LoggedInUserId; // Lấy từ Login
        private UserProfile currentUser;
        private UserProfileDAO dao = new UserProfileDAO();
        public UC_HoSoCaNhan()
        {
            InitializeComponent();
            userId = Login.LoggedInUserId;
            LoadNgaySinhComboBox();
            LoadUserProfile();

            // Gắn sự kiện Click cho nút cập nhật
            btnCapNhat.Click += btnCapNhat_Click;
        }

        // Load dữ liệu vào các ComboBox ngày/tháng/năm
        private void LoadNgaySinhComboBox()
        {
            // Ngày từ 1 đến 31
            for (int i = 1; i <= 31; i++)
            {
                cbNgay.Items.Add(i.ToString("D2"));
            }

            // Tháng từ 1 đến 12
            for (int i = 1; i <= 12; i++)
            {
                cbThang.Items.Add(i.ToString("D2"));
            }

            // Năm từ 1950 đến năm hiện tại
            for (int i = 1950; i <= DateTime.Now.Year; i++)
            {
                cbNam.Items.Add(i.ToString());
            }
        }
        private void LoadUserProfile()  // Tải thông tin người dùng từ cơ sở dữ liệu
        {
            currentUser = dao.GetUserProfileById(userId);

            if (currentUser != null)
            {
                txtHoTen.Text = currentUser.HoTen;

                cbGioiTinh.SelectedItem = currentUser.GioiTinh;
                txtSDT.Text = currentUser.SoDienThoai;
                txtEmail.Text = currentUser.Email;
                txtDiaChi.Text = currentUser.DiaChi;

                // Hiển thị ngày sinh (tách ra ngày, tháng, năm)
                DateTime ngaySinh = currentUser.NgaySinh;
                cbNgay.SelectedItem = ngaySinh.Day.ToString("00");   // "01", "02", ...
                cbThang.SelectedItem = ngaySinh.Month.ToString("00");
                cbNam.SelectedItem = ngaySinh.Year.ToString();

                if (currentUser.Avatar != null)
                {
                    pbAvatar.Image = ByteArrayToImage(currentUser.Avatar);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void picAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pbAvatar.Image = Image.FromFile(open.FileName);
                }
            }
        }

        private byte[] ImageToByteArray(Image img) // Chuyển ảnh thành mảng byte để lưu vào SQL
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)  // Chuyển mảng byte từ SQL thành ảnh để hiển thị
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }

        private void txtAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lblGioiTinh_Click(object sender, EventArgs e)
        {

        }

        private void lblSDT_Click(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            currentUser.HoTen = txtHoTen.Text;

            try
            {
                int ngay = int.Parse(cbNgay.SelectedItem?.ToString() ?? "0");
                int thang = int.Parse(cbThang.SelectedItem?.ToString() ?? "0");
                int nam = int.Parse(cbNam.SelectedItem?.ToString() ?? "0");

                currentUser.NgaySinh = new DateTime(nam, thang, ngay);
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn đầy đủ ngày, tháng, năm hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            currentUser.GioiTinh = cbGioiTinh.SelectedItem?.ToString() ?? "";
            currentUser.SoDienThoai = txtSDT.Text;
            currentUser.Email = txtEmail.Text;
            currentUser.DiaChi = txtDiaChi.Text;

            if (pbAvatar.Image != null)
            {
                currentUser.Avatar = ImageToByteArray(pbAvatar.Image);
            }

            if (dao.UpdateUserProfile(currentUser))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
