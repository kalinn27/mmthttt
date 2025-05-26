using System;
using System.Data.SqlClient;
using N4_BITCM; // Đảm bảo namespace này đúng nếu UserProfile ở đây
                // Nếu UserProfile ở N4_BTCM, thì không cần dòng này

namespace N4_BTCM
{
    public class UserProfileDAO
    {
        private readonly DBConnection db = new DBConnection();

        /// <summary>
        /// Lấy thông tin hồ sơ người dùng theo ID.
        /// </summary>
        public UserProfile GetUserProfileById(int userId)
        {
            UserProfile user = null;

            using (SqlConnection conn = db.GetConnection())
            {
                // Thay đổi query để select từ bảng UserProfiles và các cột tương ứng
                // Tên cột trong DB là UserID, FullName, Email, Phone, Address
                string query = @"SELECT
                                    up.UserID,
                                    up.FullName AS HoTen, -- Ánh xạ FullName sang HoTen
                                    up.NgaySinh,
                                    up.GioiTinh,
                                    up.Phone AS SoDienThoai, -- Ánh xạ Phone sang SoDienThoai
                                    up.Email,
                                    up.Address AS DiaChi, -- Ánh xạ Address sang DiaChi
                                    up.Avatar
                                 FROM UserProfiles up
                                 WHERE up.UserID = @UserID"; // Thay Id thành UserID

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId); // Thay @Id thành @UserID

                //conn.Open(); // Mở kết nối trước khi thực thi lệnh

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserProfile
                        {
                            Id = (int)reader["UserID"], // Đọc từ cột UserID
                            HoTen = reader["HoTen"] != DBNull.Value ? reader["HoTen"].ToString() : string.Empty, // Sử dụng alias HoTen
                            NgaySinh = reader["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["NgaySinh"]) : DateTime.MinValue,
                            GioiTinh = reader["GioiTinh"] != DBNull.Value ? reader["GioiTinh"].ToString() : string.Empty,
                            SoDienThoai = reader["SoDienThoai"] != DBNull.Value ? reader["SoDienThoai"].ToString() : string.Empty, // Sử dụng alias SoDienThoai
                            Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty,
                            DiaChi = reader["DiaChi"] != DBNull.Value ? reader["DiaChi"].ToString() : string.Empty, // Sử dụng alias DiaChi
                            Avatar = reader["Avatar"] != DBNull.Value ? (byte[])reader["Avatar"] : null
                        };
                    }
                }
            }

            return user;
        }

        /// <summary>
        /// Cập nhật thông tin hồ sơ người dùng.
        /// </summary>
        public bool UpdateUserProfile(UserProfile profile)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"UPDATE UserProfiles SET
                                        FullName = @FullName,     -- Đổi HoTen thành FullName
                                        NgaySinh = @NgaySinh,
                                        GioiTinh = @GioiTinh,
                                        Phone = @Phone,           -- Đổi SoDienThoai thành Phone
                                        Email = @Email,
                                        Address = @Address,       -- Đổi DiaChi thành Address
                                        Avatar = @Avatar
                                  WHERE UserID = @UserID";     // Đổi Id thành UserID

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", profile.HoTen); // Ánh xạ HoTen của model sang FullName của DB
                cmd.Parameters.AddWithValue("@NgaySinh", profile.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", profile.GioiTinh);
                cmd.Parameters.AddWithValue("@Phone", profile.SoDienThoai); // Ánh xạ SoDienThoai của model sang Phone của DB
                cmd.Parameters.AddWithValue("@Email", profile.Email);
                cmd.Parameters.AddWithValue("@Address", profile.DiaChi); // Ánh xạ DiaChi của model sang Address của DB
                cmd.Parameters.AddWithValue("@Avatar", (object)profile.Avatar ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UserID", profile.Id); // Ánh xạ Id của model sang UserID của DB

                conn.Open(); // Mở kết nối trước khi thực thi lệnh

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}