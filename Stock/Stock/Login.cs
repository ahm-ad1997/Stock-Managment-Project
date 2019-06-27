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

namespace Stock
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            //TO-DO: check login username and password.
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-48FCVKS;Initial Catalog=Stock;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT *
            FROM[dbo].[Login] where Username = '"+ textBox1.Text +"' and Password = '"+textBox2.Text +"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            
            if(dt.Rows.Count == 1)
            {
                this.Hide();
                StockMain main = new StockMain();
                main.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username & Password..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearbutton_Click(sender, e);
            }
            
        }
    }
}
