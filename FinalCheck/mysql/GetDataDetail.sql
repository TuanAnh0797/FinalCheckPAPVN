CREATE DEFINER=`root`@`localhost` PROCEDURE `GetDataDetail`(IN p_NameCabi NVARCHAR(30))
BEGIN
    SELECT 
        CodeBack,
        Judge,
        VaccumAct,
        VaccumSpec,
        PumpNo,
        TimePLC AS TimeCheck
    FROM DataPLC.VP
    WHERE CodeBack = p_NameCabi
    ORDER BY TimePLC DESC
    LIMIT 20;
    -- Query for GAS table
    SELECT 
        CodeBack,
        Judge,
        CodeCompressor,
        Temp,
        OIL,
        OILSpec,
        GAS,
        GASSpec,
        Mode,
        PUMP,
        VaccumCou,
        VaccumRF,
        PressureGasPipe,
        TimePLC AS TimeCheck
    FROM DataPLC.GAS
    WHERE CodeBack = p_NameCabi
    ORDER BY TimePLC DESC
    LIMIT 20;
	SELECT 
		CodeBack
      ,Judge
      ,Volt
      ,LL
      ,UL
      ,ValueActual
      ,LLOM
      ,ValueOM
       ,TimePLC as TimeCheck
  FROM DataPLC.WI1WITH 
  where CodeBack = p_NameCabi order by TimePLC desc  LIMIT 20;
  
  SELECT 
      CodeBack
      ,Judge
      ,Volt
      ,LL
      ,UL
      ,ValueActual
       ,TimePLC as TimeCheck
  FROM DataPLC.WI1START 
  where CodeBack = p_NameCabi order by TimePLC desc LIMIT 20;
  
   SELECT 
      CodeBack
      ,Judge
      ,Volt
      ,LL
      ,UL
      ,Value
      ,CurrentmA
      ,U
      ,Progname
      ,TimePLC as TimeCheck
  FROM DataPLC.IP 
   where CodeBack = p_NameCabi order by TimePLC desc LIMIT 20;
   
    SELECT 
      CodeBack
      ,Judge
      ,Volt
      ,LL
      ,UL
      ,Value
      ,CurrentmA
      ,U
      ,Progname
      ,TimePLC as TimeCheck
  FROM DataPLC.DF
  where CodeBack = p_NameCabi order by TimePLC desc LIMIT 20;
    
    SELECT 
      CodeModel
      ,Judge
      ,NamePoint1
      ,Standard1
      ,Actual1
      ,Result1
      ,NamePoint2
      ,Standard2
      ,Actual2
      ,Result2
      ,NamePoint3
      ,Standard3
      ,Actual3
      ,Result3
      ,NamePoint4
      ,Standard4
      ,Actual4
      ,Result4
      ,NamePoint5
      ,Standard5
      ,Actual5
      ,Result5
      ,NamePoint6
      ,Standard6
      ,Actual6
      ,Result6
      ,NamePoint7
      ,Standard7
      ,Actual7
      ,Result7
      ,NamePoint8
      ,Standard8
      ,Actual8
      ,Result8
      ,NamePoint9
      ,Standard9
      ,Actual9
      ,Result9
      ,NamePoint10
      ,Standard10
      ,Actual10
      ,Result10
      ,NamePoint11
      ,Standard11
      ,Actual11
      ,Result11
      ,NamePoint12
      ,Standard12
      ,Actual12
      ,Result12
      ,NamePoint13
      ,Standard13
      ,Actual13
      ,Result13
      ,NamePoint14
      ,Standard14
      ,Actual14
      ,Result14
      ,NamePoint15
      ,Standard15
      ,Actual15
      ,Result15
      ,TimePLC as TimeCheck
  FROM DataPLC.TempDetail
  where CodeModel = p_NameCabi order by TimePLC desc LIMIT 20;
  
  SELECT 
      CodeBack
      ,Judge
      ,QRCode
      ,Seed
      ,MacAddress
      ,CurrentFirm
      ,RSSI
      ,InspectionTime
      ,NG_STEP
      ,PassKey
      ,BTMacAddress
      ,CertSN
      ,ExtFid
      ,Vendor
      ,TimePLC as TimeCheck
  FROM DataPLC.IOT
 where CodeBack = p_NameCabi order by TimePLC desc LIMIT 20;
 
 SELECT 
      CodeBack
      ,Judge
      ,Volt
      ,LL
      ,UL
      ,ValueActual
      ,LLom
      ,Valueom
      ,Progname
       ,TimePLC as TimeCheck
  FROM DataPLC.WI2
  where CodeBack = p_NameCabi order by TimePLC desc LIMIT 20;
SELECT 
      CodeBack
      ,Judge
      ,CodePCB
      ,CodeMarket
      ,CodePan
      ,No
     ,TimePLC as TimeCheck
  FROM DataPLC.PAN 
  where CodeBack = p_NameCabi order by TimePLC desc LIMIT 20;
  SELECT 
      CodeBack
      ,Judge
      ,VitSidePhai
      ,VitSideTrai
      ,Hookpan
      ,PWE
      ,VitPWE
      ,InPadComp
      ,ClampPipe
      ,VitClampPipe
      ,BoxPCB
      ,VitBoxPCB
      ,ChotComp
      ,BanhXePhai
      ,BanhXeTrai
      ,CapPipe
      ,RubberPipe
      ,InsPadComp
      ,DayNoiDat
      ,VitDayNoiDatSidePhai
      ,WiringDiagram
      ,CoverComp
      ,VitCoverComp
      ,Hanger
      ,TimePLC as TimeCheck
  FROM DataPLC.CamBack 
 where CodeBack = p_NameCabi order by TimePLC desc LIMIT 20;

 SELECT 
      CodeBack
      ,Judge
      ,Econavi
      ,LogoPana
      ,Japanquality
      ,Warranty
      ,POPFC
      ,POPPC
      ,EnergyLabel
      ,PanelDoorFC
      ,PanelDoorPC
      ,WDLabel
      ,WD
      ,DoorControl
      ,_1ST
      ,Handle
      ,POPPCBottom
      ,Wellness
      ,ADVISORYLabel
      ,EnvironmentLabel
      ,POPBC
      ,CoverHingeTop
      ,FoamProtectorDoor
      ,TimePLC as TimeCheck
  FROM DataPLC.CamFront  
  where CodeBack = p_NameCabi order by TimePLC desc LIMIT 20;

END