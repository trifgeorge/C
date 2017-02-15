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
    public partial class Assignments : Form
    {
        public Controller contr;
        public string username;
        public Assignments(Controller contr,string username)
        {
            this.contr = contr;
            this.username = username;
            InitializeComponent();
            this.label1.Text =username;
            this.textBox1.ReadOnly = true;
            this.textBox2.ReadOnly = true;
            this.textBox3.ReadOnly = true;
            this.textBox4.ReadOnly = true;
            this.textBox5.ReadOnly = true;
            this.textBox6.ReadOnly = true;
            this.SetListBox();

        }

        private void SetListBox()
        {
            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();
            this.listBox3.Items.Clear();
            List<Device> devs = this.contr.SelectUnassigned();
            foreach(Device d in devs)
            {
                this.listBox3.Items.Add(d.Name);
            }
            List<Device> devss = this.contr.SelectAssignedToCurrentUser(this.username);
            foreach (Device d in devss)
            {
                this.listBox1.Items.Add(d.Name);
            }
            List<Tuple<string, string>> userdevice = this.contr.SelectAllAssignments();
            foreach (var item in userdevice)
            {
                string username = item.Item1;
                string name = item.Item2;
                this.listBox2.Items.Add(name + " assigned to " + username);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main(this.contr, this.username);
            main.Show();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = listBox3.GetItemText(listBox3.SelectedItem);
            //MessageBox.Show(name);
            Device dev = this.contr.SelectDevice(name);
            this.textBox1.Text = dev.Manufacturer;
            this.textBox2.Text = dev.Type;
            this.textBox3.Text = dev.Os;
            this.textBox4.Text = dev.OsVersion;
            this.textBox5.Text = dev.Processor;
            this.textBox6.Text = dev.RAM.ToString() + "G";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = listBox3.GetItemText(listBox3.SelectedItem);
            if (name.Length != 0) { 
            this.contr.AssignToCurrentUser(name, this.username);
            MessageBox.Show(name +"  was assigned to you");
            this.SetListBox();
            }else
            {
                MessageBox.Show("You need to select a device from Unassigned table");
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = listBox1.GetItemText(listBox1.SelectedItem);
            if (name.Length != 0) { 
            this.contr.RemoveAssignment(this.username, name);
            MessageBox.Show(name +"was removed from your assignments");
            this.SetListBox();
            }else
            {
                MessageBox.Show("You need to select a device from Assigned to You table");
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = listBox2.GetItemText(listBox2.SelectedItem);
            
            int index = name.IndexOf(' ');
            string result = name.Substring(0, index);
            Device dev = this.contr.SelectDevice(result);
            this.textBox1.Text = dev.Manufacturer;
            this.textBox2.Text = dev.Type;
            this.textBox3.Text = dev.Os;
            this.textBox4.Text = dev.OsVersion;
            this.textBox5.Text = dev.Processor;
            this.textBox6.Text = dev.RAM.ToString() + "G";
        }
    }
}
