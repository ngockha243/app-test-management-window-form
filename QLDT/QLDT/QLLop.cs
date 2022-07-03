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
    public partial class QLLop : Form
    {
        public QLLop(string id)
        {
            InitializeComponent();
            txtBasis.Text = id;

        }
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from lop ";
            command.ExecuteNonQuery();
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataView.DataSource = table;

        }

        private void QLLop_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(serverConnection.connectServer(txtBasis.Text));
            connection.Open();
            loadData();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" & txtID.Text != "" & txtName.Text != "" & txtBasis.Text != "")
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into lop (malop,tenlop,makh) values('" + txtID.Text + "',N'" + txtName.Text + "',N'" + txtBasis.Text + "')";
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
            command.CommandText = "delete from lop where malop = '" + txtID.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update lop set malop = '" + txtID.Text + "',tenlop= N'" + txtName.Text + "',makh= '" + txtBasis.Text +"' where malop= '" + txtID.Text +"'";
            command.ExecuteNonQuery();
            loadData();
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

        private void btReset_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            txtBasis.Text = "";
            command = connection.CreateCommand();
            command.CommandText = "select * from giaovien";
            command.ExecuteNonQuery();
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataView.DataSource = table;
            SetEditingMode(false);
        }

        private void dataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataView.CurrentRow.Index;
            txtID.Text = dataView.Rows[i].Cells[0].Value.ToString();
            txtName.Text = dataView.Rows[i].Cells[1].Value.ToString();
            txtBasis.Text = dataView.Rows[i].Cells[2].Value.ToString();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
