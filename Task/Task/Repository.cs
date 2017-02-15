using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Task
{
    public class Repository
    {
        //private Repository repo;
        
        public SqlConnection con;
        public Repository()
        {
          string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Task\Task\Database1.mdf;Integrated Security=True";
          ////this.repo = new Repository();
          this.con = new SqlConnection(conString);
          //this.con = con;
          

        }

        

        public List<Device> SelectAllDevices()
        {
            List<Device> devs = new List<Device>();
            
            this.con.Open();
            try
            {
                using (SqlCommand command = new SqlCommand("Select * From Device", this.con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Device dev = new Device.DeviceBuilder().SetName(reader.GetString(1)).SetManufacturer(reader.GetString(2)).SetType(reader.GetString(3)).SetOs(reader.GetString(4)).SetOsVersion(reader.GetString(5)).SetProcessor(reader.GetString(6)).SetRam(reader.GetInt32(7)).build();
                        devs.Add(dev);
                    }
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
            finally
            {
                this.con.Close();
            }
            return devs;
        
        }

        public List<Tuple<string, string>> SelectAllAssignments()
        {
            List<Tuple<string,string>> userdevice = new List<Tuple<string, string>>();
            this.con.Open();
            SqlCommand com = new SqlCommand("Select * from userdevice", this.con);
            using (SqlDataReader reader = com.ExecuteReader()) {
                while (reader.Read())
                {
                    userdevice.Add(Tuple.Create(reader.GetString(1),reader.GetString(2)));
                }


            }
            this.con.Close();
            return userdevice;

        }

        public List<string> SelectAssignnedToCurrentUser(string username)
        {
            this.con.Open();
            List<string> names = new List<string>();
            SqlCommand command = new SqlCommand("Select name from UserDevice where username=@username", this.con);
            command.Parameters.AddWithValue("@username", username);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    names.Add(reader.GetString(0));
                }
            }
            this.con.Close();
            return names;
        }

        public void RemoveUserDevice(string name)
        {
            this.con.Open();
            try
            {
                SqlCommand command = new SqlCommand("Delete From UserDevice where name=@name", this.con);
                command.Parameters.AddWithValue("@name", name);
                command.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
            finally
            {
                this.con.Close();
            }
        }

    

        public Device SelectDevice(string name)
        {
            this.con.Open();
            Device dev=null;
            try
            {
                SqlCommand command = new SqlCommand("Select * From Device where name=@name", this.con);
                command.Parameters.AddWithValue("@name", name);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dev = new Device.DeviceBuilder().SetName(reader.GetString(1)).SetManufacturer(reader.GetString(2)).SetType(reader.GetString(3)).SetOs(reader.GetString(4)).SetOsVersion(reader.GetString(5)).SetProcessor(reader.GetString(6)).SetRam(reader.GetInt32(7)).build();
                    }
                }
            }catch(SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
            finally{ 
            this.con.Close();
            }
            return dev;
        }

        public void RemoveAssignment(string username, string name)
        {
            this.con.Open();
            SqlCommand com = new SqlCommand("Delete from UserDevice where username=@username and name=@name",this.con);
            com.Parameters.AddWithValue("@username",username);
            com.Parameters.AddWithValue("@name",name);
            com.ExecuteNonQuery();
            this.con.Close();
        }

        public void AssignToCurrentUser(string name, string username)
        {
            this.con.Open();


            try
            {
                SqlCommand comm = new SqlCommand("Insert into UserDevice (username, name) values (@username, @name)", this.con);

                comm.Parameters.AddWithValue("@username", username);
                comm.Parameters.AddWithValue("@name", name);
                

                comm.ExecuteNonQuery();

            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
            finally
            {
                this.con.Close();
            }

        }

        public void RemoveDevice(string name)
        {
            this.con.Open();
            try
            {
                SqlCommand command = new SqlCommand("Delete From Device where name=@name", this.con);
                command.Parameters.AddWithValue("@name", name);
                command.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
            finally
            {
                this.con.Close();
            }
            }
        public void InsertDevice(Device device)
        {
            this.con.Open();
            
            
            try
            {
                SqlCommand comm = new SqlCommand("Insert into Device (Name, Manufacturer, Type , Os, OsVersion, Processor, RAM) values (@Name, @Manufacturer, @Type, @Os, @OsVersion, @Processor, @Ram)", this.con);
                
                comm.Parameters.AddWithValue("@Name", device.Name);
                comm.Parameters.AddWithValue("@Manufacturer",device.Manufacturer);
                comm.Parameters.AddWithValue("@Type",device.Type);
                comm.Parameters.AddWithValue("@Os",device.Os);
                comm.Parameters.AddWithValue("@OsVersion", device.OsVersion);
                comm.Parameters.AddWithValue("@Processor", device.Processor);
                comm.Parameters.AddWithValue("@Ram", device.RAM);

                comm.ExecuteNonQuery();

            } catch(SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
            finally
            {
                this.con.Close();
            }
            
        }
        public void UpdateDevice(Device dev)
        {

            this.RemoveDevice(dev.Name);
            this.InsertDevice(dev);
          
        }
        public int VerifyDevice(string name)
        {
            this.con.Open();
            int i = 0;
            SqlCommand command = new SqlCommand("Select COUNT(*) From Device where name=@name", this.con);
            command.Parameters.AddWithValue("@name", name);
            
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetInt32(0) == 1)
                    {
                        i = 1;
                    }
                }
            }
            this.con.Close();
            return i;

        }
        public int VerifyUser(string username,string password)
        {
            this.con.Open();
            int i = 0;
            SqlCommand command = new SqlCommand("Select COUNT(*) From Users where username=@username and password=@password", this.con);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetInt32(0) ==1)
                    {
                        i = 1;
                    }
                }
            }
            this.con.Close();
            return i;
        }
        public int CreateAccount(string username, string password, string role, string location)
        {
            int i = 0;
            this.con.Open();
            try
            {
                SqlCommand command = new SqlCommand("Select COUNT(*) From Users where username=@username", this.con);
                command.Parameters.AddWithValue("@username", username);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetInt32(0) == 0)
                        {
                            i = 1;
                        }
                    }
                }
                if (i != 0)
                {
                    SqlCommand comm = new SqlCommand("Insert into Users (Username, Password, Role, Location) values (@Username, @Password, @Role, @Location)", this.con);
                    comm.Parameters.AddWithValue("@Username", username);
                    comm.Parameters.AddWithValue("@Password", password);
                    comm.Parameters.AddWithValue("@Role", role);
                    comm.Parameters.AddWithValue("@Location", location);
                    

                    comm.ExecuteNonQuery();
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
            finally
            {
                this.con.Close();
            }
            return i;
        }
        public List<string> SelectUnassignned()
        {
            this.con.Open();
            List<string> devs = new List<string>();
            
            
                using (SqlCommand command = new SqlCommand("Select Name From Device Where Name NOT IN (SELECT Name From UserDevice)", this.con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                

                while (reader.Read())
                    {
                   
                    string name = reader.GetString(0);
                   
                    devs.Add(name);
                    
                    }
                }


            this.con.Close();               
            return devs;

        }
    }
    
}
