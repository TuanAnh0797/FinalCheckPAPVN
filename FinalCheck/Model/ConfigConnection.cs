using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCheck.Model
{
    public static class ConfigConnection
    {
        private static string ipAddress;
        private static int portNumber;
        public static string IpAddress { get => ipAddress; set => ipAddress = value; }
        public static int PortNumber { get => portNumber; set => portNumber = value; }

        public static class ReadData
        {
            //
            private static int nameDeviceTrigerReadCabi;
            //
            private static int nameDeviceDataCabi;
            private static int quantityDataCabi;
            //
            //private static int nameDeviceTrigerConfirm;
            //
            private static int nameDeviceDataPerson;
            private static int quantityDataPerson;
            //
            private static int nameDeviceDataReason;
            private static int quantityDataReason;
            //
            private static int nameDeviceTrigerReadError;
            //
            public static int NameDeviceTrigerReadCabi { get => nameDeviceTrigerReadCabi; set => nameDeviceTrigerReadCabi = value; }
            public static int NameDeviceDataCabi { get => nameDeviceDataCabi; set => nameDeviceDataCabi = value; }
            public static int QuantityDataCabi { get => quantityDataCabi; set => quantityDataCabi = value; }
            

            //public static int NameDeviceTrigerConfirm { get => nameDeviceTrigerConfirm; set => nameDeviceTrigerConfirm = value; }
            public static int NameDeviceDataPerson { get => nameDeviceDataPerson; set => nameDeviceDataPerson = value; }
            public static int QuantityDataPerson { get => quantityDataPerson; set => quantityDataPerson = value; }
            public static int NameDeviceDataReason { get => nameDeviceDataReason; set => nameDeviceDataReason = value; }
            public static int QuantityDataReason { get => quantityDataReason; set => quantityDataReason = value; }
            public static int NameDeviceTrigerReadError { get => nameDeviceTrigerReadError; set => nameDeviceTrigerReadError = value; }
        }
        public static class WriteData
        {
           
            private static int nameDeviceSendResult;
            private static int quantityDeviceSendResult;

            public static int NameDeviceSendResult { get => nameDeviceSendResult; set => nameDeviceSendResult = value; }
            public static int QuantityDeviceSendResult { get => quantityDeviceSendResult; set => quantityDeviceSendResult = value; }
           
        }
        public static class WriteBit
        {
            private static int aliveBit;
            private static int nameDeviceSendConfirm;

            public static int AliveBit { get => aliveBit; set => aliveBit = value; }
            public static int NameDeviceSendConfirm { get => nameDeviceSendConfirm; set => nameDeviceSendConfirm = value; }
        }




    }
}
