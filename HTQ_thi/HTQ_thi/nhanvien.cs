using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace HTQ_thi
{
    public partial class nhanvien : Form
    {
        
        public nhanvien()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=TANNGUYEN-LAPTO;Initial Catalog=bank;Integrated Security=True");

        private void Load_taikhoan()
        {
            string query = "SELECT  id_tk, so_tk, name, ngaycap, sodu, loaitk.name_ltk, branch.name_cn FROM taikhoan INNER JOIN loaitk ON taikhoan.id_ltk = loaitk.id_ltk INNER JOIN branch ON taikhoan.id_cn = branch.id_cn ";
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.DefaultView.Sort = "id_tk ASC";
            dt = dt.DefaultView.ToTable();

            dt.Columns["so_tk"].ColumnName = "Số Tài Khoản";
            dt.Columns["name"].ColumnName = "Tên";
            dt.Columns["ngaycap"].ColumnName = "Ngày Cấp";
            dt.Columns["sodu"].ColumnName = "Số Dư";
            dt.Columns["name_ltk"].ColumnName = "Loại Tài Khoản";
            dt.Columns["name_cn"].ColumnName = "Chi Nhánh";
            dt.Columns.Remove("id_tk");
            dgvntaikhoan.DataSource = dt;
            dgvntaikhoan.ClearSelection();
            dgvntaikhoan.Refresh();
        }
        private void nhanvien_Load(object sender, EventArgs e)
        {
            Load_branch();
            Load_loaiTK();
        }

        private void Load_branch()
        {
            string query = string.Format("SELECT * FROM branch");
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.DefaultView.Sort = "id_cn ASC";
            dt = dt.DefaultView.ToTable();
            chinhanhTK_cbb.DisplayMember = "name_cn";
            chinhanhTK_cbb.ValueMember = "id_cn";
            chinhanhTK_cbb.DataSource = dt;
        }
        private void Load_loaiTK()
        {
            string query = string.Format("SELECT * FROM loaitk");
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.DefaultView.Sort = "id_ltk ASC";
            dt = dt.DefaultView.ToTable();
            loaiTK_cbb.DisplayMember = "name_ltk";
            loaiTK_cbb.ValueMember = "id_ltk";
            loaiTK_cbb.DataSource = dt;
 
        } 

        private void dgvntaikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0 && i < dgvntaikhoan.Rows.Count) 
            {
                string soTK = dgvntaikhoan.Rows[i].Cells[0].Value.ToString();
                string nameLTK = dgvntaikhoan.Rows[i].Cells[4].Value.ToString();
                if (soTK != "")
                {
                    string query = string.Format("SELECT taikhoan.*,loaitk.name_ltk,branch.name_cn FROM taikhoan INNER JOIN loaitk ON taikhoan.id_ltk = loaitk.id_ltk INNER JOIN branch ON taikhoan.id_cn = branch.id_cn WHERE so_tk = '{0}' AND name_ltk = N'{1}'", soTK, nameLTK);
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if(dt.Rows.Count>0)
                    {
                        DataRow x = dt.Rows[0];
                        sotk_text.Text = x["so_tk"].ToString();
                        name_text.Text = x["name"].ToString();
                        ngaysinh_dtp.Text = x["dateofbirth"].ToString();
                        gioitinh_text.Text = x["sex"].ToString();
                        sdt_text.Text = x["phone"].ToString();
                        cmnd_text.Text = x["cmnd"].ToString();
                        diachi_text.Text = x["address"].ToString();
                        ngaycap_dtp.Text = x["ngaycap"].ToString();

                        loaiTK_cbb.SelectedIndex = Convert.ToInt32(x["id_ltk"]);
                        chinhanhTK_cbb.SelectedIndex = Convert.ToInt32(x["id_cn"]);
                        sotk_text.Tag = x["id_tk"].ToString();
                    }
                    
                }
            }
            
            
        } 

       

        private void key_search_text_KeyDown(object sender, KeyEventArgs e)
        {
            dgvntaikhoan.DataSource = null;
            if(e.KeyCode == Keys.Enter)
            {
                if(key_search_text.Text.Trim() != "")
                {
                    string key = key_search_text.Text.ToString().Trim();
                    string query = "SELECT id_tk, so_tk, name, ngaycap, sodu, loaitk.name_ltk, branch.name_cn FROM taikhoan INNER JOIN loaitk ON taikhoan.id_ltk = loaitk.id_ltk INNER JOIN branch ON taikhoan.id_cn = branch.id_cn WHERE name LIKE '%" + key + "%' OR so_tk LIKE '%" + key + "%' ";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dt.DefaultView.Sort = "id_tk ASC";
                    dt = dt.DefaultView.ToTable();

                    dt.Columns["so_tk"].ColumnName = "Số Tài Khoản";
                    dt.Columns["name"].ColumnName = "Tên";
                    dt.Columns["ngaycap"].ColumnName = "Ngày Cấp";
                    dt.Columns["sodu"].ColumnName = "Số Dư";
                    dt.Columns["name_ltk"].ColumnName = "Loại Tài Khoản";
                    dt.Columns["name_cn"].ColumnName = "Chi Nhánh";
                    dt.Columns.Remove("id_tk");

                    dgvntaikhoan.DataSource = dt;
                    dgvntaikhoan.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập vào ô tìm kiếm!");
                }
                
            }
        }


        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsx_btn.Text = "Thêm Tài Khoản";
            tsx_btn.Visible = true;

        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsx_btn.Text = "Cập Nhật Tài Khoản";
            tsx_btn.Visible = true;
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsx_btn.Text = "Xóa Tài Khoản";
            tsx_btn.Visible = true;
        }

        private void tsx_btn_Click(object sender, EventArgs e)
        {
            if (sotk_text.Text != "" && name_text.Text != "" && gioitinh_text.Text != "" && ngaysinh_dtp.Text != "" && sdt_text.Text != "" && diachi_text.Text != "" && cmnd_text.Text != "" && ngaycap_dtp.Text != "" && chinhanhTK_cbb.SelectedItem != null && loaiTK_cbb.SelectedItem != null)
            {
                if (tsx_btn.Text == "Thêm Tài Khoản")
                {
                    bool them = Them();
                    if(them)
                    {
                        MessageBox.Show("Thêm Tài Khoản Thành Công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm Tài Khoản Không Thành Công!");
                    }
                }
                else if (tsx_btn.Text == "Cập Nhật Tài Khoản")
                {
                    bool sua = Sua(Convert.ToInt32(sotk_text.Tag));
                    if (sua)
                    {
                        MessageBox.Show("Cập Nhập Tài Khoản Thành Công!");
                    }
                    else
                    {
                        MessageBox.Show("Cập Nhập Tài Khoản Không Thành Công!");
                    }
                }
                else if (tsx_btn.Text == "Xóa Tài Khoản")
                {
                    bool xoa = Xoa(Convert.ToInt32(sotk_text.Tag));
                    if (xoa)
                    {
                        MessageBox.Show("Xóa Tài Khoản Thành Công!");
                    }
                    else
                    {
                        MessageBox.Show("Xóa Tài Khoản Không Thành Công!");
                    }
                }

                Load_taikhoan();

            }
            else
            {
                MessageBox.Show("Vui Lòng Điền Đủ Thông Tin!");
            }
            

        }

        private bool Them()
        {
            string zero = sotk_text.Text.ToString().Trim();
            string one = name_text.Text.ToString().Trim();
            string two = ngaysinh_dtp.Text;
            string three = sdt_text.Text.ToString().Trim();
            string four = diachi_text.Text.ToString().Trim();
            string five = cmnd_text.Text.ToString().Trim();
            string six = gioitinh_text.Text.ToString().Trim();
            string seven = ngaycap_dtp.Text;
            int eight = loaiTK_cbb.SelectedIndex;
            int nine = chinhanhTK_cbb.SelectedIndex;

            string select = string.Format("SELECT * FROM taikhoan WHERE so_tk = '{0}' AND id_ltk = '{1}'", zero, eight);
            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count>1)
            {
                MessageBox.Show("Số Tài Khoản Với Loại Tài Khoản Này Đã Tồn Tại!");
                return false;
            }
            else
            {
                try
                {
                    con.Open();
                    string query = string.Format("INSERT INTO taikhoan(so_tk,name,dateofbirth,phone,address,cmnd,sex,ngaycap,id_ltk,id_cn,sodu) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}') ", zero, one, two, three, four, five, six, seven, eight, nine, 0);
                    SqlCommand cmd = new SqlCommand(query, con);
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }

                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    con.Close();
                }
                return false;
            }
            
        }
        private bool Sua(int id)
        {
            string zero = sotk_text.Text.ToString().Trim();
            string one = name_text.Text.ToString().Trim();
            string two = ngaysinh_dtp.Text;
            string three = sdt_text.Text.ToString().Trim();
            string four = diachi_text.Text.ToString().Trim();
            string five = cmnd_text.Text.ToString().Trim();
            string six = gioitinh_text.Text.ToString().Trim();
            string seven = ngaycap_dtp.Text;
            int eight = loaiTK_cbb.SelectedIndex;
            int nine = chinhanhTK_cbb.SelectedIndex;

            string select = string.Format("SELECT * FROM taikhoan WHERE so_tk = '{0}' AND id_ltk = '{1}'", zero, eight);
            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 1)
            {
                MessageBox.Show("Số Tài Khoản Với Loại Tài Khoản Này Đã Tồn Tại!");
                return false;
            }
            else
            {
                try
                {
                    con.Open();
                    string query = string.Format("UPDATE taikhoan SET so_tk = '{0}',name = '{1}',dateofbirth = '{2}',phone = '{3}',address = '{4}',cmnd = '{5}',sex = '{6}',ngaycap = '{7}',id_ltk = '{8}',id_cn = '{9}' WHERE id_tk = '{10}'", zero, one, two, three, four, five, six, seven, eight, nine, id);
                    SqlCommand cmd = new SqlCommand(query, con);
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    con.Close();
                }

                return false;
            }
            
            

        }
        private bool Xoa(int id)
        {
            DialogResult rst = MessageBox.Show("Bạn Chắc Chắn Muốn Xóa Tài Khoản", "Thông Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (rst == DialogResult.Yes)
            {            
                try
                {
                    con.Open();
                    string query = string.Format("DELETE FROM taikhoan WHERE id_tk = '{0}'", id);
                    SqlCommand cmd = new SqlCommand(query, con);
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    con.Close();
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        private void key_search_text_Click(object sender, EventArgs e)
        {
            key_search_text.Text = "";
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            sotk_text.Text = "";
            name_text.Text = "";
            gioitinh_text.Text = "";
            sdt_text.Text = "";
            diachi_text.Text = "";
            cmnd_text.Text = "";
            sotk_text.Tag = null;
            chinhanhTK_cbb.SelectedIndex = 0;
            loaiTK_cbb.SelectedIndex = 0;

        }

        private void login_nv_btn_Click(object sender, EventArgs e)
        {
            string user = user_nv_text.Text.ToString();
            string pass = pass_nv_text.Text.ToString();
            string select = string.Format("SELECT * FROM nhanvien WHERE user_nv = N'{0}' AND pass_nv = '{1}'", user, pass);
            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string name = dt.Rows[0]["name_nv"].ToString();
                user_nv_text.Tag = dt.Rows[0]["id_nv"].ToString();
                ma_nv_lb.Text = dt.Rows[0]["ma_nv"].ToString();
                Load_taikhoan();
                MessageBox.Show("Chào Mừng Nhân Viên " + name);
                login_pnl.Visible = false;
                error_lb.Visible = false;
            }
            else
            {
                error_lb.Visible = true;
            }
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            ma_nv_lb.Text = "";
            user_nv_text.Text = "";
            pass_nv_text.Text = "";
            user_nv_text.Tag = null;
            chinhanhTK_cbb.Tag = null;
            login_pnl.Visible = true;
        }

        private void login_pnl_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
