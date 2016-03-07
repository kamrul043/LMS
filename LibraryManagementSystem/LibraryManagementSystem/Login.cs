using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=lmsDB;Integrated Security=True");
        
        public Login()
        {
            InitializeComponent();
            textBox2.PasswordChar='*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Profile_Master Where Pro_User_Id='" + textBox1.Text + "' and Pro_Password= '" + textBox2.Text + "'", con.Activecon());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                LMS obj = new LMS();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid User Name or Password....!!", "Aleart", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
