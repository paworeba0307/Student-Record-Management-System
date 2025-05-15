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

namespace Student_Record_Management_System
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "admin123")
            {
                this.Hide();
                Main_Menu_Form mainMenu = new Main_Menu_Form();
                mainMenu.Show();
            }
            else
            {
                MessageBox.Show("Invalid credentials. Please try again.");
            }
        }
    }
}
