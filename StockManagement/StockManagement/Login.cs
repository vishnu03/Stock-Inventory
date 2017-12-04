using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TODO : CheckLogin   username and password 
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Stock;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM [dbo].[Login1] where UserName ='" + textBox1.Text + "' and Password ='" + textBox2.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    StockMain main = new StockMain();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username & password..!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    button1_Click(sender, e);
                }
        }
    }
}
