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
        //private string reasonerror;
        //private string personConfirm;

        public int STT { get => sTT; set => sTT = value; }
        public string Cabinet { get => cabinet; set => cabinet = value; }
        public string Result { get => result; set => result = value; }
        public string TimeCheck { get => timeCheck; set => timeCheck = value; }
       
        //public string PersonConfirm { get => personConfirm; set => personConfirm = value; }
        //public string Reasonerror { get => reasonerror; set => reasonerror = value; }

        public ResultMain(int stt, string cabi,string rs,string time)
        {
            STT = stt;
            Cabinet = cabi;
            Result = rs;
            TimeCheck = time;
            //Reasonerror = reasonerror;
            //PersonConfirm = reasonerror;
        }
    }
    public class ResultMainNew : ResultMain
    {
        private string reasonerror;
        private string personConfirm;
        public string PersonConfirm { get => personConfirm; set => personConfirm = value; }
        public string Reasonerror { get => reasonerror; set => reasonerror = value; }
        public ResultMainNew(int stt, string cabi, string rs, string time, string reasonerror, string personconfirm) : base(stt, cabi, rs, time)
        {
            Reasonerror = reasonerror;
            PersonConfirm = personconfirm;
        }
    }
}
