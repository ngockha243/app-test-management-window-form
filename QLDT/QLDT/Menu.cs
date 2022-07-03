using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDT
{
    public partial class Menu : Form
    {

        public Menu(string name, string auth, string basis)
        {
            InitializeComponent();
            txtName.Text = name;
            txtAuth.Text = auth;
            if (auth == "4")
            {
                btFaculty.Visible = false;
                btClass.Visible = false;
                btUser.Visible = false;
                btClass.Visible = false;
                btTest.Visible = false;

            }
            else if (auth == "5")
            {
                btManager.Visible = false;
                btPrint.Visible = false;
                btnReady.Visible = false;
            }
            else
            {
                btTest.Visible = false;
            }
            
            if (basis == "CS1")
            {
                loadDataServer(1);
            }
            else
            {
                loadDataServer(2);
            }
            txtName.Text = name;
            txtBasis.Text = basis;

        }

        public void loadDataServer(int id)
        {
            string str = @"Data Source=DESKTOP-4HAFPCF\SERVER" +id+";Initial Catalog=THI_TN;User ID=sa;Password=123";
        }

        private void customizeDesing()
        {
            SubpanelQLUser.Visible = false;
            SubpanelSystem.Visible = false;

        }

        private Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void hideSubMenu()
        {
            if (SubpanelQL.Visible == true)
            {
                SubpanelQL.Visible = false;
            }
            if (SubpanelSystem.Visible == true)
            {
                SubpanelSystem.Visible = false;
            }
            if (SubpanelQLUser.Visible == false)
            {
                SubpanelQLUser.Visible = false;
            }
            
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        

        
        #region Quan Ly User 
        private void btManager_Click(object sender, EventArgs e)
        {
            showSubMenu(SubpanelQL);
            SubpanelQLUser.Visible = false;

        }

        private void btUser_Click(object sender, EventArgs e)
        {
            showSubMenu(SubpanelQLUser);

        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            openChildForm(new QLSV(txtBasis.Text));
            
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            openChildForm(new QLGV(txtBasis.Text));
        }

        
        private void btHistory_Click(object sender, EventArgs e)
        {
            openChildForm(new LichSuThi(txtAuth.Text,txtName.Text));
        }
        #endregion

        #region System
        private void btSystem_Click(object sender, EventArgs e)
        {
            showSubMenu(SubpanelSystem);
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            openChildForm(new ChuanBiThi(txtBasis.Text, txtName.Text));
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            openChildForm(new LamBaiThi(txtBasis.Text, txtName.Text));
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            openChildForm(new InPhieuDiem(txtBasis.Text, txtName.Text));
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login lg = new Login();
                lg.Show();
                this.Hide();
            }
        }
        #endregion



        private void Menu_Load(object sender, EventArgs e)
        {
            hideSubMenu();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SubpanelQLUser_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btFaculty_Click(object sender, EventArgs e)
        {
            openChildForm(new QLKhoa(txtBasis.Text));
        }

        private void btClass_Click(object sender, EventArgs e)
        {
            openChildForm(new QLLop(txtBasis.Text));
        }

        private void btSubject_Click(object sender, EventArgs e)
        {
            openChildForm(new QLMonHoc(txtBasis.Text));
        }

        private void btQuestion_Click_1(object sender, EventArgs e)
        {
            openChildForm(new QLDeThi(txtBasis.Text, txtName.Text));
        }

        private void panelBotton_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
