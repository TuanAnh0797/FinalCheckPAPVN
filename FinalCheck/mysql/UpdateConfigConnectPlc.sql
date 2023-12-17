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
    NameDeviceTrigerReadError INT,
    VP tinyint,
    GAS tinyint,
    WI1WITH tinyint,
    WI1START tinyint,
    IP tinyint,
    DF tinyint,
    TEMP tinyint,
    IOT tinyint,
    WI2 tinyint,
    PAN tinyint,
    CAMBACK tinyint,
    CAMFRONT tinyint
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
	UPDATE configcheckfinal
    SET 
       VP = VP,
    GAS =GAS,
    WI1WITH =WI1WITH,
    WI1START =WI1START,
    IP =IP,
    DF =DF,
    TEMP =TEMP,
    IOT =IOT,
    WI2 =WI2,
    PAN =PAN,
    CAMBACK =CAMBACK,
    CAMFRONT = CAMFRONT;
END