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
    public partial class Quanly : Form
    {
        public Quanly()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=TANNGUYEN-LAPTO;Initial Catalog=bank;Integrated Security=True");
        private void Load_nhanvien()
        {
            string query = string.Format("SELECT ma_nv, name_nv, dateofbirth, sex, phone, address,cmnd FROM nhanvien INNER JOIN branch ON nhanvien.id_cn = branch.id_cn WHERE branch.id_cn = '{0}'",Convert.ToInt32(chinhanhQL_cbb.Tag));
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dt.DefaultView.Sort = "ma_nv ASC";
            dt = dt.DefaultView.ToTable();

            dt.Columns["ma_nv"].ColumnName = "Mã Nhân Viên";
            dt.Columns["name_nv"].ColumnName = "Tên";
            dt.Columns["dateofbirth"].ColumnName = "Ngày Sinh";
            dt.Columns["sex"].ColumnName = "Giới Tính";
            dt.Columns["phone"].ColumnName = "Số ĐT";
            dt.Columns["address"].ColumnName = "Địa Chỉ";
            dt.Columns["cmnd"].ColumnName = "CMND";

            dgvnnhanvien.DataSource = dt;
            dgvnnhanvien.ClearSelection();
            dgvnnhanvien.Refresh();

        }
        private void Load_branch_nv()
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
        private void Quanly_Load(object sender, EventArgs e)
        {
            Load_nhanvien();
            Load_branch_nv();
        }

        private void dgvnnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0 && i < dgvnnhanvien.Rows.Count)
            {
                string maNV = dgvnnhanvien.Rows[i].Cells[0].Value.ToString();
                if (maNV != "")
                {
                    string query = string.Format("SELECT nhanvien.* FROM nhanvien WHERE ma_nv = '{0}' AND nhanvien.id_cn = '{1}'", maNV, Convert.ToInt32(chinhanhQL_cbb.Tag));
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DataRow x = dt.Rows[0];
                    user_nv_text.Text = x["user_nv"].ToString();
                    pass_nv_text.Text = x["pass_nv"].ToString();
                    manv_text.Text = x["ma_nv"].ToString();
                    name_text.Text = x["name_nv"].ToString();
                    ngaysinh_dtp.Text = x["dateofbirth"].ToString();
                    gioitinh_text.Text = x["sex"].ToString();
                    sdt_text.Text = x["phone"].ToString();
                    cmnd_text.Text = x["cmnd"].ToString();
                    diachi_text.Text = x["address"].ToString();
     
                    chinhanhTK_cbb.SelectedIndex = chinhanhQL_cbb.SelectedIndex;
                    manv_text.Tag = x["id_nv"].ToString();
                }
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            user_nv_text.Text = "";
            pass_nv_text.Text = "";
            name_text.Text = "";
            gioitinh_text.Text = "";
            sdt_text.Text = "";
            diachi_text.Text = "";
            cmnd_text.Text = "";
            manv_text.Text = "";
            manv_text.Tag = null;
            chinhanhTK_cbb.SelectedIndex = 0;

        }

        private void key_search_text_KeyDown(object sender, KeyEventArgs e)
        {
            dgvnnhanvien.DataSource = null;
            if (e.KeyCode == Keys.Enter)
            {
                if (key_search_text.Text.Trim() != "")
                {
                    string key = key_search_text.Text.ToString().Trim();
                    string query = string.Format("SELECT ma_nv, name_nv, dateofbirth, sex, phone, address,cmnd, branch.name_cn FROM nhanvien INNER JOIN branch ON nhanvien.id_cn = branch.id_cn WHERE (name_nv LIKE '%" + key + "%' OR name_cn LIKE '%" + key + "%' OR ma_nv LIKE '%" + key + "%') AND nhanvien.id_cn = '{0}'", Convert.ToInt32(chinhanhQL_cbb.Tag)) ;
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dt.DefaultView.Sort = "ma_nv ASC";
                    dt = dt.DefaultView.ToTable();

                    dt.Columns["ma_nv"].ColumnName = "Mã Nhân Viên";
                    dt.Columns["name_nv"].ColumnName = "Tên";
                    dt.Columns["dateofbirth"].ColumnName = "Ngày Sinh";
                    dt.Columns["sex"].ColumnName = "Giới Tính";
                    dt.Columns["phone"].ColumnName = "Số ĐT";
                    dt.Columns["address"].ColumnName = "Địa Chỉ";
                    dt.Columns["cmnd"].ColumnName = "CMND";
                    dt.Columns["name_cn"].ColumnName = "Chi Nhánh Làm Việc";


                    dgvnnhanvien.DataSource = dt;
                    dgvnnhanvien.ClearSelection();
                    dgvnnhanvien.Refresh();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập vào ô tìm kiếm!");
                }

            }
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsx_btn.Text = "Thêm Nhân Viên";
            tsx_btn.Visible = true;
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsx_btn.Text = "Cập Nhật Nhân Viên";
            tsx_btn.Visible = true;
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsx_btn.Text = "Xóa Nhân Viên";
            tsx_btn.Visible = true;
        }

        private void tsx_btn_Click(object sender, EventArgs e)
        {
            if (user_nv_text.Text != "" && name_text.Text != "" && ngaysinh_dtp.Text != "" && gioitinh_text.Text != "" && sdt_text.Text != "" && diachi_text.Text != "" && cmnd_text.Text != "" && pass_nv_text.Text != "" && chinhanhTK_cbb.SelectedItem != null)
            {
                if (tsx_btn.Text == "Thêm Nhân Viên")
                {
                    bool them = Them();
                    if (them)
                    {
                        MessageBox.Show("Thêm Nhân Viên Thành Công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm Nhân Viên Không Thành Công!");
                    }
                }
                else if (tsx_btn.Text == "Cập Nhật Nhân Viên")
                {
                    bool sua = Sua(Convert.ToInt32(manv_text.Tag));
                    if (sua)
                    {
                        MessageBox.Show("Cập Nhập Nhân Viên Thành Công!");
                    }
                    else
                    {
                        MessageBox.Show("Cập Nhập Nhân Viên Không Thành Công!");
                    }
                }
                else if (tsx_btn.Text == "Xóa Nhân Viên")
                {
                    bool xoa = Xoa(Convert.ToInt32(manv_text.Tag));
                    if (xoa)
                    {
                        MessageBox.Show("Xóa Nhân Viên Thành Công!");
                    }
                    else
                    {
                        MessageBox.Show("Xóa Nhân Viên Không Thành Công!");
                    }
                }

                Load_nhanvien();

            }
            else
            {
                MessageBox.Show("Vui Lòng Điền Đủ Thông Tin!");
            }

        }
        private bool Them()
        {
            string zero = user_nv_text.Text.ToString().Trim();
            string one = name_text.Text.ToString().Trim();
            string two = ngaysinh_dtp.Text;
            string three = sdt_text.Text.ToString().Trim();
            string four = diachi_text.Text.ToString().Trim();
            string five = cmnd_text.Text.ToString().Trim();
            string six = gioitinh_text.Text.ToString().Trim();
            string seven = pass_nv_text.Text.ToString().Trim();
            int eight = Convert.ToInt32(chinhanhTK_cbb.Tag);
            string nine = manv_text.Text.ToString().Trim();


            string select1 = string.Format("SELECT * FROM nhanvien WHERE ma_nv = '{0}' AND id_cn = '{1}'", nine, eight);
            SqlDataAdapter da1 = new SqlDataAdapter(select1, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            string select2 = string.Format("SELECT * FROM nhanvien WHERE user_nv = N'{0}' AND id_cn = '{1}'", zero, eight);
            SqlDataAdapter da2 = new SqlDataAdapter(select2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            if (dt1.Rows.Count > 1)
            {
                MessageBox.Show("Mã Nhân Viên Với Chi Nhánh Này Đã Tồn Tại!");
                return false;
            }          
            else if (dt2.Rows.Count > 1)
            {
                MessageBox.Show("Tên Đăng Nhập Với Chi Nhánh Này Đã Tồn Tại!");
                return false;
            }
            else
            {
                try
                {
                    con.Open();
                    string query = string.Format("INSERT INTO nhanvien(user_nv,name_nv,dateofbirth,phone,address,cmnd,sex,pass_nv,id_cn,ma_nv) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}') ", zero, one, two, three, four, five, six, seven, eight, nine);
                    SqlCommand cmd = new SqlCommand(query, con);
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }

                }
                catch (Exception)
                {

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
            string zero = user_nv_text.Text.ToString().Trim();
            string one = name_text.Text.ToString().Trim();
            string two = ngaysinh_dtp.Text;
            string three = sdt_text.Text.ToString().Trim();
            string four = diachi_text.Text.ToString().Trim();
            string five = cmnd_text.Text.ToString().Trim();
            string six = gioitinh_text.Text.ToString().Trim();
            string seven = pass_nv_text.Text.ToString().Trim();
            int eight = Convert.ToInt32(chinhanhTK_cbb.Tag);
            string nine = manv_text.Text.ToString().Trim();

            string select = string.Format("SELECT * FROM nhanvien WHERE ma_nv = '{0}' AND id_cn = '{1}'", zero, eight);
            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 1)
            {
                MessageBox.Show("Mã Nhân Viên Với Chi Nhánh Này Đã Tồn Tại!");
                return false;
            }
            else
            {
                try
                {
                    con.Open();
                    string query = string.Format("UPDATE nhanvien SET user_nv = '{0}',name_nv = '{1}',dateofbirth = '{2}',phone = '{3}',address = '{4}',cmnd = '{5}',sex = '{6}',pass_nv = '{7}',id_cn = '{8}',ma_nv = '{9}' WHERE id_nv = '{10}'", zero, one, two, three, four, five, six, seven, eight, nine, id);
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
            DialogResult rst = MessageBox.Show("Bạn Chắc Chắn Muốn Xóa Nhân Viên", "Thông Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (rst == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    string query = string.Format("DELETE FROM nhanvien WHERE id_nv = '{0}'", id);
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

        private void login_nv_btn_Click(object sender, EventArgs e)
        {
            string user = user_ql_text.Text.ToString();
            string pass = pass_ql_text.Text.ToString();
            string query = string.Format("SELECT * FROM quanli WHERE user_ql = N'{0}' AND pass_ql = '{1}'", user, pass);
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string name = dt.Rows[0]["name_ql"].ToString();
                user_ql_text.Tag = dt.Rows[0]["id_ql"].ToString();
                ma_ql_lb.Text = dt.Rows[0]["ma_ql"].ToString();
                ma_ql_lb_Changed();
                MessageBox.Show("Chào Quản Lí " + name);
                login_pnl.Visible = false;
            }
            else
            {
                error_lb.Visible = true;
            }
        }
        private void ma_ql_lb_Changed()
        {
            if (ma_ql_lb.Text != "")
            {
                Load_branch();
            }
        }

        private void Load_branch()
        {
            string query = string.Format("SELECT branch.*, quanli.ma_ql FROM branch INNER JOIN quanli ON branch.id_cn = quanli.id_cn WHERE quanli.ma_ql = '{0}'", ma_ql_lb.Text.ToString());
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dt.DefaultView.Sort = "id_cn ASC";
            dt = dt.DefaultView.ToTable();

            chinhanhQL_cbb.DisplayMember = "name_cn";
            chinhanhQL_cbb.ValueMember = "id_cn";
            chinhanhQL_cbb.DataSource = dt;

        }

        private void chinhanhQL_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = string.Format("SELECT * FROM branch WHERE name_cn = N'{0}'", chinhanhQL_cbb.Text.ToString());
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                DataRow x = dt.Rows[0];
                chinhanhQL_cbb.Tag = x["id_cn"].ToString();
                
            }      
           
            Load_nhanvien();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            ma_ql_lb.Text = "";
            user_ql_text.Text = "";
            pass_ql_text.Text = "";
            user_ql_text.Tag = null;
            chinhanhQL_cbb.DataSource = null;
            chinhanhQL_cbb.Tag = null;
            login_pnl.Visible = true;
        }

        private void chinhanhTK_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = string.Format("SELECT * FROM branch WHERE name_cn = N'{0}'", chinhanhTK_cbb.Text.ToString());
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow x = dt.Rows[0];
                chinhanhTK_cbb.Tag = x["id_cn"].ToString();
                
            }

        }
    }
}
