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
                        if (Convert.ToInt32(x["amount"].ToString()) < 0)
                        {
                            x["amount"] = x["amount"].ToString().Replace("-", "");
                            sum_money += Convert.ToInt32(x["amount"]);
                        }
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

     
    }
}
