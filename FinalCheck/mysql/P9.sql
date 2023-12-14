CREATE DEFINER=`TA`@`%` PROCEDURE `UpdateConfigConnectPlc`(
    IpAddress VARCHAR(30),
    PortNumber INT,
    NameDeviceTrigerReadCabi INT,
    NameDeviceDataCabi INT,
    NameDeviceDataPerson INT,
    NameDeviceDataReason INT,
    NameDeviceSendResult INT,
    AliveBit INT,
    NameDeviceSendConfirm INT,
    NameDeviceTrigerReadError INT
)
BEGIN
    UPDATE ConfigConnectionPlc
    SET 
        IpAddress = IpAddress,
        PortNumber = PortNumber,
        NameDeviceTrigerReadCabi = NameDeviceTrigerReadCabi,
        NameDeviceDataCabi = NameDeviceDataCabi,
        NameDeviceDataPerson = NameDeviceDataPerson,
        NameDeviceDataReason = NameDeviceDataReason,
        NameDeviceSendResult = NameDeviceSendResult,
        AliveBit = AliveBit,
        NameDeviceSendConfirm = NameDeviceSendConfirm,
        NameDeviceTrigerReadError = NameDeviceTrigerReadError;
END