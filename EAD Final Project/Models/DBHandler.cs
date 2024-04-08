using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EAD_Final_Project.Models
{
    internal class DBHandler
    {
        public static TransportManagementSystemContext context=new TransportManagementSystemContext();
        public static (int, User) FindUser(string email)
        {
            User obj = context.Users.Find(email) as User;
            return (obj != null ? obj.Role : 0, obj);
        }
        public static VehicleEntry AddEntry(string NumberPlateNumber)
        {
            VehicleEntry e = new VehicleEntry {In=DateTime.Now,Out=null,Status="in",NumberPlateNumber=NumberPlateNumber };
            context.VehicleEntries.Add(e);
            context.SaveChanges();
            MessageBox.Show("Entry Added");
            return e;
        }
        public static void setOutTime(int id)
        {
            VehicleEntry obj=context.VehicleEntries.Find(id) as VehicleEntry;
            obj.Status = "out";
            obj.Out = DateTime.Now;
            context.SaveChanges();
        }
    }
}
