using BilgeHotel.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.BLL.DesignPatterns.SingletonPatterns
{
    public class DBTool
    {
        DBTool() { }
        static ProjectContext _dbInstance;

        public static ProjectContext DBInstance
        {
            get
            {
                if (_dbInstance == null) _dbInstance = new ProjectContext();
                return _dbInstance;
            }
        }
    }
}
