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
    public partial class DisconnectedClasses : Form
    {
        public DisconnectedClasses()
        {
            InitializeComponent();
        }

      
        private void DisconnectedClasses_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'finalDataSet1.DisconnectedClass' table. You can move, or remove it, as needed.
            this.disconnectedClassTableAdapter.Fill(this.finalDataSet1.DisconnectedClass);
            RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-VIJGOTF;Initial Catalog=Final;Integrated Security=True");
                DataSet ds = new DataSet();
                SqlDataAdapter adpt = new SqlDataAdapter("Select * from DisconnectedClass", conn);

                adpt.Fill(ds, "DisconnectedClass");
                dataGridView1.DataSource = ds.Tables["DisconnectedClass"];

                listBox1.DataSource = ds.Tables["DisconnectedClass"];
                listBox1.ValueMember = "id";
                listBox1.DisplayMember = "CName";

                comboBox3.DataSource = ds.Tables["DisconnectedClass"];
                comboBox3.ValueMember = "id";
                comboBox3.DisplayMember = "CName";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-VIJGOTF;Initial Catalog=Final;Integrated Security=True");
            DataSet ds = new DataSet();
            SqlDataAdapter adpt = new SqlDataAdapter("Select * from DisconnectedClass", conn);
            adpt.Fill(ds, "DisconnectedClass");

            DataRow dr = ds.Tables["DisconnectedClass"].NewRow();
            dr["CName"]= textBox1.Text;
            dr["PType"]= comboBox1.Text;

            dr["OrderedDate"]= dateTimePicker1.Value;

            ds.Tables["DisconnectedClass"].Rows.Add(dr);

            SqlCommandBuilder build = new SqlCommandBuilder(adpt);
            adpt.Update(ds,"DisconnectedClass");

            textBox1.Text = comboBox1.Text = " ";
            dateTimePicker1.Value = DateTime.Now;
            MessageBox.Show("Data Added Successfully!!");
            RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var conn = new SqlConnection("Data Source=DESKTOP-VIJGOTF;Initial Catalog=Final;Integrated Security=True");
            DataSet ds = new DataSet();
            SqlDataAdapter adpt = new SqlDataAdapter("Selec" +
                "" +
                "t * from DisconnectedClass where id='"+listBox1.SelectedItem+"'",conn);
            adpt.Fill(ds,"DisconnectedClass");
            foreach (DataRow dr in ds.Tables["DisconnectedClass"].Rows)
            {
                dr["CName"] = textBox2.Text;
                dr["PType"] = comboBox2.Text;

                dr["OrderedDate"] = dateTimePicker2.Value;

                SqlCommandBuilder build = new SqlCommandBuilder(adpt);
                adpt.Update(ds,"DisconnectedClass");
                textBox2.Text = comboBox2.Text = " ";
                dateTimePicker2.Value = DateTime.Now;

                RefreshData();
                MessageBox.Show("Data Updated Successfully!!");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try { 
            if (MessageBox.Show("Are you Sure?","Confirm",MessageBoxButtons.OKCancel)==DialogResult.OK)
                {
                    var conn = new SqlConnection("Data Source=DESKTOP-VIJGOTF;Initial Catalog=Final;Integrated Security=True");
                    DataSet ds = new DataSet();
                    SqlDataAdapter adpt = new SqlDataAdapter("Select * from DisconnectedClass where id='"+comboBox3.SelectedValue+"'",conn);
                    adpt.Fill(ds,"DisconnectedClass");

                   foreach(DataRow dr in ds.Tables["DisconnectedClass"].Rows)
                    {
                        dr.Delete();
                    }
                    SqlCommandBuilder build = new SqlCommandBuilder(adpt);
                    adpt.Update(ds,"DisconnectedClass");

                    RefreshData();
                    MessageBox.Show("Data Deleted Successfully!!");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var conn = new SqlConnection("Data Source=DESKTOP-VIJGOTF;Initial Catalog=Final;Integrated Security=True");
                DataSet ds = new DataSet();
                SqlDataAdapter adpt = new SqlDataAdapter("Select * from DisconnectedClass where id ='" + listBox1.SelectedItem + "'", conn);
                adpt.Fill(ds, "DisconnectedClass");
                foreach (DataRow dr in ds.Tables["DisconnectedClass"].Rows)
                {
                    textBox2.Text = dr["CName"].ToString();
                    comboBox2.Text = dr["PType"].ToString();

                    dateTimePicker2.Value = Convert.ToDateTime(dr["OrderedDate"]);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
