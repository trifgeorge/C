using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task
{
    public partial class CreateAccount : Form
    {
        public Controller contr;
        public CreateAccount(Controller contr)
        {
            this.contr = contr;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1(this.contr);
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
            string password = this.textBox2.Text;
            string role = this.textBox3.Text;
            string location = this.textBox4.Text;

            int i=this.contr.CreateAccount(username,password,role,location);
            if (i == 0 || username.Length == 0 || password.Length == 0 || role.Length==0 || location.Length==0)
            {
                MessageBox.Show("This username is already taken or one of the inputs is invalid");
            }else
            {
                MessageBox.Show("Account Created");
                Form1 form = new Form1(this.contr);
                form.Show();
                this.Hide();
            }
        }
    }
}
