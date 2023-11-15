using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCheck
{
    public class  ResultMain
    {
        private int sTT;
        private string cabinet;
        private string result;
        private string timeCheck;

        public int STT { get => sTT; set => sTT = value; }
        public string Cabinet { get => cabinet; set => cabinet = value; }
        public string Result { get => result; set => result = value; }
        public string TimeCheck { get => timeCheck; set => timeCheck = value; }
        
        public ResultMain(int stt, string cabi,string rs,string time)
        {
            STT = stt;
            Cabinet = cabi;
            Result = rs;
            TimeCheck = time;
        }
    }
}
