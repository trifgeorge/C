using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class Controller
    {
        public Repository repo;

        public Controller(Repository repo)
        {
            this.repo = repo;
        }
        public int VerifyUser(string username,string password)
        {
            int i=this.repo.VerifyUser(username, password);
            return i;
        }
        public int CreateAccount(string username,string password,string role,string location)
        {
            int i = this.repo.CreateAccount(username, password, role, location);
            return i;
        }

        public int InsertDevice(string name, string manufacturer, string type, string os, string osVersion, string processor, string ram)
        {
            Device dev = new Device.DeviceBuilder().SetName(name).SetManufacturer(manufacturer).SetType(type).SetOs(os).SetOsVersion(osVersion).SetProcessor(processor).SetRam(Convert.ToInt32(ram)).build();
            if (this.repo.VerifyDevice(dev.Name) == 1)
            {
                return 1;
            }
            this.repo.InsertDevice(dev);
            return 0 ;
        }

        public List<Device> SelectAssignedToCurrentUser(string username)
        {
            List<string> names = this.repo.SelectAssignnedToCurrentUser(username);
            List<Device> devs = new List<Device>();
            foreach (string n in names)
            {
                devs.Add(this.repo.SelectDevice(n));
            }
            return devs;
        }

        public List<Tuple<string, string>> SelectAllAssignments()
        {
            return this.repo.SelectAllAssignments();
        }

        public List<Device> SelectAllDevices()
        {
            return this.repo.SelectAllDevices();
        }

        public Device SelectDevice(string name)
        {
            return this.repo.SelectDevice(name);
        }

        public void UpdateDevice(string name, string manufacturer, string type, string os, string osVersion, string processor, int v)
        {
            Device dev = new Device.DeviceBuilder().SetName(name).SetManufacturer(manufacturer).SetType(type).SetOs(os).SetOsVersion(osVersion).SetProcessor(processor).SetRam(v).build();
            this.repo.UpdateDevice(dev);
        }

        public void RemoveDevice(string name)
        {
            this.repo.RemoveDevice(name);
            this.repo.RemoveUserDevice(name);
        }
        public List<Device> SelectUnassigned()
        {
            List<string> names=this.repo.SelectUnassignned();
            List<Device> devs = new List<Device>();
            foreach(string n in names)
            {
                devs.Add(this.repo.SelectDevice(n));
            }
            return devs;
        }

        public void AssignToCurrentUser(string name, string username)
        {
            this.repo.AssignToCurrentUser(name, username);
        }

        public void RemoveAssignment(string username, string name)
        {
            this.repo.RemoveAssignment(username, name);
        }
    }
}
