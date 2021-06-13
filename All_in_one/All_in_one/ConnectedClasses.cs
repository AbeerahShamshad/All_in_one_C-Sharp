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
    public partial class ConnectedClasses : Form
    {
        public ConnectedClasses()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var conn = new SqlConnection("Data Source=DESKTOP-VIJGOTF;Initial Catalog=Final;Integrated Security=True");

            try
            {
                var comm = new SqlCommand("Insert into ConnectedClass(Name,Email,Address,ProductName,Quantity) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + Convert.ToInt32(numericUpDown1.Value) + "')",conn);
                conn.Open();
                comm.ExecuteNonQuery();
                MessageBox.Show("Customer's Data Entered Successfully!! ");
                ListboxUpdate();
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

        private void button2_Click(object sender, EventArgs e)
        {
            var conn = new SqlConnection("Data Source=DESKTOP-VIJGOTF;Initial Catalog=Final;Integrated Security=True");
            var comm = new SqlCommand("Update ConnectedClass set Name='"+textBox1.Text+"',Email='"+textBox2.Text+"',Address='"+textBox3.Text+"',ProductName='"+comboBox1.Text+"',Quantity='"+Convert.ToInt32(numericUpDown1.Value)+"' where Name='"+listBox1.SelectedItem+"'",conn);
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
                ListboxUpdate();
                MessageBox.Show("Updated Successfully!!");
                numericUpDown1.Update();
                textBox1.Text = textBox2.Text = textBox3.Text = " ";
                comboBox1.Text = " ";
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

        private void ListboxUpdate()
        {
            listBox1.Items.Clear();
            var conn = new SqlConnection("Data Source=DESKTOP-VIJGOTF;Initial Catalog=Final;Integrated Security=True");
            var comm = new SqlCommand("Select * from ConnectedClass",conn);
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while(reader.Read())
                {
                    listBox1.Items.Add(reader["Name"]);
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
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            var conn = new SqlConnection("Data Source=DESKTOP-VIJGOTF;Initial Catalog=Final;Integrated Security=True");
            var comm = new SqlCommand("Select * from ConnectedClass where Name='" + listBox1.SelectedItem + "'", conn);
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader["Name"].ToString();
                    textBox2.Text = reader["Email"].ToString();
                    textBox3.Text = reader["Address"].ToString();
                    comboBox1.Text = reader["ProductName"].ToString();
                   numericUpDown1.Value =Convert.ToInt32( reader["Quantity"].ToString());
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

        private void ConnectedClasses_Load(object sender, EventArgs e)
        {
            ListboxUpdate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var conn = new SqlConnection("Data Source=DESKTOP-VIJGOTF;Initial Catalog=Final;Integrated Security=True");
            var comm = new SqlCommand("Delete from ConnectedClass where Name='"+listBox1.SelectedItem+"'",conn);
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();

                ListboxUpdate();
                MessageBox.Show("Deleted Successfully!!");
                numericUpDown1.Update();
                textBox1.Text = textBox2.Text = textBox3.Text = " ";
                comboBox1.Text = " ";
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
}
