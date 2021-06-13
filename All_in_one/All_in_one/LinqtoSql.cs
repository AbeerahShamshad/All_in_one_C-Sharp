using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace All_in_one
{
    public partial class LinqtoSql : Form
    {
        public LinqtoSql()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void btninsert_Click(object sender, EventArgs e)
        {
            var l2 = new linq_2
            {
                CustomerName = textBox1.Text,
                ProductName = comboBox1.Text,
                OrderedDate = dateTimePicker1.Value
            };

            db.linq_2s.InsertOnSubmit(l2);
            db.SubmitChanges();
            MessageBox.Show("Data Added Successfully!!");
            RefreshData();
            textBox1.Text = " ";
            comboBox1.Text = " ";
            dateTimePicker1.Value = DateTime.Now;

        }
        void RefreshData()
        {
            var emp = from s in db.linq_2s select s;
            dataGridView1.DataSource = emp;
        }
            private void LinqtoSql_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'finalDataSet.linq_2' table. You can move, or remove it, as needed.
            this.linq_2TableAdapter.Fill(this.finalDataSet.linq_2);

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                var l2 = (from s in db.linq_2s where s.CustomerName==textBox1.Text select s).First();
                textBox1.Text = l2.CustomerName;
                comboBox1.Text = l2.ProductName;
                dateTimePicker1.Value = l2.OrderedDate;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            var l2 = (from s in db.linq_2s where s.CustomerName==textBox1.Text select s).First();
            l2.CustomerName = textBox1.Text;
            l2.ProductName = comboBox1.Text;
            l2.OrderedDate = dateTimePicker1.Value;
            db.SubmitChanges();
            MessageBox.Show("Updated Succesffully!!");
            RefreshData();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            var l2 = (from s in db.linq_2s where s.CustomerName==textBox1.Text select s);
            db.linq_2s.DeleteAllOnSubmit(l2);
            db.SubmitChanges();
            MessageBox.Show("Deleted Successfully!!");
            RefreshData();
        }

        private void btndeleteAll_Click(object sender, EventArgs e)
        {

            var l2 = from s in db.linq_2s select s;
            db.linq_2s.DeleteAllOnSubmit(l2);
            db.SubmitChanges();
            MessageBox.Show("All Record Deleted");
            RefreshData();
        }
        }
}
