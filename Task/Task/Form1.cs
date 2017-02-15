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
    public partial class Form1 : Form
    {
        public Controller contr;
        public Form1(Controller contr)
        {
            this.contr = contr;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateAccount create = new CreateAccount(this.contr);
            create.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
            string password = this.textBox2.Text;

            int i = this.contr.VerifyUser(username, password);

            if (i != 0)
            {
                MessageBox.Show("Successfully Logged In");
                
                Main main = new Main(this.contr,username);
                main.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Wrong credentials");
            }
        }
    }
}
