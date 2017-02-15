using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Task
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //Repository repo = new Repository();
            //Device dev = new Device.DeviceBuilder().SetName("name4").SetManufacturer("manu4").SetType("type6").SetOs("os4").SetOsVersion("123.23").SetProcessor("proc4").SetRam(15).build();
            //repo.UpdateDevice(dev);
            ////repo.RemoveDevice("name4");
            //List<Device> devs=repo.SelectAllDevices();
            //foreach(Device d in devs) { 
            //MessageBox.Show(d.Type.ToString());
            //}
            //Device d1=repo.SelectDevice("name3");
            //MessageBox.Show(d1.Os.ToString());
            Repository repo = new Repository();
            Controller contr = new Controller(repo);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(contr));

        }
    }
}
