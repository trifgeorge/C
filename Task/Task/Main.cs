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
    public partial class Main : Form
    {
        public Controller contr;
        public string username;
        public Main(Controller contr, string username)
        {
            this.contr = contr;
            this.username = username;

            InitializeComponent();
            this.label1.Text = "Hello " + this.username;
            this.SetListBox();
            this.textBox1.ReadOnly = true;
            this.textBox2.ReadOnly = true;
            this.textBox3.ReadOnly = true;
            this.textBox4.ReadOnly = true;
            this.textBox5.ReadOnly = true;
            this.textBox6.ReadOnly = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateNewDevice create = new CreateNewDevice(this.contr, this.username);
            create.Show();
            this.Hide();
            //this.SetListBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1(this.contr);
            form.Show();
        }
        public void SetListBox()
        {
            this.listBox1.Items.Clear();
            List<Device> devs = this.contr.SelectAllDevices();
            foreach (Device d in devs)
            {
                this.listBox1.Items.Add(d.Name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = listBox1.GetItemText(listBox1.SelectedItem);
            //MessageBox.Show(name);
            Device dev = this.contr.SelectDevice(name);
            this.textBox1.Text = dev.Manufacturer;
            this.textBox2.Text = dev.Type;
            this.textBox3.Text = dev.Os;
            this.textBox4.Text = dev.OsVersion;
            this.textBox5.Text = dev.Processor;
            this.textBox6.Text = dev.RAM.ToString() + "G";
            this.textBox7.Text = dev.Manufacturer;
            this.textBox8.Text = dev.Type;
            this.textBox9.Text = dev.Os;
            this.textBox10.Text = dev.OsVersion;
            this.textBox11.Text = dev.Processor;
            this.textBox12.Text = dev.RAM.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = listBox1.GetItemText(listBox1.SelectedItem);
            string manufacturer = this.textBox7.Text;
            string type = this.textBox8.Text;
            string os = this.textBox9.Text;
            string osVersion = this.textBox10.Text;
            string processor = this.textBox11.Text;
            string ram = this.textBox12.Text;

            int rram;
            if (!Int32.TryParse(ram, out rram) || name.Length == 0 || manufacturer.Length==0 || type.Length==0 || os.Length==0 || osVersion.Length==0 || processor.Length==0 || ram.Length==0)
            {
                MessageBox.Show("The ram must be an integer and length not 0");

            }
            else
            {
                this.contr.UpdateDevice(name, manufacturer, type, os, osVersion, processor, Convert.ToInt32(ram));
                MessageBox.Show("The Device was updated");
                this.SetListBox();
                
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = listBox1.GetItemText(listBox1.SelectedItem);
            this.contr.RemoveDevice(name);
            MessageBox.Show("The Device was removed");
            this.SetListBox();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Assignments assi = new Assignments(this.contr, this.username);
            assi.Show();
        }
    }
}
