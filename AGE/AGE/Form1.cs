using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AGE
{
    public partial class Form1 : Form
    {
        private object dataTimePicker1;
        string gender;
        public Form1()
        {
            InitializeComponent();
        }
        
        public string conString = "Data Source=DESKTOP-GVFM3FQ;Initial Catalog=AGE;Integrated Security=True";

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            f(textBox1.Text.Length > 10)
            {
                textBox1.Text = textBox1.Text.Substring(0, 10);
                MessageBox.Show("The length of the first name should be less than 10");
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
                      
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text.Length > 10)
            {
                textBox2.Text = textBox2.Text.Substring(0, 10);
                MessageBox.Show("The length of the first name should be less than 10");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text.Length > 10)
            {
                textBox3.Text = textBox1.Text.Substring(0, 10);
                MessageBox.Show("The length of the first name should be less than 10");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var today = DateTime.Today;

            var age = today.Year - dateTimePicker1.Value.Year;

            if (dateTimePicker1.Value.Date > today.AddYears(-age)) age--;

            textBox1.Text = Convert.ToString(age);

            Regex r = new Regex(@"^[0-9](10)$");
                if (r.IsMatch(textBox4.Text))
            {
                MessageBox.Show("valid mobile number");

            }
            else
            {
                MessageBox.Show("Invalid mobile number");
            }

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State==System.Data.ConnectionState.Open)
            {

                string q = "insert into BASIC_DETAILS([FIRST NAME], [LAST NAME], GENDER, DATE, AGE)values('"+textBox2.Text.Tostring()+"', '"+textBox3.Text.Tostring()+"', '"+gender.Text.Tostring()+"', '"+textBoxdateTimePicker1.Text.Tostring()+"', '"+textBox1.Text.Tostring()+"')";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("connection made succesfully");
            }
        }
    }
}
