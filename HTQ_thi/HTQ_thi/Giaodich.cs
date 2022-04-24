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
    public partial class Giaodich : Form
    {
        public Giaodich()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=TANNGUYEN-LAPTO;Initial Catalog=bank;Integrated Security=True");

        private void Load_giaodich()
        {
            string query = String.Format("SELECT taikhoan.so_tk,taikhoan.name,giaodich.id_gd,giaodich.time, giaodich.loaigd,giaodich.amount,loaitk.name_ltk FROM giaodich INNER JOIN taikhoan ON taikhoan.id_tk = giaodich.id_tk INNER JOIN nhanvien ON giaodich.id_nv = nhanvien.id_nv INNER JOIN branch ON giaodich.id_cn = branch.id_cn INNER JOIN loaitk ON taikhoan.id_ltk = loaitk.id_ltk WHERE branch.id_cn = '{0}'", chinhanhGD_cbb.Tag);
            SqlDataAdapter da = new SqlDataAdapter(query, con);   
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["id_gd"].SetOrdinal(0);
            dt.Columns["so_tk"].SetOrdinal(1);
            dt.Columns["name"].SetOrdinal(2);
            dt.Columns["amount"].SetOrdinal(6);
            dt.Columns["name_ltk"].SetOrdinal(3);
            dt.Columns["time"].SetOrdinal(5);
            dt.Columns["loaigd"].SetOrdinal(4);

            change_typeofdata_loaigd(dt);
            dt.DefaultView.Sort = "id_gd ASC";
            dt = dt.DefaultView.ToTable();
            dt.Columns["id_gd"].ColumnName = "Mã Giao Dịch";
            dt.Columns["so_tk"].ColumnName = "Số Tài Khoản";
            dt.Columns["name"].ColumnName = "Tên";
            dt.Columns["amount"].ColumnName = "Biến Động Số Dư";
            dt.Columns["name_ltk"].ColumnName = "Loại Tài Khoản";
            dt.Columns["time"].ColumnName = "Thời Gian";
            dt.Columns["loaigd"].ColumnName = "Loại Giao Dịch";
          

            dgvgiaodich.DataSource = dt;
            dgvgiaodich.Refresh();
            
        }
        private void Load_branch()
        {
            string query = string.Format("SELECT branch.*, nhanvien.ma_nv FROM branch INNER JOIN nhanvien ON branch.id_cn = nhanvien.id_cn WHERE nhanvien.ma_nv = '{0}'", ma_nv_lb.Text.ToString());
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dt.DefaultView.Sort = "id_cn ASC";
            dt = dt.DefaultView.ToTable();

            chinhanhGD_cbb.DisplayMember = "name_cn";
            chinhanhGD_cbb.ValueMember = "id_cn";
            chinhanhGD_cbb.DataSource = dt;     

        }
        private void Load_loaiTK()
        {
            string query = string.Format("SELECT * FROM loaitk");
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.DefaultView.Sort = "id_ltk ASC";
            dt = dt.DefaultView.ToTable();
            loaitk_cbb.DisplayMember = "name_ltk";
            loaitk_cbb.ValueMember = "id_ltk";
            loaitk_cbb.DataSource = dt;
            loaitk_cbb.Text = "";
        }
        private void change_typeofdata_loaigd(DataTable dt)
        {
            foreach(DataRow x in dt.Rows)
            {              
                if (Convert.ToInt32(x["loaigd"]) == 0)
                {
                    x["loaigd"] = "Rút Tiền";
                }
                else if (Convert.ToInt32(x["loaigd"]) == 1) 
                {
                    x["loaigd"] = "Nạp Tiền";
                }
            }
        }
        private void Giaodich_Load(object sender, EventArgs e)
        {
            sotk_text.Focus();
            Load_giaodich();
            Load_loaiTK();
        }

        private void sotk_text_MouseLeave(object sender, EventArgs e)
        {
            if (sotk_text.Text != "")
            {
                string query = string.Format("SELECT * FROM taikhoan WHERE so_tk = '{0}'", sotk_text.Text.ToString());
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Số Tài Khoản Không Hợp Lệ!");
                    sotk_text.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Số Tài Khoản Hợp Lệ!");
            }
        }

        private void cbloaigd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sotk_text.Text !="")
            {
                string query = string.Format("SELECT taikhoan.*,branch.name_cn,loaitk.name_ltk FROM taikhoan INNER JOIN branch ON taikhoan.id_cn = branch.id_cn INNER JOIN loaitk ON taikhoan.id_ltk = loaitk.id_ltk WHERE so_tk = '{0}' AND taikhoan.id_ltk = '{1}'", sotk_text.Text.ToString(), loaitk_cbb.SelectedIndex.ToString());
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow x = dt.Rows[0];

                    name_text.Text = x["name"].ToString();
                    ngaysinh_text.Text = Convert.ToDateTime(x["dateofbirth"]).ToString("dd/MM/yyyy");
                    sdt_text.Text = x["phone"].ToString();
                    diachi_text.Text = x["address"].ToString();
                    cmnd_text.Text = x["cmnd"].ToString();
                    gioitinh_text.Text = x["sex"].ToString();
                    ngaycap_text.Text = Convert.ToDateTime(x["ngaycap"]).ToString("dd/MM/yyyy");
                    chinhanhTK_text.Text = x["name_cn"].ToString();
                    sodu_text.Text = String.Format("{0:#,0.#} VNĐ", Convert.ToInt32(x["sodu"]));

                    sotk_text.Tag = x["id_tk"].ToString();
                }
                else
                {
                    name_text.Text = "";
                    ngaysinh_text.Text = "";
                    sdt_text.Text = "";
                    diachi_text.Text = "";
                    cmnd_text.Text = "";
                    gioitinh_text.Text = "";
                    ngaycap_text.Text = "";
                    chinhanhTK_text.Text = "";
                    sodu_text.Text = "";

                    sotk_text.Tag = null;
                }
                
            }
            
           
        }

        private bool update_money(int id, int type)
        {
            int money = Convert.ToInt32(sotien_text.Text.ToString());
            string select = string.Format("SELECT * FROM taikhoan WHERE id_tk = '{0}'", id);
            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int sodu = Convert.ToInt32(dt.Rows[0]["sodu"]);
            
            if (type == 1)
            {
                sodu += money;             
            }
            if (type == 0)
            {
                if(sodu<money)
                {
                    MessageBox.Show("Số Dư Không Đủ!");
                    return false;
                }
                else
                {
                    sodu -= money;
                    money = -money;
                }          
            }
            try
            {
                con.Open();
                string query = string.Format("UPDATE taikhoan SET sodu = '{0}' WHERE id_tk = '{1}'", sodu, id);
                SqlCommand cmd_up = new SqlCommand(query, con);
                if (cmd_up.ExecuteNonQuery() == 1)
                {
                    con.Close();
                    try
                    {
                        con.Open();
                        int idTK = Convert.ToInt32(sotk_text.Tag);
                        int idNV = Convert.ToInt32(user_nv_text.Tag);
                        int idCN = Convert.ToInt32(chinhanhGD_cbb.Tag);
                        DateTime time = DateTime.Now;              // Use current time
                        string format = "yyyy-MM-dd HH:mm:ss";    // modify the format depending upon input required in the column in database 
                        string insert = string.Format("INSERT INTO giaodich(id_tk,id_nv,id_cn,time,amount,loaigd) values('{0}','{1}','{2}','{3}','{4}','{5}') ", idTK, idNV, idCN, time.ToString(format), money, type.ToString());
                        SqlCommand cmd_is = new SqlCommand(insert, con);
                        if (cmd_is.ExecuteNonQuery() == 1)
                        {
                            Load_giaodich();
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
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }
            return false;
        }
        private void naptien_btn_Click(object sender, EventArgs e)
        {
            if (sotk_text.Tag != null && sotien_text.Text!=null) 
            {
                bool naptien = update_money(Convert.ToInt32(sotk_text.Tag), 1);
                if (naptien)
                {
                    MessageBox.Show("Nạp Tiền Thành Công");
                    cbloaigd_SelectedIndexChanged(sender, e);
                }
                else
                {
                    MessageBox.Show("Nạp Tiền Không thành công\nVui Lòng Thử Lại!");
                }           
            }
            else
            {
                MessageBox.Show("Không Tìm Thấy Thông Tin Tài Khoản!");
            }
            
        }

        private void ruttien_btn_Click(object sender, EventArgs e)
        {
            if (sotk_text.Tag != null && sotien_text.Text != null)
            {
                bool ruttien = update_money(Convert.ToInt32(sotk_text.Tag), 0);
                if (ruttien)
                {
                    MessageBox.Show("Rút Tiền Thành Công");
                    cbloaigd_SelectedIndexChanged(sender, e);
                }
                else
                {
                    MessageBox.Show("Rút Tiền Không thành công\nVui Lòng Thử Lại");
                }
           
            }
            else
            {
                MessageBox.Show("Không Tìm Thấy Thông Tin Tài Khoản!");
            }

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
                ma_nv_lb_Changed();
                MessageBox.Show("Chào Mừng Nhân Viên " + name);

                login_pnl.Visible = false;
                error_lb.Visible = false;
            }
            else
            {
                error_lb.Visible = true;
            }
        }

        private void ma_nv_lb_Changed()
        {
            if(ma_nv_lb.Text !="")
            {
                Load_branch();
            }
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            ma_nv_lb.Text = "";
            user_nv_text.Text = "";
            pass_nv_text.Text = "";
            user_nv_text.Tag = null;
            login_pnl.Visible = true;
        }

        private void chinhanhGD_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = string.Format("SELECT * FROM branch WHERE name_cn = N'{0}'", chinhanhGD_cbb.SelectedItem.ToString());
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow x = dt.Rows[0];
                chinhanhGD_cbb.Tag = x["id_cn"].ToString();
            }

 
            Load_giaodich();
        }
    }
}
