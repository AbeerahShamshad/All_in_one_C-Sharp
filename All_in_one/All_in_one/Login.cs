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

namespace All_in_one
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (textBox1.Text == " ")
            {
                errorProvider1.SetError(textBox1, "Username is Missing!!");
            }
            else if(textBox2.Text==" ")
            {
                errorProvider1.SetError(textBox2,"Password is Missing!!");
            }
            else
            {
                var conn = new SqlConnection("Data Source=DESKTOP-VIJGOTF;Initial Catalog=Final;Integrated Security=True");
                try
                {
                    var comm = new SqlCommand("Select Name,Password from LoginInfo where Name='"+textBox1.Text+"' and Password='"+textBox2.Text+"'",conn);
                    conn.Open();
                    SqlDataReader reader = comm.ExecuteReader();
                    textBox1.Text = textBox2.Text = " ";
                    int check = 0;
                    while (reader.Read())
                    {
                        check += 1;
                    }
                    if (check == 1)
                    {
                        MessageBox.Show("Login successfully");
                        Services s = new Services();
                        s.Show();
                        
                    }
                    else if (check > 1)
                    {
                        MessageBox.Show("Dublicate");
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Username & Password");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
           
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp s = new SignUp();
            s.Show();
        }
    }
}
