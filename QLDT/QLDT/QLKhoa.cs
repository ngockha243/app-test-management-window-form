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
namespace QLDT
{
    public partial class QLKhoa : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=LAPTOP-L3ADQ9AS\MSSQLSERVER01;Initial Catalog=THI_TN;Persist Security Info=True;User ID=sa;Password=oneforall11";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from khoa";
            command.ExecuteNonQuery();
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataView.DataSource = table;

        }
        public QLKhoa(string id)
        {
            InitializeComponent();
            txtBasis.Text = id;
        }

        private void QLKhoa_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loadData();
        }
        
        private void dataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataView.CurrentRow.Index;
            txtID.Text = dataView.Rows[i].Cells[0].Value.ToString();
            txtName.Text = dataView.Rows[i].Cells[1].Value.ToString();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" & txtID.Text != "" & txtName.Text != "")
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into khoa (makh,tenkh,macs) values('" + txtID.Text + "',N'" + txtName.Text + "','" + txtBasis.Text + "')";
                command.ExecuteNonQuery();
                loadData();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }


        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from khoa where makh = '" + txtID.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update khoa set tenkh= N'" + txtName.Text + "',macs= '" + txtBasis.Text + "'where makh = '" + txtID.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            loadData();
        }

    }
}
