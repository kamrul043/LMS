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

namespace LibraryManagementSystem
{
    public partial class Role : Form
    {
        public Role()
        {
            InitializeComponent();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            CreateNew();
            ViewGrid();
           
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            UpdateRecords();
            ViewGrid();

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            AddRecords();
            MessageBox.Show("Recorded Suceessfully....!!");
            CreateNew();
            ViewGrid();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DeleteRecords();
            ViewGrid();


        }
        void CreateNew()
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;

            Connection con = new Connection();
            SqlDataAdapter sda = new SqlDataAdapter("Proc_New_Role",con.Activecon());
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            textBox1.Text = dt.Rows[0][0].ToString();
            textBox2.Focus();

        }
        void AddRecords()
        {
            Connection con = new Connection();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [lmsDB].[dbo].[Role_Master]
           ([Role_Id]
           ,[Role]
           ,[Role_Status])
     VALUES
           ('"+textBox1.Text+"','"+textBox2.Text+"','"+comboBox1.Text+"')",con.Activecon());
            cmd.ExecuteNonQuery();
        }

        private void Role_Load(object sender, EventArgs e)
        {
            CreateNew();
            ViewGrid();
        }

        void ViewGrid()
        {
            Connection con = new Connection();
            SqlDataAdapter sda = new SqlDataAdapter("select * From Role_Master",con.Activecon());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = (n + 1).ToString();
                dataGridView1.Rows[n].Cells[1].Value=  item["Role_Id"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["Role"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["Role_Status"].ToString();
          }
            Row.Text="Row Count : " + dt.Rows.Count.ToString();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int n = dataGridView1.SelectedRows[0].Index;
            textBox1.Text = dataGridView1.Rows[n].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[n].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[n].Cells[3].Value.ToString();
        }
        void UpdateRecords()
        {
            Connection con = new Connection();
            SqlCommand cmd = new SqlCommand(@"UPDATE [lmsDB].[dbo].[Role_Master]
                                            SET [Role_Id] ='"+textBox1.Text+"',[Role] = '"+textBox2.Text+"',[Role_Status] = '"+comboBox1.Text+"'Where [Role_Id] ='"+textBox1.Text+"'", con.Activecon());
                                           cmd.ExecuteNonQuery();
        }
        void DeleteRecords()
        {
            Connection con = new Connection();
            SqlCommand cmd = new SqlCommand(@"Delete from [Role_Master]
                                            Where [Role_Id] ='" + textBox1.Text + "'", con.Activecon());
            cmd.ExecuteNonQuery();
        }
    }
}
