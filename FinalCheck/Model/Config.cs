using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCheck.Model
{
    public class Config
    {
        public DataBase DataBase { get; set; }
    }
    public class DataBase
    {
        public string ConnectionString { get; set; }
    }

   
}
