CREATE DEFINER=`root`@`localhost` PROCEDURE `GetConfigConnectPlc`()
BEGIN
    SELECT 
        IpAddress,
        PortNumber,
        NameDeviceTrigerReadCabi,
        NameDeviceDataCabi,
        QuantityDataCabi,
        NameDeviceDataPerson,
        QuantityDataPerson,
        NameDeviceDataReason,
        QuantityDataReason,
        NameDeviceSendResult,
        QuantityDeviceSendResult,
        AliveBit,
        NameDeviceSendConfirm,
        NameDeviceTrigerReadError
    FROM DataPLC.ConfigConnectionPlc;
END