using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
   public class Device
    {
        
        public string Name { get; }
        public string Manufacturer { get; }
        public string Type { get; }
        public string Os { get;}
        public string OsVersion { get; }
        public string Processor { get; }
        public int RAM { get; }
        
         
        public class DeviceBuilder
        {
           
            public string Name;
            public string Manufacturer;
            public string Type;
            public string Os;
            public string OsVersion;
            public string Processor;
            public int RAM;

          
            public DeviceBuilder SetName(string Name)
            {
                this.Name = Name;
                return this;
            }
            public DeviceBuilder SetManufacturer(string Manufacturer)
            {
                this.Manufacturer = Manufacturer;
                return this;
            }
            public DeviceBuilder SetType(string Type)
            {
                this.Type = Type;
                return this;
            }
            public DeviceBuilder SetOs(string Os)
            {
                this.Os = Os;
                return this;
            }
            public DeviceBuilder SetOsVersion(string OsVersion)
            {
                this.OsVersion = OsVersion;
                return this;
            }
            public DeviceBuilder SetProcessor(string Processor)
            {
                this.Processor = Processor;
                return this;
            }
            public DeviceBuilder SetRam(int Ram)
            {
                this.RAM = Ram;
                return this;
            }
            public Device build()
            {
                return new Device(this);
            }
        }
        private Device(DeviceBuilder builder)
        {
            
            this.Name = builder.Name;
            this.Manufacturer = builder.Manufacturer;
            this.Type = builder.Type;
            this.Processor = builder.Processor;
            this.Os = builder.Os;
            this.OsVersion = builder.OsVersion;
            this.RAM = builder.RAM;
        }
    }

}
