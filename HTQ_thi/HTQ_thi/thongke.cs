using MySql.Data.MySqlClient;
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

namespace HTQ_thi
{
    public partial class thongke : Form
    {
        public thongke()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=TANNGUYEN-LAPTO;Initial Catalog=bank;Integrated Security=True");

        private void Load_nhanvien()
        {
            string query = string.Format("SELECT ma_nv, name_nv,id_gd,giaodich.time, amount,loaigd FROM giaodich INNER JOIN nhanvien ON giaodich.id_nv = nhanvien.id_nv  WHERE giaodich.id_cn = '{0}' AND month(giaodich.time) = month(CURRENT_TIMESTAMP) AND year(giaodich.time) = year(CURRENT_TIMESTAMP)", chinhanhQL_cbb.Tag);
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow x in dt.Rows)
            {
                if (Convert.ToInt32(x["amount"].ToString()) < 0)
                {
                    x["amount"] = x["amount"].ToString().Replace("-", "");
                }
            }

            dt.DefaultView.Sort = "amount DESC";
            dt = dt.DefaultView.ToTable();
           
            dt.Columns["ma_nv"].ColumnName = "Mã Nhân Viên";
            dt.Columns["name_nv"].ColumnName = "Tên";
            dt.Columns["id_gd"].ColumnName = "Mã Giao Dịch";
            dt.Columns["time"].ColumnName = "Thời Gian";
            dt.Columns["amount"].ColumnName = "Số Tiền";
            dt.Columns["loaigd"].ColumnName = "Loại Giao Dịch";


            dgvdoanhso.DataSource = dt;
            dgvdoanhso.ClearSelection();
            dgvdoanhso.Refresh();

        }
        private void key_search_text_KeyDown(object sender, KeyEventArgs e)
        {
            dgvdoanhso.DataSource = null;
            if (e.KeyCode == Keys.Enter)
            {
                if (key_search_text.Text.Trim() != "")
                {
                    string key = key_search_text.Text.ToString().Trim();
                    string query = string.Format("SELECT ma_nv, name_nv,id_gd,giaodich.time, amount,loaigd FROM giaodich INNER JOIN nhanvien ON giaodich.id_nv = nhanvien.id_nv WHERE (ma_nv LIKE '%" + key + "%' OR name_nv LIKE '%" + key + "%') AND giaodich.id_cn = '{0}' AND month(giaodich.time) = month(CURRENT_TIMESTAMP) AND year(giaodich.time) = year(CURRENT_TIMESTAMP) ", chinhanhQL_cbb.Tag);
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dt.DefaultView.Sort = "amount DESC";
                    dt = dt.DefaultView.ToTable();

                    dt.Columns["ma_nv"].ColumnName = "Mã Nhân Viên";
                    dt.Columns["name_nv"].ColumnName = "Tên";
                    dt.Columns["id_gd"].ColumnName = "Mã Giao Dịch";
                    dt.Columns["time"].ColumnName = "Thời Gian";
                    dt.Columns["amount"].ColumnName = "Số Tiền";
                    dt.Columns["loaigd"].ColumnName = "Loại Giao Dịch";


                    
                    dgvdoanhso.DataSource = dt;
                    dgvdoanhso.ClearSelection();
                    dgvdoanhso.Refresh();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập vào ô tìm kiếm!");
                }

            }
        }

        private void login_nv_btn_Click(object sender, EventArgs e)
        {
            string user = user_ql_text.Text.ToString();
            string pass = pass_ql_text.Text.ToString();
            string query = string.Format("SELECT * FROM quanli WHERE user_ql = '{0}' AND pass_ql = '{1}'", user, pass);
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
            if (dt.Rows.Count > 0)
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
            chinhanhQL_cbb.Tag = null;
            login_pnl.Visible = true;
        }

        private void key_search_text_Click(object sender, EventArgs e)
        {
            key_search_text.Text = "";
        }

        private void dgvdoanhso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sum_gd.Text = "";
            sum_gt.Text = "";
            int i = e.RowIndex;
            if (i >= 0 && i < dgvdoanhso.Rows.Count)
            {
                string maNV = dgvdoanhso.Rows[i].Cells[0].Value.ToString();
                if (maNV != "")
                {
                    string query = string.Format("SELECT ma_nv, name_nv,id_gd,giaodich.time, amount,loaigd FROM giaodich INNER JOIN nhanvien ON giaodich.id_nv = nhanvien.id_nv  WHERE giaodich.id_cn = '{0}' AND ma_nv = '{1}' AND month(giaodich.time) = month(CURRENT_TIMESTAMP) AND year(giaodich.time) = year(CURRENT_TIMESTAMP)", chinhanhQL_cbb.Tag, maNV);
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    ma_nv_lb.Text = dt.Rows[0]["ma_nv"].ToString();
                    int sum_money = 0;

                    foreach (DataRow x in dt.Rows)
                    {
                        x["amount"] = x["amount"].ToString().Replace("-", "");
                        sum_money += Convert.ToInt32(x["amount"]);

                    }

                    int s = dt.Rows.Count;
                    sum_gd.Text = s.ToString();
                    string money = sum_money.ToString();
                    sum_gt.Text = String.Format("{0:#,0.#} VNĐ", Convert.ToInt32(money));


                    dt.DefaultView.Sort = "amount DESC";
                    dt = dt.DefaultView.ToTable();

                    dt.Columns["ma_nv"].ColumnName = "Mã Nhân Viên";
                    dt.Columns["name_nv"].ColumnName = "Tên Nhân Viên";
                    dt.Columns["id_gd"].ColumnName = "Mã Giao Dịch";    
                    dt.Columns["time"].ColumnName = "Thời Gian";
                    dt.Columns["amount"].ColumnName = "Số Tiến Giao Dịch";
                    dt.Columns["loaigd"].ColumnName = "Loại Giao Dịch";

                    dgvnhanvien.DataSource = dt;
                    dgvnhanvien.ClearSelection();
                    dgvnhanvien.Refresh();

                    
                }
            }

        }
/// <summary>
/// //////
/// </summary>

        private void quảnLíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quanli_pnl.Visible = true;
            quảnLíToolStripMenuItem.BackColor = Color.LightPink;
            nhanvien_pnl.Visible = false;
            nhânViênToolStripMenuItem.BackColor = Color.White;
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quanli_pnl.Visible = false;
            nhanvien_pnl.Visible = true;
            nhânViênToolStripMenuItem.BackColor = Color.LightPink;
            quảnLíToolStripMenuItem.BackColor = Color.White;
        }
        private void Load_taikhoan()
        {
            string maNV = ma_nv_lb1.Text.ToString();
            if(maNV != "")
            {
                string query1 = string.Format("SELECT so_tk, name,id_gd,time, amount,loaigd FROM giaodich INNER JOIN nhanvien ON giaodich.id_nv = nhanvien.id_nv INNER JOIN taikhoan ON giaodich.id_tk = taikhoan.id_tk WHERE giaodich.id_cn = '{0}' AND ma_nv = '{1}' AND day(giaodich.time) = day(CURRENT_TIMESTAMP) AND month(giaodich.time) = month(CURRENT_TIMESTAMP) AND year(giaodich.time) = year(CURRENT_TIMESTAMP)", chinhanhNV_cbb.Tag, maNV);
                SqlDataAdapter da1 = new SqlDataAdapter(query1, con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);

                foreach (DataRow x in dt1.Rows)
                {
                    if (Convert.ToInt32(x["amount"].ToString()) < 0)
                    {
                        x["amount"] = x["amount"].ToString().Replace("-", "");
                    }
                }

                SUM_taikhoan(dt1);
                dt1.DefaultView.Sort = "amount DESC";
                dt1 = dt1.DefaultView.ToTable();

                dt1.Columns["so_tk"].ColumnName = "Số Tài Khoản";
                dt1.Columns["name"].ColumnName = "Tên Khách Hàng";
                dt1.Columns["id_gd"].ColumnName = "Mã Giao Dịch";
                dt1.Columns["time"].ColumnName = "Thời Gian";
                dt1.Columns["amount"].ColumnName = "Số Tiền";
                dt1.Columns["loaigd"].ColumnName = "Loại Giao Dịch";


                dgvtaikhoan.DataSource = dt1;
                dgvtaikhoan.ClearSelection();
                dgvtaikhoan.Refresh();

            }
            
        }
        private void login_nv_btn_Click_1(object sender, EventArgs e)
        {
            string user = user_nv_text.Text.ToString();
            string pass = pass_nv_text.Text.ToString();
            string query = string.Format("SELECT * FROM nhanvien WHERE user_nv = '{0}' AND pass_nv = '{1}'", user, pass);
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string name = dt.Rows[0]["name_nv"].ToString();
                user_nv_text.Tag = dt.Rows[0]["id_nv"].ToString();
                ma_nv_lb1.Text = dt.Rows[0]["ma_nv"].ToString();
                ma_nv_lb1_Changed();
                MessageBox.Show("Chào Nhân Viên " + name);
                login_nv_pnl.Visible = false;
                error_lb1.Visible = false;
            }
            else
            {
                error_lb1.Visible = true;
            }
        }

        private void ma_nv_lb1_Changed()
        {
            if (ma_nv_lb1.Text != "")
            {
                Load_branch_nv();
            }
        }

        private void Load_branch_nv()
        {
            string query = string.Format("SELECT branch.* FROM branch INNER JOIN nhanvien ON branch.id_cn = nhanvien.id_cn WHERE ma_nv = '{0}'", ma_nv_lb1.Text.ToString());
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dt.DefaultView.Sort = "id_cn ASC";
            dt = dt.DefaultView.ToTable();


            chinhanhNV_cbb.DisplayMember = "name_cn";
            chinhanhNV_cbb.ValueMember = "id_cn";
            chinhanhNV_cbb.DataSource = dt;

        }
        private void logout_nv_Click(object sender, EventArgs e)
        {
            ma_nv_lb1.Text = "";
            user_nv_text.Text = "";
            pass_nv_text.Text = "";
            user_nv_text.Tag = null;
            chinhanhNV_cbb.Tag = null;
            login_nv_pnl.Visible = true;
        }

        private void key_search_nv_Click(object sender, EventArgs e)
        {
            key_search_nv.Text = "";
        }

        private void key_search_nv_KeyDown(object sender, KeyEventArgs e)
        {
            dgvdoanhso.DataSource = null;
            if (e.KeyCode == Keys.Enter)
            {
                if (key_search_text.Text.Trim() != "")
                {
                    string key = key_search_text.Text.ToString().Trim();
                    string maNV = ma_nv_lb1.Text;
                    string query = string.Format("SELECT so_tk, name, id_gd, time, amount, loaigd FROM giaodich INNER JOIN nhanvien ON giaodich.id_nv = nhanvien.id_nv INNER JOIN taikhoan ON giaodich.id_tk = taikhoan.id_tk WHERE giaodich.id_cn = '{0}' AND ma_nv = '{1}' AND (so_tk LIKE '%" + key + "%' OR name LIKE '%" + key + "%') AND day(giaodich.time) = day(CURRENT_TIMESTAMP) AND month(giaodich.time) = month(CURRENT_TIMESTAMP) AND year(giaodich.time) = year(CURRENT_TIMESTAMP)", chinhanhNV_cbb.Tag, maNV);
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dt.DefaultView.Sort = "amount DESC";
                    dt = dt.DefaultView.ToTable();

                    dt.Columns["so_tk"].ColumnName = "Số Tài Khoản";
                    dt.Columns["name"].ColumnName = "Tên Khách Hàng";
                    dt.Columns["id_gd"].ColumnName = "Mã Giao Dịch";
                    dt.Columns["time"].ColumnName = "Thời Gian";
                    dt.Columns["amount"].ColumnName = "Số Tiền";
                    dt.Columns["loaigd"].ColumnName = "Loại Giao Dịch";



                    dgvtaikhoan.DataSource = dt;
                    dgvtaikhoan.ClearSelection();
                    dgvtaikhoan.Refresh();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập vào ô tìm kiếm!");
                }

            }
        }

        private void chinhanhNV_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = string.Format("SELECT * FROM branch WHERE name_cn = N'{0}'", chinhanhNV_cbb.Text.ToString());
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow x = dt.Rows[0];
                chinhanhNV_cbb.Tag = x["id_cn"].ToString();

            }

            Load_taikhoan();
        }

        private void SUM_taikhoan(DataTable dt)
        {
            num_gd_nv.Text = "";
            num_gt_nv.Text = "";
            int sum_money = 0;
            foreach(DataRow x in dt.Rows)
            {
                x["amount"] = x["amount"].ToString().Replace("-", "");
                sum_money += Convert.ToInt32(x["amount"]);
            }

            int s = dt.Rows.Count;
            num_gd_nv.Text = s.ToString();
            string money = sum_money.ToString();
            num_gt_nv.Text = String.Format("{0:#,0.#} VNĐ", Convert.ToInt32(money));
        }
     
    }
}
