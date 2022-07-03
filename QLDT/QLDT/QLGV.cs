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
using QLDT;     //goi file serverConnection
namespace QLDT
{
    
    public partial class QLGV : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        
        public QLGV(string basis)
        {
            InitializeComponent();
            txtBasis.Text = basis;
        }
        
        void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from giaovien";
            command.ExecuteNonQuery();
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataView.DataSource = table;

        }
        
        private void QLGV_Load(object sender, EventArgs e)
        {
            //truyen data basis de ket noi server tuong ung
            connection = new SqlConnection(serverConnection.connectServer(txtBasis.Text));  
            connection.Open();
            loadData();
            //string strCmd = "select makh,tenkh from khoa";
            //SqlCommand cmd = new SqlCommand(strCmd, connection);

            //SqlDataReader reader = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Columns.Add("makh", typeof(string));
            //dt.Load(reader);

            //comboMaKH.ValueMember = "customerid";
            //comboMaKH.DisplayMember = "contactname";
            //comboMaKH.DataSource = dt;

            //SqlDataAdapter da = new SqlDataAdapter(strCmd, connection);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //cmd.ExecuteNonQuery();
            ////connection.Close();

            //comboMaKH.DisplayMember = "tenkh";
            //comboMaKH.ValueMember = "makh";
            //comboMaKH.DataSource = ds.Tables[0];

            //comboMaKH.Enabled = true;
        }

        private void dataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataView.CurrentRow.Index;
            txtID.Text = dataView.Rows[i].Cells[0].Value.ToString();
            txtHo.Text = dataView.Rows[i].Cells[1].Value.ToString();
            txtTen.Text = dataView.Rows[i].Cells[2].Value.ToString();
            txtDegree.Text = dataView.Rows[i].Cells[3].Value.ToString();
            txtFaculty.Text = dataView.Rows[i].Cells[4].Value.ToString();

            

            SetEditingMode(true);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" & txtHo.Text != "" & txtTen.Text != "" & txtDegree.Text != "" & txtFaculty.Text != "")
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into giaovien (magv,ho,ten,hocvi,makh) values('" + txtID.Text + "',N'" + txtHo.Text + "',N'" + txtTen.Text + "',N'" + txtDegree.Text + "','" + txtFaculty.Text + "')";
                command.ExecuteNonQuery();
                btAdd.Enabled = true;
                loadData();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            

        }

        private void txtDegree_TextChanged(object sender, EventArgs e)
        {

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from giaovien where magv = '" + txtID.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update giaovien set ho = N'" + txtHo.Text + "',ten= N'" + txtTen.Text + "',hocvi= N'" + txtDegree.Text + "',makh='" + txtFaculty.Text + "' where magv ='" + txtID.Text + "'" ;
            command.ExecuteNonQuery();
            loadData();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtHo.Text = "";
            txtTen.Text = "";
            txtDegree.Text = "";
            txtFaculty.Text = "";
            loadData();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from giaovien where magv='" + txtSearchID.Text +"'";
            command.ExecuteNonQuery();
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataView.DataSource = table;
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

        

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
