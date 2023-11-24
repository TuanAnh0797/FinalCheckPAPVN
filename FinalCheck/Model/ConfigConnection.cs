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
        private static int port;
        public static string IpAddress { get => ipAddress; set => ipAddress = value; }
        public static int Port { get => port; set => port = value; }

        public static class ReadData
        {
            //
            private static string typeDeviceTrigerReadCabi;
            private static int nameDeviceTrigerReadCabi;
            //
            private static string typeDeviceDataCabi;
            private static int nameDeviceDataCabi;
            private static int quantityDataCabi;
            //
            private static string typeDeviceTrigerConfirm;
            private static int nameDeviceTrigerConfirm;
            //
            private static string typeDeviceDataPerson;
            private static int nameDeviceDataPerson;
            private static int quantityDataPerson;
            //
            private static string typeDeviceDataReason;
            private static int nameDeviceDataReason;
            private static int quantityDataReason;
            //
            public static string TypeDeviceTrigerReadCabi { get => typeDeviceTrigerReadCabi; set => typeDeviceTrigerReadCabi = value; }
            public static int NameDeviceTrigerReadCabi { get => nameDeviceTrigerReadCabi; set => nameDeviceTrigerReadCabi = value; }
            public static string TypeDeviceDataCabi { get => typeDeviceDataCabi; set => typeDeviceDataCabi = value; }
            public static int NameDeviceDataCabi { get => nameDeviceDataCabi; set => nameDeviceDataCabi = value; }
            public static int QuantityDataCabi { get => quantityDataCabi; set => quantityDataCabi = value; }
            public static string TypeDeviceTrigerConfirm { get => typeDeviceTrigerConfirm; set => typeDeviceTrigerConfirm = value; }
            public static int NameDeviceTrigerConfirm { get => nameDeviceTrigerConfirm; set => nameDeviceTrigerConfirm = value; }
            public static string TypeDeviceDataPerson { get => typeDeviceDataPerson; set => typeDeviceDataPerson = value; }
            public static int NameDeviceDataPerson { get => nameDeviceDataPerson; set => nameDeviceDataPerson = value; }
            public static int QuantityDataPerson { get => quantityDataPerson; set => quantityDataPerson = value; }
            public static string TypeDeviceDataReason { get => typeDeviceDataReason; set => typeDeviceDataReason = value; }
            public static int NameDeviceDataReason { get => nameDeviceDataReason; set => nameDeviceDataReason = value; }
            public static int QuantityDataReason { get => quantityDataReason; set => quantityDataReason = value; }

        }
        public static class WriteData
        {
            private static string typeDeviceSendResult;
            private static int nameDeviceSendResult;
            private static int quantityDeviceSendResult;

            public static string TypeDeviceSendResult { get => typeDeviceSendResult; set => typeDeviceSendResult = value; }
            public static int NameDeviceSendResult { get => nameDeviceSendResult; set => nameDeviceSendResult = value; }
            public static int QuantityDeviceSendResult { get => quantityDeviceSendResult; set => quantityDeviceSendResult = value; }
        }
        public static class WriteBit
        {
            private static string typeDeviceSendConfirm;
            private static int nameDeviceSendConfirm;

            public static string TypeDeviceSendConfirm { get => typeDeviceSendConfirm; set => typeDeviceSendConfirm = value; }
            public static int NameDeviceSendConfirm { get => nameDeviceSendConfirm; set => nameDeviceSendConfirm = value; }
        }




    }
}
