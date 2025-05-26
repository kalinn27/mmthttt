//// File: N4_BTCM/Login.cs
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Data.SqlClient; // Thêm directive này
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace N4_BTCM
//{
//    public partial class Login : Form
//    {
//        public static int LoggedInUserId { get; private set; } // Biến static để lưu ID người dùng
//        public Login()
//        {
//            InitializeComponent();
//        }

//        private void Login_Load(object sender, EventArgs e)
//        {
//            DBConnection conn = new DBConnection();
//            if (!conn.TestConnection())
//            {
//                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu. Vui lòng kiểm tra cấu hình.", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                // Bạn có thể muốn thoát ứng dụng nếu không kết nối được database
//                // Application.Exit(); 
//            }

//            //adminPassword = "adminpass123";
//        }

//        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
//        {
//            this.Hide(); // Ẩn form login
//            Register registerForm = new Register();
//            registerForm.ShowDialog();
//            this.Close(); // Đóng hẳn sau khi form đăng ký đóng lại
//        }

//        private void btnExit_Click(object sender, EventArgs e)
//        {
//            this.DialogResult = DialogResult.Cancel; // Đặt DialogResult là Cancel khi thoát
//            this.Close(); // Đóng form Login
//        }

//        // Thêm phương thức xử lý sự kiện cho nút Đăng nhập
//        private void btnLogin_Click(object sender, EventArgs e)
//        {
//            string username = txtUsername.Text.Trim();
//            string password = txtPassword.Text;

//            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
//            {
//                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            DBConnection db = new DBConnection();
//            SqlConnection conn = db.GetConnection();

//            if (conn == null)
//            {
//                return;
//            }

//            try
//            {
//                string query = "SELECT UserID, PasswordHash, RoleID, Username AS FullName FROM Accounts WHERE Username = @Username";
//                //string query = "SELECT UserID, PasswordHash, RoleID, FullName FROM Users WHERE Username = @Username";
//                SqlCommand cmd = new SqlCommand(query, conn);
//                cmd.Parameters.AddWithValue("@Username", username);

//                SqlDataReader reader = cmd.ExecuteReader();

//                if (reader.Read())
//                {
//                    string storedPasswordHash = reader["PasswordHash"].ToString();
//                    int userId = Convert.ToInt32(reader["UserID"]); // Có thể dùng sau này
//                    int roleId = Convert.ToInt32(reader["RoleID"]); // Lấy RoleID của người dùng
//                    string fullName = reader["FullName"].ToString();

//                    if (PasswordHasher.VerifyPassword(password, storedPasswordHash))
//                    {
//                        LoggedInUserId = userId; // Lưu ID người dùng đã đăng nhập
//                        // Xác minh mật khẩu thành công
//                        if (roleId == 1) // Kiểm tra RoleID có phải là Admin (RoleID = 1)
//                        {
//                            MessageBox.Show($"Đăng nhập thành công! Chào mừng Quản trị viên, {fullName}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                            this.DialogResult = DialogResult.OK; // Đặt DialogResult là OK
//                            this.Close(); // Đóng form Login để Program.cs chạy MainMenu
//                        }
//                        else
//                        {
//                            MessageBox.Show("Bạn không có quyền truy cập vào hệ thống.", "Truy cập bị từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                            // Không đóng form Login, người dùng có thể thử lại
//                        }
//                    }
//                    else
//                    {
//                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    }
//                }
//                else
//                {
//                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            finally
//            {
//                if (conn.State == ConnectionState.Open)
//                {
//                    conn.Close();
//                }
//            }
//        }
//    }
//}
// File: N4_BTCM/Login.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using N4_BITCM; // Đảm bảo namespace này đúng cho UserProfile, nếu có

namespace N4_BTCM
{
    public partial class Login : Form
    {
        public static int LoggedInUserId { get; private set; } // Biến static để lưu ID người dùng
        public static int LoggedInUserRole { get; private set; } // Biến static để lưu RoleID
        public static string LoggedInFullName { get; private set; } // Biến static để lưu FullName

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            DBConnection connTest = new DBConnection(); // Đổi tên biến để tránh nhầm lẫn
            if (!connTest.TestConnection())
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu. Vui lòng kiểm tra cấu hình.", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Bạn có thể muốn thoát ứng dụng nếu không kết nối được database
                // Application.Exit();
            }
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // Ẩn form login
            Register registerForm = new Register(); // Đảm bảo class Register tồn tại
            registerForm.ShowDialog();
            this.Close(); // Đóng hẳn sau khi form đăng ký đóng lại
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Đặt DialogResult là Cancel khi thoát
            this.Close(); // Đóng form Login
        }

        // Thêm phương thức xử lý sự kiện cho nút Đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DBConnection db = new DBConnection();
            SqlConnection conn = null; // Khởi tạo null

            try
            {
                conn = db.GetConnection(); // Lấy kết nối
                if (conn == null)
                {
                    MessageBox.Show("Không thể lấy kết nối đến cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Mở kết nối nếu nó chưa được mở
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // Query lấy thông tin từ bảng Accounts (hoặc UserProfiles nếu bạn đang dùng nó làm bảng tài khoản)
                // Theo các ảnh bạn cung cấp, bảng UserProfiles có các cột Username, PasswordHash, RoleID.
                // Nếu bạn đã tách ra bảng Accounts, hãy đảm bảo query này đúng với cấu trúc bảng Accounts.
                // Ở đây tôi dùng "Username AS FullName" để phù hợp với code cũ của bạn, nhưng nếu FullName là cột riêng, hãy dùng FullName.
                string query = "SELECT UserID, PasswordHash, RoleID, FullName FROM UserProfiles WHERE Username = @Username"; // Dùng UserProfiles như ảnh mới nhất
                                                                                                                             // Nếu bạn chắc chắn đã tạo bảng Accounts riêng và chuyển dữ liệu sang đó, thì dùng:
                                                                                                                             // string query = "SELECT UserID, PasswordHash, RoleID, Username AS FullName FROM Accounts WHERE Username = @Username";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string storedPasswordHash = reader["PasswordHash"].ToString();
                    LoggedInUserId = Convert.ToInt32(reader["UserID"]);
                    LoggedInUserRole = Convert.ToInt32(reader["RoleID"]);
                    LoggedInFullName = reader["FullName"] != DBNull.Value ? reader["FullName"].ToString() : username; // Lấy FullName hoặc Username nếu FullName null

                    // Gọi phương thức VerifyPassword từ PasswordHasher
                    if (PasswordHasher.VerifyPassword(password, storedPasswordHash))
                    {
                        // Xác minh mật khẩu thành công
                        if (LoggedInUserRole == 1) // Kiểm tra RoleID có phải là Admin (RoleID = 1)
                        {
                            MessageBox.Show($"Đăng nhập thành công! Chào mừng Quản trị viên, {LoggedInFullName}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK; // Đặt DialogResult là OK
                            this.Close(); // Đóng form Login để Program.cs chạy MainMenu (hoặc form Admin)
                        }
                        else if (LoggedInUserRole == 2) // Giả định RoleID = 2 là Khách hàng
                        {
                            MessageBox.Show($"Đăng nhập thành công! Chào mừng Khách hàng, {LoggedInFullName}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Mở Form KhachHang
                            this.Hide();
                            KhachHang khachHangForm = new KhachHang(); // Đảm bảo class KhachHang tồn tại
                            khachHangForm.ShowDialog(); // Hiển thị dưới dạng Dialog
                            this.Close(); // Đóng form Login sau khi form KhachHang đóng
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản của bạn không có quyền truy cập.", "Truy cập bị từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi chi tiết hơn nếu có thể
                System.Diagnostics.Debug.WriteLine($"Lỗi khi đăng nhập: {ex.Message}");
                MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}