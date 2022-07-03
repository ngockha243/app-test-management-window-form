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
using QLDT;

namespace QLDT
{
    public partial class QLSV : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public QLSV(string basis)
        {
            InitializeComponent();
            txtBasis.Text = basis;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from sinhvien";
            command.ExecuteNonQuery();
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataView.DataSource = table;
        }

        private void QLSV_Load(object sender, EventArgs e)
        {
            //truyen data basis de ket noi server tuong ung
            connection = new SqlConnection(serverConnection.connectServer(txtBasis.Text));
            connection.Open();
            loadData();
        }

        

        private void btAdd_Click(object sender, EventArgs e)
        {
            DateTime t = new DateTime(2010,1,1);
            if (txtDate.Value.CompareTo(t) == 1)
            {
                MessageBox.Show("Bạn vui lòng nhập ngày sinh đúng");
            }
            else if(txtID.Text != "" & txtHo.Text != "" & txtTen.Text != "" & txtClass.Text != "" & txtAddress.Text != "")
            {
                string date = txtDate.Value.ToString("yyyy/MM/dd hh:mm:ss");
                command = connection.CreateCommand();
                command.CommandText = "insert into sinhvien (masv,ho,ten,ngaysinh,diachi,malop) values('" + txtID.Text + "',N'" + txtHo.Text + "',N'" + txtTen.Text + "','" + date + "',N'" + txtAddress.Text + "','" + txtClass.Text + "')";
                //command.CommandText = "insert into giaovien (magv,ho,ten,hocvi,makh) values('" + txtID.Text + "',N'" + txtHo.Text + "',N'" + txtTen.Text + "',N'" + txtDegree.Text + "','" + txtFaculty.Text + "')";

                command.ExecuteNonQuery();
                loadData();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            
        }

        private void dataView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataView.CurrentRow.Index;
            txtID.Text = dataView.Rows[i].Cells[0].Value.ToString();
            txtHo.Text = dataView.Rows[i].Cells[1].Value.ToString();
            txtTen.Text = dataView.Rows[i].Cells[2].Value.ToString();
            txtDate.Text = dataView.Rows[i].Cells[3].Value.ToString();
            txtAddress.Text = dataView.Rows[i].Cells[4].Value.ToString();
            txtClass.Text = dataView.Rows[i].Cells[5].Value.ToString();
            SetEditingMode(true);
        }
        private void SetEditingMode(bool enable)
        {
            if (!enable)
            {
                dataView.ClearSelection();
            }
            btAdd.Enabled = !enable;
            btReset.Enabled = true;
            btDelete.Enabled = enable;
            btEdit.Enabled = enable;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from sinhvien where masv = '" + txtID.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            string date = txtDate.Value.ToString("yyyy/MM/dd hh:mm:ss");
            command.CommandText = "update sinhvien set ho = N'" + txtHo.Text + "',ten= N'" + txtTen.Text + "',ngaysinh= '" + date + "',diachi='" + txtAddress.Text + "',malop='" + txtClass.Text + "' where masv ='" + txtID.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtHo.Text = "";
            txtTen.Text = "";
            txtDate.Text = "";
            txtAddress.Text = "";
            txtClass.Text = "";
            loadData();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            
                command = connection.CreateCommand();
                command.CommandText = "select * from sinhvien where masv='" + txtSearchID.Text + "'";
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dataView.DataSource = table;
        }
    }
}
