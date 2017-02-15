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
    public partial class CreateNewDevice : Form
    {
        public Controller contr;
        public string username;
        public CreateNewDevice(Controller contr,string username)
        {
            this.contr = contr;
            this.username = username;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = this.textBox1.Text;
            string manufacturer = this.textBox2.Text;
            string type = this.textBox3.Text;
            string os = this.textBox4.Text;
            string osVersion = this.textBox5.Text;
            string processor = this.textBox6.Text;
            string ram = this.textBox7.Text;
            int rram;
            if (!Int32.TryParse(ram, out rram) || name.Length == 0 || manufacturer.Length == 0 || type.Length == 0 || os.Length == 0 || osVersion.Length == 0 || processor.Length == 0 || ram.Length == 0)

            {
                MessageBox.Show("The ram must be an integer and length not 0");


            }
            else
            {
                int i = this.contr.InsertDevice(name, manufacturer, type, os, osVersion, processor, ram);
                if (i == 1)
                {
                    MessageBox.Show("This Device is already in");
                }
                else
                {
                    MessageBox.Show(name + "was added in the data base");

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Main main = new Main(this.contr, this.username);
            main.Show();
        }
    }
}
