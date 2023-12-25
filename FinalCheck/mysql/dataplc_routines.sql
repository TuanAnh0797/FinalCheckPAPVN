-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 192.168.3.178    Database: dataplc
-- ------------------------------------------------------
-- Server version	8.0.35

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Dumping events for database 'dataplc'
--

--
-- Dumping routines for database 'dataplc'
--
/*!50003 DROP PROCEDURE IF EXISTS `GetConfigCheckFinal` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetConfigCheckFinal`()
BEGIN
   SELECT  * FROM dataplc.configcheckfinal limit 1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetConfigConnectPlc` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
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
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetDataDetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
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
CodeBack,
CodeModel,
CodeSerial,
Judge,
NamePoint1,
Standard1,
Actual1,
Result1,
NamePoint2,
Standard2,
Actual2,
Result2,
NamePoint3,
Standard3,
Actual3,
Result3,
NamePoint4,
Standard4,
Actual4,
Result4,
NamePoint5,
Standard5,
Actual5,
Result5,
NamePoint6,
Standard6,
Actual6,
Result6,
NamePoint7,
Standard7,
Actual7,
Result7,
NamePoint8,
Standard8,
Actual8,
Result8,
NamePoint9,
Standard9,
Actual9,
Result9,
NamePoint10,
Standard10,
Actual10,
Result10,
NamePoint11,
Standard11,
Actual11,
Result11,
NamePoint12,
Standard12,
Actual12,
Result12,
NamePoint13,
Standard13,
Actual13,
Result13,
NamePoint14,
Standard14,
Actual14,
Result14,
NamePoint15,
Standard15,
Actual15,
Result15,
TimePLC as TimeCheck
  FROM DataPLC.TempDetail
  where substring(CodeBack,1,19)  = p_NameCabi  order by TimePLC desc LIMIT 20;
  SELECT 
	CodeBack,
	CodeModel,
	CodeSerial,
	Judge,
	CodeMarket,
	Information,
	QRCode,
	PassKey,
	ErrorName,
	TimePLC as TimeCheck
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

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetJudgeAllLine` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetJudgeAllLine`(IN p_CodeModel NVARCHAR(30))
BEGIN
    DECLARE rsVP NVARCHAR(2);
    DECLARE rsGAS NVARCHAR(2);
    DECLARE rsWI1WITH NVARCHAR(2);
    DECLARE rsWI1START NVARCHAR(2);
    
    DECLARE rsIP NVARCHAR(2);
    DECLARE rsDF NVARCHAR(2);
    DECLARE rsPAN NVARCHAR(2);
    DECLARE rsWI2 NVARCHAR(2);
    DECLARE rsIOT NVARCHAR(2);
    DECLARE rsTemp NVARCHAR(2);
    DECLARE rsCAMBack NVARCHAR(2);
    DECLARE rsCAMFront NVARCHAR(2);
    
    DECLARE rsTotal NVARCHAR(2);
    
	DECLARE _VP tinyint;
    DECLARE _GAS tinyint;
    DECLARE _WI1WITH tinyint;
   DECLARE _WI1START tinyint;
   DECLARE _IP tinyint;
   DECLARE _DF tinyint;
  DECLARE  _TEMP tinyint;
   DECLARE _IOT tinyint;
  DECLARE  _WI2 tinyint;
  DECLARE  _PAN tinyint;
  DECLARE  _CAMBACK tinyint;
  DECLARE  _CAMFRONT tinyint;
  
  SELECT VP,GAS,WI1WITH,WI1START,IP,DF,TEMP,IOT,WI2,PAN,CAMBACK,CAMFRONT INTO _VP,_GAS,_WI1WITH,_WI1START,_IP,_DF,_TEMP,_IOT,_WI2,_PAN,_CAMBACK,_CAMFRONT FROM configcheckfinal  LIMIT 1;
	IF(_VP = 1) THEN
         SELECT Judge INTO rsVP FROM VP WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsVP = 'NA';
    END IF;
    
    IF(_GAS = 1) THEN
         SELECT Judge INTO rsGAS FROM gas WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsGAS = 'NA';
    END IF;
     IF(_WI1WITH = 1) THEN
         SELECT Judge INTO rsWI1WITH FROM wi1with WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsWI1WITH = 'NA';
    END IF;
     IF(_WI1START = 1) THEN
          SELECT Judge INTO rsWI1START FROM wi1start WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsWI1START = 'NA';
    END IF;
    
    IF(_IP = 1) THEN
          SELECT Judge INTO rsIP FROM  ip WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsIP = 'NA';
    END IF;
    IF(_DF = 1) THEN
          SELECT Judge INTO rsDF FROM  df WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsDF = 'NA';
    END IF;
     IF(_TEMP = 1) THEN
          SELECT Judge INTO rsTemp FROM  tempresult WHERE substring(CodeBack,1,19)  = p_CodeModel  ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsTemp = 'NA';
    END IF;
     IF(_IOT = 1) THEN
          IF(exists(select NameModel from modelcheckiot where NameModel = substring(p_CodeModel,1,12))) THEN
        SELECT Judge INTO rsIOT FROM  iot WHERE CodeBack = p_CodeModel and (Judge = 'OK' or Judge = 'NG')  ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsIOT = 'NA';
    END IF;
    ELSE
        SET rsIOT = 'NA';
    END IF;

      IF(_WI2 = 1) THEN
          SELECT Judge INTO rsWI2 FROM wi2  WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsWI2 = 'NA';
    END IF;
   
	 IF(_PAN = 1) THEN
          SELECT Judge INTO rsPAN FROM  pan WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsPAN = 'NA';
    END IF;
    IF(_CAMBACK = 1) THEN
           SELECT Judge INTO rsCAMBack FROM  camback WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsCAMBack = 'NA';
    END IF;
     IF(_CAMFRONT = 1) THEN
            SELECT Judge INTO rsCAMFront FROM camfront  WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsCAMFront = 'NA';
    END IF;
     
     
     
      
	
   
   
   
  
  
   
   
   
   
   
IF((UPPER(rsVP) = 'OK' or rsVP = 'NA') AND 
	(UPPER(rsGAS) = 'OK' or rsGAS = 'NA') AND 
    (UPPER(rsWI1START) = 'OK' or rsWI1START ='NA') AND 
    (UPPER(rsIP) = 'OK'or rsIP = 'NA') AND 
    (UPPER(rsDF) = 'OK' or rsDF = 'NA')AND 
    (UPPER(rsWI1WITH) = 'OK'or rsWI1WITH = 'NA') AND 
    (UPPER(rsPAN) = 'OK' or rsPAN = 'NA')AND 
    (UPPER(rsWI2) = 'OK' or rsWI2 = 'NA')AND 
    (UPPER(rsIOT) = 'OK' or rsIOT = 'NA') AND 
    (UPPER(rsTemp) = 'OK'or rsTemp = 'NA') AND 
    (UPPER(rsCAMBack) = 'OK'or rsCAMBack = 'NA') AND 
    (UPPER(rsCAMFront) = 'OK' or rsCAMFront = 'NA')) THEN
        SET rsTotal = 'OK';
    ELSE
        SET rsTotal = 'NG';
    END IF;
    SELECT rsVP AS JudgeVP, rsGAS AS JudgeGAS, rsWI1START AS JudgeWI1START, rsWI1WITH AS JudgeWI1WITH, rsIP AS JudgeIP,
        rsDF AS JudgeDF, rsTemp AS JudgeTEMP, rsIOT AS JudgeIOT, rsPAN AS JudgePAN, rsWI2 AS JudgeWI2, 
        rsCAMBack AS JudgeCAMBACK, rsCAMFront AS JudgeCAMFRONT,
        rsTotal AS JudgeTotal;
 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetJudgeAllLineDetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetJudgeAllLineDetail`(IN p_CodeModel NVARCHAR(30))
BEGIN
    DECLARE rsVP NVARCHAR(2);
    DECLARE rsGAS NVARCHAR(2);
    DECLARE rsWI1WITH NVARCHAR(2);
    DECLARE rsWI1START NVARCHAR(2);
    
    DECLARE rsIP NVARCHAR(2);
    DECLARE rsDF NVARCHAR(2);
    DECLARE rsPAN NVARCHAR(2);
    DECLARE rsWI2 NVARCHAR(2);
    DECLARE rsIOT NVARCHAR(2);
    DECLARE rsTemp NVARCHAR(2);
    DECLARE rsCAMBack NVARCHAR(2);
    DECLARE rsCAMFront NVARCHAR(2);
    
    DECLARE rsTotal NVARCHAR(2);
     DECLARE Reason nvarchar(100);
	DECLARE UserConfirm nvarchar(50);
   

   DECLARE _VP tinyint;
    DECLARE _GAS tinyint;
    DECLARE _WI1WITH tinyint;
   DECLARE _WI1START tinyint;
   DECLARE _IP tinyint;
   DECLARE _DF tinyint;
  DECLARE  _TEMP tinyint;
   DECLARE _IOT tinyint;
  DECLARE  _WI2 tinyint;
  DECLARE  _PAN tinyint;
  DECLARE  _CAMBACK tinyint;
  DECLARE  _CAMFRONT tinyint;
  
        SELECT ReasonError,PersonConfirm  INTO Reason, UserConfirm FROM DataCheckFinal where CodeBack = p_CodeModel  ORDER BY  TimeUpdate DESC LIMIT 1;

  
  SELECT VP,GAS,WI1WITH,WI1START,IP,DF,TEMP,IOT,WI2,PAN,CAMBACK,CAMFRONT INTO _VP,_GAS,_WI1WITH,_WI1START,_IP,_DF,_TEMP,_IOT,_WI2,_PAN,_CAMBACK,_CAMFRONT FROM configcheckfinal  LIMIT 1;
	IF(_VP = 1) THEN
         SELECT Judge INTO rsVP FROM VP WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsVP = 'NA';
    END IF;
    
    IF(_GAS = 1) THEN
         SELECT Judge INTO rsGAS FROM gas WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsGAS = 'NA';
    END IF;
     IF(_WI1WITH = 1) THEN
         SELECT Judge INTO rsWI1WITH FROM wi1with WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsWI1WITH = 'NA';
    END IF;
     IF(_WI1START = 1) THEN
          SELECT Judge INTO rsWI1START FROM wi1start WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsWI1START = 'NA';
    END IF;
    
    IF(_IP = 1) THEN
          SELECT Judge INTO rsIP FROM  ip WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsIP = 'NA';
    END IF;
    IF(_DF = 1) THEN
          SELECT Judge INTO rsDF FROM  df WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsDF = 'NA';
    END IF;
     IF(_TEMP = 1) THEN
          SELECT Judge INTO rsTemp FROM  tempresult WHERE substring(CodeBack,1,19)  = p_CodeModel  ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsTemp = 'NA';
    END IF;
     IF(_IOT = 1) THEN
          IF(exists(select NameModel from modelcheckiot where NameModel = substring(p_CodeModel,1,12))) THEN
        SELECT Judge INTO rsIOT FROM  iot WHERE CodeBack = p_CodeModel and (Judge = 'OK' or Judge = 'NG') ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsIOT = 'NA';
    END IF;
    ELSE
        SET rsIOT = 'NA';
    END IF;

      IF(_WI2 = 1) THEN
          SELECT Judge INTO rsWI2 FROM wi2  WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsWI2 = 'NA';
    END IF;
   
	 IF(_PAN = 1) THEN
          SELECT Judge INTO rsPAN FROM  pan WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsPAN = 'NA';
    END IF;
    IF(_CAMBACK = 1) THEN
           SELECT Judge INTO rsCAMBack FROM  camback WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsCAMBack = 'NA';
    END IF;
     IF(_CAMFRONT = 1) THEN
            SELECT Judge INTO rsCAMFront FROM camfront  WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsCAMFront = 'NA';
    END IF;
     
     
     
      
	
   
   
   
  
  
   
   
   
   
   
IF((UPPER(rsVP) = 'OK' or rsVP = 'NA') AND 
	(UPPER(rsGAS) = 'OK' or rsGAS = 'NA') AND 
    (UPPER(rsWI1START) = 'OK' or rsWI1START ='NA') AND 
    (UPPER(rsIP) = 'OK'or rsIP = 'NA') AND 
    (UPPER(rsDF) = 'OK' or rsDF = 'NA')AND 
    (UPPER(rsWI1WITH) = 'OK'or rsWI1WITH = 'NA') AND 
    (UPPER(rsPAN) = 'OK' or rsPAN = 'NA')AND 
    (UPPER(rsWI2) = 'OK' or rsWI2 = 'NA')AND 
    (UPPER(rsIOT) = 'OK' or rsIOT = 'NA') AND 
    (UPPER(rsTemp) = 'OK'or rsTemp = 'NA') AND 
    (UPPER(rsCAMBack) = 'OK'or rsCAMBack = 'NA') AND 
    (UPPER(rsCAMFront) = 'OK' or rsCAMFront = 'NA')) THEN
        SET rsTotal = 'OK';
    ELSE
        SET rsTotal = 'NG';
    END IF;
    SELECT rsVP AS JudgeVP, rsGAS AS JudgeGAS, rsWI1START AS JudgeWI1START, rsWI1WITH AS JudgeWI1WITH, rsIP AS JudgeIP,
        rsDF AS JudgeDF, rsTemp AS JudgeTEMP, rsIOT AS JudgeIOT, rsPAN AS JudgePAN, rsWI2 AS JudgeWI2, 
        rsCAMBack AS JudgeCAMBACK, rsCAMFront AS JudgeCAMFRONT,
        rsTotal AS JudgeTotal , Reason as ReasonError,UserConfirm as UserConfirm;
 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertDataFinalCheck` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`TA`@`%` PROCEDURE `InsertDataFinalCheck`(
    IN p_CodeBack NVARCHAR(30),
    IN p_Judge_VP VARCHAR(8),
    IN p_Judge_GAS VARCHAR(8),
    IN p_Judge_WI1WITH VARCHAR(8),
    IN p_Judge_WI1START VARCHAR(8),
    IN p_Judge_IP VARCHAR(8),
    IN p_Judge_DF VARCHAR(8),
    IN p_Judge_TEMP VARCHAR(8),
    IN p_Judge_IOT VARCHAR(8),
    IN p_Judge_WI2 VARCHAR(8),
    IN p_Judge_PAN VARCHAR(8),
    IN p_Judge_CAMBACK VARCHAR(8),
    IN p_Judge_CAMFRONT VARCHAR(8),
    IN p_Judge_Total VARCHAR(8),
    IN p_ReasonError NVARCHAR(100),
    IN p_PersonConfirm NVARCHAR(50)
)
BEGIN
    IF NOT EXISTS (SELECT 1 FROM DataCheckFinal WHERE CodeBack = p_CodeBack) THEN
        INSERT INTO DataCheckFinal (
            CodeBack,
            Judge_VP,
            Judge_GAS,
            Judge_WI1WITH,
            Judge_WI1START,
            Judge_IP,
            Judge_DF,
            Judge_TEMP,
            Judge_IOT,
            Judge_WI2,
            Judge_PAN,
            Judge_CAMBACK,
            Judge_CAMFRONT,
            Judge_Total,
            ReasonError,
            PersonConfirm
        ) VALUES (
            p_CodeBack,
            p_Judge_VP,
            p_Judge_GAS,
            p_Judge_WI1WITH,
            p_Judge_WI1START,
            p_Judge_IP,
            p_Judge_DF,
            p_Judge_TEMP,
            p_Judge_IOT,
            p_Judge_WI2,
            p_Judge_PAN,
            p_Judge_CAMBACK,
            p_Judge_CAMFRONT,
            p_Judge_Total,
            p_ReasonError,
            p_PersonConfirm
        );
    ELSE
        UPDATE DataCheckFinal SET TimeUpdate = NOW() WHERE CodeBack = p_CodeBack;
    END IF;

    INSERT INTO DataCheckFinalDetail (
        CodeBack,
        Judge_VP,
        Judge_GAS,
        Judge_WI1WITH,
        Judge_WI1START,
        Judge_IP,
        Judge_DF,
        Judge_TEMP,
        Judge_IOT,
        Judge_WI2,
        Judge_PAN,
        Judge_CAMBACK,
        Judge_CAMFRONT,
        Judge_Total,
        ReasonError,
        PersonConfirm
    ) VALUES (
        p_CodeBack,
        p_Judge_VP,
        p_Judge_GAS,
        p_Judge_WI1WITH,
        p_Judge_WI1START,
        p_Judge_IP,
        p_Judge_DF,
        p_Judge_TEMP,
        p_Judge_IOT,
        p_Judge_WI2,
        p_Judge_PAN,
        p_Judge_CAMBACK,
        p_Judge_CAMFRONT,
        p_Judge_Total,
        p_ReasonError,
        p_PersonConfirm
    );

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `LoadDataForChart` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`TA`@`%` PROCEDURE `LoadDataForChart`(IN p_selectionItem VARCHAR(3))
BEGIN
	DECLARE _hournow int;
    Set _hournow = hour(now());
	IF(p_selectionItem = '1') THEN
		if(_hournow>5 and _hournow < 14) then
        SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		SELECT
        SUM(CASE WHEN Judge_VP = 'OK' THEN 1 ELSE 0 END) as VPOK,
        SUM(CASE WHEN Judge_GAS = 'OK' THEN 1 ELSE 0 END) as GASOILOK,
        SUM(CASE WHEN Judge_WI1WITH = 'OK' THEN 1 ELSE 0 END) as WI1WITHOK,
        SUM(CASE WHEN Judge_WI1START = 'OK' THEN 1 ELSE 0 END) as WI1STARTOK,
        SUM(CASE WHEN Judge_IP = 'OK' THEN 1 ELSE 0 END) as IPOK,
        SUM(CASE WHEN Judge_DF = 'OK' THEN 1 ELSE 0 END) as DFOK,
        SUM(CASE WHEN Judge_TEMP = 'OK' THEN 1 ELSE 0 END) as TEMPOK,
        SUM(CASE WHEN Judge_IOT = 'OK' THEN 1 ELSE 0 END) as IOTOK,
        SUM(CASE WHEN Judge_WI2 = 'OK' THEN 1 ELSE 0 END) as WI2OK,
        SUM(CASE WHEN Judge_PAN = 'OK' THEN 1 ELSE 0 END) as PANOK,
        SUM(CASE WHEN Judge_CAMBACK = 'OK' THEN 1 ELSE 0 END) as CAMBACKOK,
        SUM(CASE WHEN Judge_CAMFRONT = 'OK' THEN 1 ELSE 0 END) as CAMFRONTOK,

        SUM(CASE WHEN Judge_VP = 'NG' THEN 1 ELSE 0 END) as VPNG,
        SUM(CASE WHEN Judge_GAS = 'NG' THEN 1 ELSE 0 END) as GASOILNG,
        SUM(CASE WHEN Judge_WI1WITH = 'NG' THEN 1 ELSE 0 END) as WI1WITHNG,
        SUM(CASE WHEN Judge_WI1START = 'NG' THEN 1 ELSE 0 END) as WI1STARTNG,
        SUM(CASE WHEN Judge_IP = 'NG' THEN 1 ELSE 0 END) as IPNG,
        SUM(CASE WHEN Judge_DF = 'NG' THEN 1 ELSE 0 END) as DFNG,
        SUM(CASE WHEN Judge_TEMP = 'NG' THEN 1 ELSE 0 END) as TEMPNG,
        SUM(CASE WHEN Judge_IOT = 'NG' THEN 1 ELSE 0 END) as IOTNG,
        SUM(CASE WHEN Judge_WI2 = 'NG' THEN 1 ELSE 0 END) as WI2NG,
        SUM(CASE WHEN Judge_PAN = 'NG' THEN 1 ELSE 0 END) as PANNG,
        SUM(CASE WHEN Judge_CAMBACK = 'NG' THEN 1 ELSE 0 END) as CAMBACKNG,
        SUM(CASE WHEN Judge_CAMFRONT = 'NG' THEN 1 ELSE 0 END) as CAMFRONTNG,

        SUM(CASE WHEN Judge_VP = 'PD' THEN 1 ELSE 0 END) as VPPENDING,
        SUM(CASE WHEN Judge_GAS = 'PD' THEN 1 ELSE 0 END) as GASOILPENDING,
        SUM(CASE WHEN Judge_WI1WITH = 'PD' THEN 1 ELSE 0 END) as WI1WITHPENDING,
        SUM(CASE WHEN Judge_WI1START = 'PD' THEN 1 ELSE 0 END) as WI1STARTPENDING,
        SUM(CASE WHEN Judge_IP = 'PD' THEN 1 ELSE 0 END) as IPPENDING,
        SUM(CASE WHEN Judge_DF = 'PD' THEN 1 ELSE 0 END) as DFPENDING,
        SUM(CASE WHEN Judge_TEMP = 'PD' THEN 1 ELSE 0 END) as TEMPPENDING,
        SUM(CASE WHEN Judge_IOT = 'PD' THEN 1 ELSE 0 END) as IOTPENDING,
        SUM(CASE WHEN Judge_WI2 = 'PD' THEN 1 ELSE 0 END) as WI2PENDING,
        SUM(CASE WHEN Judge_PAN = 'PD' THEN 1 ELSE 0 END) as PANPENDING,
        SUM(CASE WHEN Judge_CAMBACK = 'PD' THEN 1 ELSE 0 END) as CAMBACKPENDING,
        SUM(CASE WHEN Judge_CAMFRONT = 'PD' THEN 1 ELSE 0 END) as CAMFRONTPENDING,

        SUM(CASE WHEN Judge_Total = 'OK' THEN 1 ELSE 0 END) as TotalOK,
        SUM(CASE WHEN Judge_Total = 'NG' THEN 1 ELSE 0 END) as TotalNG

		FROM DataCheckFinal where Date(TimeUpdate) = curdate() and hour(TimeUpdate)>5 and hour(TimeUpdate)<14;
		elseif(_hournow> 13 and _hournow < 22) then
		SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		SELECT
        SUM(CASE WHEN Judge_VP = 'OK' THEN 1 ELSE 0 END) as VPOK,
        SUM(CASE WHEN Judge_GAS = 'OK' THEN 1 ELSE 0 END) as GASOILOK,
        SUM(CASE WHEN Judge_WI1WITH = 'OK' THEN 1 ELSE 0 END) as WI1WITHOK,
        SUM(CASE WHEN Judge_WI1START = 'OK' THEN 1 ELSE 0 END) as WI1STARTOK,
        SUM(CASE WHEN Judge_IP = 'OK' THEN 1 ELSE 0 END) as IPOK,
        SUM(CASE WHEN Judge_DF = 'OK' THEN 1 ELSE 0 END) as DFOK,
        SUM(CASE WHEN Judge_TEMP = 'OK' THEN 1 ELSE 0 END) as TEMPOK,
        SUM(CASE WHEN Judge_IOT = 'OK' THEN 1 ELSE 0 END) as IOTOK,
        SUM(CASE WHEN Judge_WI2 = 'OK' THEN 1 ELSE 0 END) as WI2OK,
        SUM(CASE WHEN Judge_PAN = 'OK' THEN 1 ELSE 0 END) as PANOK,
        SUM(CASE WHEN Judge_CAMBACK = 'OK' THEN 1 ELSE 0 END) as CAMBACKOK,
        SUM(CASE WHEN Judge_CAMFRONT = 'OK' THEN 1 ELSE 0 END) as CAMFRONTOK,

        SUM(CASE WHEN Judge_VP = 'NG' THEN 1 ELSE 0 END) as VPNG,
        SUM(CASE WHEN Judge_GAS = 'NG' THEN 1 ELSE 0 END) as GASOILNG,
        SUM(CASE WHEN Judge_WI1WITH = 'NG' THEN 1 ELSE 0 END) as WI1WITHNG,
        SUM(CASE WHEN Judge_WI1START = 'NG' THEN 1 ELSE 0 END) as WI1STARTNG,
        SUM(CASE WHEN Judge_IP = 'NG' THEN 1 ELSE 0 END) as IPNG,
        SUM(CASE WHEN Judge_DF = 'NG' THEN 1 ELSE 0 END) as DFNG,
        SUM(CASE WHEN Judge_TEMP = 'NG' THEN 1 ELSE 0 END) as TEMPNG,
        SUM(CASE WHEN Judge_IOT = 'NG' THEN 1 ELSE 0 END) as IOTNG,
        SUM(CASE WHEN Judge_WI2 = 'NG' THEN 1 ELSE 0 END) as WI2NG,
        SUM(CASE WHEN Judge_PAN = 'NG' THEN 1 ELSE 0 END) as PANNG,
        SUM(CASE WHEN Judge_CAMBACK = 'NG' THEN 1 ELSE 0 END) as CAMBACKNG,
        SUM(CASE WHEN Judge_CAMFRONT = 'NG' THEN 1 ELSE 0 END) as CAMFRONTNG,

        SUM(CASE WHEN Judge_VP = 'PD' THEN 1 ELSE 0 END) as VPPENDING,
        SUM(CASE WHEN Judge_GAS = 'PD' THEN 1 ELSE 0 END) as GASOILPENDING,
        SUM(CASE WHEN Judge_WI1WITH = 'PD' THEN 1 ELSE 0 END) as WI1WITHPENDING,
        SUM(CASE WHEN Judge_WI1START = 'PD' THEN 1 ELSE 0 END) as WI1STARTPENDING,
        SUM(CASE WHEN Judge_IP = 'PD' THEN 1 ELSE 0 END) as IPPENDING,
        SUM(CASE WHEN Judge_DF = 'PD' THEN 1 ELSE 0 END) as DFPENDING,
        SUM(CASE WHEN Judge_TEMP = 'PD' THEN 1 ELSE 0 END) as TEMPPENDING,
        SUM(CASE WHEN Judge_IOT = 'PD' THEN 1 ELSE 0 END) as IOTPENDING,
        SUM(CASE WHEN Judge_WI2 = 'PD' THEN 1 ELSE 0 END) as WI2PENDING,
        SUM(CASE WHEN Judge_PAN = 'PD' THEN 1 ELSE 0 END) as PANPENDING,
        SUM(CASE WHEN Judge_CAMBACK = 'PD' THEN 1 ELSE 0 END) as CAMBACKPENDING,
        SUM(CASE WHEN Judge_CAMFRONT = 'PD' THEN 1 ELSE 0 END) as CAMFRONTPENDING,

        SUM(CASE WHEN Judge_Total = 'OK' THEN 1 ELSE 0 END) as TotalOK,
        SUM(CASE WHEN Judge_Total = 'NG' THEN 1 ELSE 0 END) as TotalNG

    FROM DataCheckFinal where Date(TimeUpdate) = curdate() and hour(TimeUpdate)>13 and hour(TimeUpdate)<22;
    else
		if(_hournow >21) THEN
					SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		SELECT
        SUM(CASE WHEN Judge_VP = 'OK' THEN 1 ELSE 0 END) as VPOK,
        SUM(CASE WHEN Judge_GAS = 'OK' THEN 1 ELSE 0 END) as GASOILOK,
        SUM(CASE WHEN Judge_WI1WITH = 'OK' THEN 1 ELSE 0 END) as WI1WITHOK,
        SUM(CASE WHEN Judge_WI1START = 'OK' THEN 1 ELSE 0 END) as WI1STARTOK,
        SUM(CASE WHEN Judge_IP = 'OK' THEN 1 ELSE 0 END) as IPOK,
        SUM(CASE WHEN Judge_DF = 'OK' THEN 1 ELSE 0 END) as DFOK,
        SUM(CASE WHEN Judge_TEMP = 'OK' THEN 1 ELSE 0 END) as TEMPOK,
        SUM(CASE WHEN Judge_IOT = 'OK' THEN 1 ELSE 0 END) as IOTOK,
        SUM(CASE WHEN Judge_WI2 = 'OK' THEN 1 ELSE 0 END) as WI2OK,
        SUM(CASE WHEN Judge_PAN = 'OK' THEN 1 ELSE 0 END) as PANOK,
        SUM(CASE WHEN Judge_CAMBACK = 'OK' THEN 1 ELSE 0 END) as CAMBACKOK,
        SUM(CASE WHEN Judge_CAMFRONT = 'OK' THEN 1 ELSE 0 END) as CAMFRONTOK,

        SUM(CASE WHEN Judge_VP = 'NG' THEN 1 ELSE 0 END) as VPNG,
        SUM(CASE WHEN Judge_GAS = 'NG' THEN 1 ELSE 0 END) as GASOILNG,
        SUM(CASE WHEN Judge_WI1WITH = 'NG' THEN 1 ELSE 0 END) as WI1WITHNG,
        SUM(CASE WHEN Judge_WI1START = 'NG' THEN 1 ELSE 0 END) as WI1STARTNG,
        SUM(CASE WHEN Judge_IP = 'NG' THEN 1 ELSE 0 END) as IPNG,
        SUM(CASE WHEN Judge_DF = 'NG' THEN 1 ELSE 0 END) as DFNG,
        SUM(CASE WHEN Judge_TEMP = 'NG' THEN 1 ELSE 0 END) as TEMPNG,
        SUM(CASE WHEN Judge_IOT = 'NG' THEN 1 ELSE 0 END) as IOTNG,
        SUM(CASE WHEN Judge_WI2 = 'NG' THEN 1 ELSE 0 END) as WI2NG,
        SUM(CASE WHEN Judge_PAN = 'NG' THEN 1 ELSE 0 END) as PANNG,
        SUM(CASE WHEN Judge_CAMBACK = 'NG' THEN 1 ELSE 0 END) as CAMBACKNG,
        SUM(CASE WHEN Judge_CAMFRONT = 'NG' THEN 1 ELSE 0 END) as CAMFRONTNG,

        SUM(CASE WHEN Judge_VP = 'PD' THEN 1 ELSE 0 END) as VPPENDING,
        SUM(CASE WHEN Judge_GAS = 'PD' THEN 1 ELSE 0 END) as GASOILPENDING,
        SUM(CASE WHEN Judge_WI1WITH = 'PD' THEN 1 ELSE 0 END) as WI1WITHPENDING,
        SUM(CASE WHEN Judge_WI1START = 'PD' THEN 1 ELSE 0 END) as WI1STARTPENDING,
        SUM(CASE WHEN Judge_IP = 'PD' THEN 1 ELSE 0 END) as IPPENDING,
        SUM(CASE WHEN Judge_DF = 'PD' THEN 1 ELSE 0 END) as DFPENDING,
        SUM(CASE WHEN Judge_TEMP = 'PD' THEN 1 ELSE 0 END) as TEMPPENDING,
        SUM(CASE WHEN Judge_IOT = 'PD' THEN 1 ELSE 0 END) as IOTPENDING,
        SUM(CASE WHEN Judge_WI2 = 'PD' THEN 1 ELSE 0 END) as WI2PENDING,
        SUM(CASE WHEN Judge_PAN = 'PD' THEN 1 ELSE 0 END) as PANPENDING,
        SUM(CASE WHEN Judge_CAMBACK = 'PD' THEN 1 ELSE 0 END) as CAMBACKPENDING,
        SUM(CASE WHEN Judge_CAMFRONT = 'PD' THEN 1 ELSE 0 END) as CAMFRONTPENDING,

        SUM(CASE WHEN Judge_Total = 'OK' THEN 1 ELSE 0 END) as TotalOK,
        SUM(CASE WHEN Judge_Total = 'NG' THEN 1 ELSE 0 END) as TotalNG

	FROM DataCheckFinal where Date(TimeUpdate) = curdate() and hour(TimeUpdate)> 21;
   
	ELSE
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		SELECT
        SUM(CASE WHEN Judge_VP = 'OK' THEN 1 ELSE 0 END) as VPOK,
        SUM(CASE WHEN Judge_GAS = 'OK' THEN 1 ELSE 0 END) as GASOILOK,
        SUM(CASE WHEN Judge_WI1WITH = 'OK' THEN 1 ELSE 0 END) as WI1WITHOK,
        SUM(CASE WHEN Judge_WI1START = 'OK' THEN 1 ELSE 0 END) as WI1STARTOK,
        SUM(CASE WHEN Judge_IP = 'OK' THEN 1 ELSE 0 END) as IPOK,
        SUM(CASE WHEN Judge_DF = 'OK' THEN 1 ELSE 0 END) as DFOK,
        SUM(CASE WHEN Judge_TEMP = 'OK' THEN 1 ELSE 0 END) as TEMPOK,
        SUM(CASE WHEN Judge_IOT = 'OK' THEN 1 ELSE 0 END) as IOTOK,
        SUM(CASE WHEN Judge_WI2 = 'OK' THEN 1 ELSE 0 END) as WI2OK,
        SUM(CASE WHEN Judge_PAN = 'OK' THEN 1 ELSE 0 END) as PANOK,
        SUM(CASE WHEN Judge_CAMBACK = 'OK' THEN 1 ELSE 0 END) as CAMBACKOK,
        SUM(CASE WHEN Judge_CAMFRONT = 'OK' THEN 1 ELSE 0 END) as CAMFRONTOK,

        SUM(CASE WHEN Judge_VP = 'NG' THEN 1 ELSE 0 END) as VPNG,
        SUM(CASE WHEN Judge_GAS = 'NG' THEN 1 ELSE 0 END) as GASOILNG,
        SUM(CASE WHEN Judge_WI1WITH = 'NG' THEN 1 ELSE 0 END) as WI1WITHNG,
        SUM(CASE WHEN Judge_WI1START = 'NG' THEN 1 ELSE 0 END) as WI1STARTNG,
        SUM(CASE WHEN Judge_IP = 'NG' THEN 1 ELSE 0 END) as IPNG,
        SUM(CASE WHEN Judge_DF = 'NG' THEN 1 ELSE 0 END) as DFNG,
        SUM(CASE WHEN Judge_TEMP = 'NG' THEN 1 ELSE 0 END) as TEMPNG,
        SUM(CASE WHEN Judge_IOT = 'NG' THEN 1 ELSE 0 END) as IOTNG,
        SUM(CASE WHEN Judge_WI2 = 'NG' THEN 1 ELSE 0 END) as WI2NG,
        SUM(CASE WHEN Judge_PAN = 'NG' THEN 1 ELSE 0 END) as PANNG,
        SUM(CASE WHEN Judge_CAMBACK = 'NG' THEN 1 ELSE 0 END) as CAMBACKNG,
        SUM(CASE WHEN Judge_CAMFRONT = 'NG' THEN 1 ELSE 0 END) as CAMFRONTNG,

        SUM(CASE WHEN Judge_VP = 'PD' THEN 1 ELSE 0 END) as VPPENDING,
        SUM(CASE WHEN Judge_GAS = 'PD' THEN 1 ELSE 0 END) as GASOILPENDING,
        SUM(CASE WHEN Judge_WI1WITH = 'PD' THEN 1 ELSE 0 END) as WI1WITHPENDING,
        SUM(CASE WHEN Judge_WI1START = 'PD' THEN 1 ELSE 0 END) as WI1STARTPENDING,
        SUM(CASE WHEN Judge_IP = 'PD' THEN 1 ELSE 0 END) as IPPENDING,
        SUM(CASE WHEN Judge_DF = 'PD' THEN 1 ELSE 0 END) as DFPENDING,
        SUM(CASE WHEN Judge_TEMP = 'PD' THEN 1 ELSE 0 END) as TEMPPENDING,
        SUM(CASE WHEN Judge_IOT = 'PD' THEN 1 ELSE 0 END) as IOTPENDING,
        SUM(CASE WHEN Judge_WI2 = 'PD' THEN 1 ELSE 0 END) as WI2PENDING,
        SUM(CASE WHEN Judge_PAN = 'PD' THEN 1 ELSE 0 END) as PANPENDING,
        SUM(CASE WHEN Judge_CAMBACK = 'PD' THEN 1 ELSE 0 END) as CAMBACKPENDING,
        SUM(CASE WHEN Judge_CAMFRONT = 'PD' THEN 1 ELSE 0 END) as CAMFRONTPENDING,

        SUM(CASE WHEN Judge_Total = 'OK' THEN 1 ELSE 0 END) as TotalOK,
        SUM(CASE WHEN Judge_Total = 'NG' THEN 1 ELSE 0 END) as TotalNG

	FROM DataCheckFinal where (Date(TimeUpdate) = curdate() and hour(TimeUpdate)>= 0 AND hour(TimeUpdate) < 6) or (DATE_SUB(CURDATE(), INTERVAL 1 DAY) AND hour(TimeUpdate)> 21);
        END IF;
    end if;
    ELSE
		IF(_hournow > 5) then
		SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		SELECT
        SUM(CASE WHEN Judge_VP = 'OK' THEN 1 ELSE 0 END) as VPOK,
        SUM(CASE WHEN Judge_GAS = 'OK' THEN 1 ELSE 0 END) as GASOILOK,
        SUM(CASE WHEN Judge_WI1WITH = 'OK' THEN 1 ELSE 0 END) as WI1WITHOK,
        SUM(CASE WHEN Judge_WI1START = 'OK' THEN 1 ELSE 0 END) as WI1STARTOK,
        SUM(CASE WHEN Judge_IP = 'OK' THEN 1 ELSE 0 END) as IPOK,
        SUM(CASE WHEN Judge_DF = 'OK' THEN 1 ELSE 0 END) as DFOK,
        SUM(CASE WHEN Judge_TEMP = 'OK' THEN 1 ELSE 0 END) as TEMPOK,
        SUM(CASE WHEN Judge_IOT = 'OK' THEN 1 ELSE 0 END) as IOTOK,
        SUM(CASE WHEN Judge_WI2 = 'OK' THEN 1 ELSE 0 END) as WI2OK,
        SUM(CASE WHEN Judge_PAN = 'OK' THEN 1 ELSE 0 END) as PANOK,
        SUM(CASE WHEN Judge_CAMBACK = 'OK' THEN 1 ELSE 0 END) as CAMBACKOK,
        SUM(CASE WHEN Judge_CAMFRONT = 'OK' THEN 1 ELSE 0 END) as CAMFRONTOK,

        SUM(CASE WHEN Judge_VP = 'NG' THEN 1 ELSE 0 END) as VPNG,
        SUM(CASE WHEN Judge_GAS = 'NG' THEN 1 ELSE 0 END) as GASOILNG,
        SUM(CASE WHEN Judge_WI1WITH = 'NG' THEN 1 ELSE 0 END) as WI1WITHNG,
        SUM(CASE WHEN Judge_WI1START = 'NG' THEN 1 ELSE 0 END) as WI1STARTNG,
        SUM(CASE WHEN Judge_IP = 'NG' THEN 1 ELSE 0 END) as IPNG,
        SUM(CASE WHEN Judge_DF = 'NG' THEN 1 ELSE 0 END) as DFNG,
        SUM(CASE WHEN Judge_TEMP = 'NG' THEN 1 ELSE 0 END) as TEMPNG,
        SUM(CASE WHEN Judge_IOT = 'NG' THEN 1 ELSE 0 END) as IOTNG,
        SUM(CASE WHEN Judge_WI2 = 'NG' THEN 1 ELSE 0 END) as WI2NG,
        SUM(CASE WHEN Judge_PAN = 'NG' THEN 1 ELSE 0 END) as PANNG,
        SUM(CASE WHEN Judge_CAMBACK = 'NG' THEN 1 ELSE 0 END) as CAMBACKNG,
        SUM(CASE WHEN Judge_CAMFRONT = 'NG' THEN 1 ELSE 0 END) as CAMFRONTNG,

        SUM(CASE WHEN Judge_VP = 'PD' THEN 1 ELSE 0 END) as VPPENDING,
        SUM(CASE WHEN Judge_GAS = 'PD' THEN 1 ELSE 0 END) as GASOILPENDING,
        SUM(CASE WHEN Judge_WI1WITH = 'PD' THEN 1 ELSE 0 END) as WI1WITHPENDING,
        SUM(CASE WHEN Judge_WI1START = 'PD' THEN 1 ELSE 0 END) as WI1STARTPENDING,
        SUM(CASE WHEN Judge_IP = 'PD' THEN 1 ELSE 0 END) as IPPENDING,
        SUM(CASE WHEN Judge_DF = 'PD' THEN 1 ELSE 0 END) as DFPENDING,
        SUM(CASE WHEN Judge_TEMP = 'PD' THEN 1 ELSE 0 END) as TEMPPENDING,
        SUM(CASE WHEN Judge_IOT = 'PD' THEN 1 ELSE 0 END) as IOTPENDING,
        SUM(CASE WHEN Judge_WI2 = 'PD' THEN 1 ELSE 0 END) as WI2PENDING,
        SUM(CASE WHEN Judge_PAN = 'PD' THEN 1 ELSE 0 END) as PANPENDING,
        SUM(CASE WHEN Judge_CAMBACK = 'PD' THEN 1 ELSE 0 END) as CAMBACKPENDING,
        SUM(CASE WHEN Judge_CAMFRONT = 'PD' THEN 1 ELSE 0 END) as CAMFRONTPENDING,

        SUM(CASE WHEN Judge_Total = 'OK' THEN 1 ELSE 0 END) as TotalOK,
        SUM(CASE WHEN Judge_Total = 'NG' THEN 1 ELSE 0 END) as TotalNG

    FROM DataCheckFinal WHERE  Date(TimeUpdate) = curdate() and hour(TimeUpdate)>5 ;
    else
		SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		SELECT
        SUM(CASE WHEN Judge_VP = 'OK' THEN 1 ELSE 0 END) as VPOK,
        SUM(CASE WHEN Judge_GAS = 'OK' THEN 1 ELSE 0 END) as GASOILOK,
        SUM(CASE WHEN Judge_WI1WITH = 'OK' THEN 1 ELSE 0 END) as WI1WITHOK,
        SUM(CASE WHEN Judge_WI1START = 'OK' THEN 1 ELSE 0 END) as WI1STARTOK,
        SUM(CASE WHEN Judge_IP = 'OK' THEN 1 ELSE 0 END) as IPOK,
        SUM(CASE WHEN Judge_DF = 'OK' THEN 1 ELSE 0 END) as DFOK,
        SUM(CASE WHEN Judge_TEMP = 'OK' THEN 1 ELSE 0 END) as TEMPOK,
        SUM(CASE WHEN Judge_IOT = 'OK' THEN 1 ELSE 0 END) as IOTOK,
        SUM(CASE WHEN Judge_WI2 = 'OK' THEN 1 ELSE 0 END) as WI2OK,
        SUM(CASE WHEN Judge_PAN = 'OK' THEN 1 ELSE 0 END) as PANOK,
        SUM(CASE WHEN Judge_CAMBACK = 'OK' THEN 1 ELSE 0 END) as CAMBACKOK,
        SUM(CASE WHEN Judge_CAMFRONT = 'OK' THEN 1 ELSE 0 END) as CAMFRONTOK,

        SUM(CASE WHEN Judge_VP = 'NG' THEN 1 ELSE 0 END) as VPNG,
        SUM(CASE WHEN Judge_GAS = 'NG' THEN 1 ELSE 0 END) as GASOILNG,
        SUM(CASE WHEN Judge_WI1WITH = 'NG' THEN 1 ELSE 0 END) as WI1WITHNG,
        SUM(CASE WHEN Judge_WI1START = 'NG' THEN 1 ELSE 0 END) as WI1STARTNG,
        SUM(CASE WHEN Judge_IP = 'NG' THEN 1 ELSE 0 END) as IPNG,
        SUM(CASE WHEN Judge_DF = 'NG' THEN 1 ELSE 0 END) as DFNG,
        SUM(CASE WHEN Judge_TEMP = 'NG' THEN 1 ELSE 0 END) as TEMPNG,
        SUM(CASE WHEN Judge_IOT = 'NG' THEN 1 ELSE 0 END) as IOTNG,
        SUM(CASE WHEN Judge_WI2 = 'NG' THEN 1 ELSE 0 END) as WI2NG,
        SUM(CASE WHEN Judge_PAN = 'NG' THEN 1 ELSE 0 END) as PANNG,
        SUM(CASE WHEN Judge_CAMBACK = 'NG' THEN 1 ELSE 0 END) as CAMBACKNG,
        SUM(CASE WHEN Judge_CAMFRONT = 'NG' THEN 1 ELSE 0 END) as CAMFRONTNG,

        SUM(CASE WHEN Judge_VP = 'PD' THEN 1 ELSE 0 END) as VPPENDING,
        SUM(CASE WHEN Judge_GAS = 'PD' THEN 1 ELSE 0 END) as GASOILPENDING,
        SUM(CASE WHEN Judge_WI1WITH = 'PD' THEN 1 ELSE 0 END) as WI1WITHPENDING,
        SUM(CASE WHEN Judge_WI1START = 'PD' THEN 1 ELSE 0 END) as WI1STARTPENDING,
        SUM(CASE WHEN Judge_IP = 'PD' THEN 1 ELSE 0 END) as IPPENDING,
        SUM(CASE WHEN Judge_DF = 'PD' THEN 1 ELSE 0 END) as DFPENDING,
        SUM(CASE WHEN Judge_TEMP = 'PD' THEN 1 ELSE 0 END) as TEMPPENDING,
        SUM(CASE WHEN Judge_IOT = 'PD' THEN 1 ELSE 0 END) as IOTPENDING,
        SUM(CASE WHEN Judge_WI2 = 'PD' THEN 1 ELSE 0 END) as WI2PENDING,
        SUM(CASE WHEN Judge_PAN = 'PD' THEN 1 ELSE 0 END) as PANPENDING,
        SUM(CASE WHEN Judge_CAMBACK = 'PD' THEN 1 ELSE 0 END) as CAMBACKPENDING,
        SUM(CASE WHEN Judge_CAMFRONT = 'PD' THEN 1 ELSE 0 END) as CAMFRONTPENDING,

        SUM(CASE WHEN Judge_Total = 'OK' THEN 1 ELSE 0 END) as TotalOK,
        SUM(CASE WHEN Judge_Total = 'NG' THEN 1 ELSE 0 END) as TotalNG

	FROM DataCheckFinal where (Date(TimeUpdate) = curdate() and hour(TimeUpdate)>= 0 AND hour(TimeUpdate) < 6) or (DATE_SUB(CURDATE(), INTERVAL 1 DAY) AND hour(TimeUpdate)> 5);
    END IF;
END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `LoadDataForChartHistory` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`TA`@`%` PROCEDURE `LoadDataForChartHistory`(IN DateTimeFrom DATETIME,
IN DateTimeTo DATETIME)
BEGIN
	SELECT
        SUM(CASE WHEN Judge_VP = 'OK' THEN 1 ELSE 0 END) as VPOK,
        SUM(CASE WHEN Judge_GAS = 'OK' THEN 1 ELSE 0 END) as GASOILOK,
        SUM(CASE WHEN Judge_WI1WITH = 'OK' THEN 1 ELSE 0 END) as WI1WITHOK,
        SUM(CASE WHEN Judge_WI1START = 'OK' THEN 1 ELSE 0 END) as WI1STARTOK,
        SUM(CASE WHEN Judge_IP = 'OK' THEN 1 ELSE 0 END) as IPOK,
        SUM(CASE WHEN Judge_DF = 'OK' THEN 1 ELSE 0 END) as DFOK,
        SUM(CASE WHEN Judge_TEMP = 'OK' THEN 1 ELSE 0 END) as TEMPOK,
        SUM(CASE WHEN Judge_IOT = 'OK' THEN 1 ELSE 0 END) as IOTOK,
        SUM(CASE WHEN Judge_WI2 = 'OK' THEN 1 ELSE 0 END) as WI2OK,
        SUM(CASE WHEN Judge_PAN = 'OK' THEN 1 ELSE 0 END) as PANOK,
        SUM(CASE WHEN Judge_CAMBACK = 'OK' THEN 1 ELSE 0 END) as CAMBACKOK,
        SUM(CASE WHEN Judge_CAMFRONT = 'OK' THEN 1 ELSE 0 END) as CAMFRONTOK,

        SUM(CASE WHEN Judge_VP = 'NG' THEN 1 ELSE 0 END) as VPNG,
        SUM(CASE WHEN Judge_GAS = 'NG' THEN 1 ELSE 0 END) as GASOILNG,
        SUM(CASE WHEN Judge_WI1WITH = 'NG' THEN 1 ELSE 0 END) as WI1WITHNG,
        SUM(CASE WHEN Judge_WI1START = 'NG' THEN 1 ELSE 0 END) as WI1STARTNG,
        SUM(CASE WHEN Judge_IP = 'NG' THEN 1 ELSE 0 END) as IPNG,
        SUM(CASE WHEN Judge_DF = 'NG' THEN 1 ELSE 0 END) as DFNG,
        SUM(CASE WHEN Judge_TEMP = 'NG' THEN 1 ELSE 0 END) as TEMPNG,
        SUM(CASE WHEN Judge_IOT = 'NG' THEN 1 ELSE 0 END) as IOTNG,
        SUM(CASE WHEN Judge_WI2 = 'NG' THEN 1 ELSE 0 END) as WI2NG,
        SUM(CASE WHEN Judge_PAN = 'NG' THEN 1 ELSE 0 END) as PANNG,
        SUM(CASE WHEN Judge_CAMBACK = 'NG' THEN 1 ELSE 0 END) as CAMBACKNG,
        SUM(CASE WHEN Judge_CAMFRONT = 'NG' THEN 1 ELSE 0 END) as CAMFRONTNG,

        SUM(CASE WHEN Judge_VP = 'PD' THEN 1 ELSE 0 END) as VPPENDING,
        SUM(CASE WHEN Judge_GAS = 'PD' THEN 1 ELSE 0 END) as GASOILPENDING,
        SUM(CASE WHEN Judge_WI1WITH = 'PD' THEN 1 ELSE 0 END) as WI1WITHPENDING,
        SUM(CASE WHEN Judge_WI1START = 'PD' THEN 1 ELSE 0 END) as WI1STARTPENDING,
        SUM(CASE WHEN Judge_IP = 'PD' THEN 1 ELSE 0 END) as IPPENDING,
        SUM(CASE WHEN Judge_DF = 'PD' THEN 1 ELSE 0 END) as DFPENDING,
        SUM(CASE WHEN Judge_TEMP = 'PD' THEN 1 ELSE 0 END) as TEMPPENDING,
        SUM(CASE WHEN Judge_IOT = 'PD' THEN 1 ELSE 0 END) as IOTPENDING,
        SUM(CASE WHEN Judge_WI2 = 'PD' THEN 1 ELSE 0 END) as WI2PENDING,
        SUM(CASE WHEN Judge_PAN = 'PD' THEN 1 ELSE 0 END) as PANPENDING,
        SUM(CASE WHEN Judge_CAMBACK = 'PD' THEN 1 ELSE 0 END) as CAMBACKPENDING,
        SUM(CASE WHEN Judge_CAMFRONT = 'PD' THEN 1 ELSE 0 END) as CAMFRONTPENDING,

        SUM(CASE WHEN Judge_Total = 'OK' THEN 1 ELSE 0 END) as TotalOK,
        SUM(CASE WHEN Judge_Total = 'NG' THEN 1 ELSE 0 END) as TotalNG
		FROM DataCheckFinal where TimeUpdate Between DateTimeFrom AND DateTimeTo;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `LoadDataForTableHistory` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`TA`@`%` PROCEDURE `LoadDataForTableHistory`()
BEGIN
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
    SELECT CodeBack, Judge_Total, TimeUpdate
    FROM DataCheckFinal
    ORDER BY TimeUpdate DESC
    LIMIT 50;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `LoadDataForTableHistoryTrace` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`TA`@`%` PROCEDURE `LoadDataForTableHistoryTrace`(
    datetimefrom VARCHAR(30),
    datetimeto VARCHAR(30),
    namecabi VARCHAR(30)
)
BEGIN
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
    IF (CHAR_LENGTH(datetimefrom) > 5 AND CHAR_LENGTH(datetimeto) > 5 AND CHAR_LENGTH(namecabi) >= 19) THEN
        SELECT CodeBack, Judge_Total, TimeUpdate
        FROM DataCheckFinal
        WHERE CodeBack = namecabi AND TimeUpdate BETWEEN STR_TO_DATE(datetimefrom, '%Y-%m-%d %H:%i:%s') AND STR_TO_DATE(datetimeto, '%Y-%m-%d %H:%i:%s');
    ELSEIF (CHAR_LENGTH(datetimefrom) > 5 AND CHAR_LENGTH(datetimeto) > 5) THEN
        SELECT CodeBack, Judge_Total, TimeUpdate
        FROM DataCheckFinal
        WHERE TimeUpdate BETWEEN STR_TO_DATE(datetimefrom, '%Y-%m-%d %H:%i:%s') AND STR_TO_DATE(datetimeto, '%Y-%m-%d %H:%i:%s');
    ELSEIF (CHAR_LENGTH(namecabi) >= 19) THEN
        SELECT CodeBack, Judge_Total, TimeUpdate
        FROM DataCheckFinal
        WHERE CodeBack = namecabi;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `new_procedure` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`TA`@`%` PROCEDURE `new_procedure`(IN DateTimeFrom DATETIME,
IN DateTimeTo DATETIME)
BEGIN
	SELECT
        SUM(CASE WHEN Judge_VP = 'OK' THEN 1 ELSE 0 END) as VPOK,
        SUM(CASE WHEN Judge_GAS = 'OK' THEN 1 ELSE 0 END) as GASOILOK,
        SUM(CASE WHEN Judge_WI1WITH = 'OK' THEN 1 ELSE 0 END) as WI1WITHOK,
        SUM(CASE WHEN Judge_WI1START = 'OK' THEN 1 ELSE 0 END) as WI1STARTOK,
        SUM(CASE WHEN Judge_IP = 'OK' THEN 1 ELSE 0 END) as IPOK,
        SUM(CASE WHEN Judge_DF = 'OK' THEN 1 ELSE 0 END) as DFOK,
        SUM(CASE WHEN Judge_TEMP = 'OK' THEN 1 ELSE 0 END) as TEMPOK,
        SUM(CASE WHEN Judge_IOT = 'OK' THEN 1 ELSE 0 END) as IOTOK,
        SUM(CASE WHEN Judge_WI2 = 'OK' THEN 1 ELSE 0 END) as WI2OK,
        SUM(CASE WHEN Judge_PAN = 'OK' THEN 1 ELSE 0 END) as PANOK,
        SUM(CASE WHEN Judge_CAMBACK = 'OK' THEN 1 ELSE 0 END) as CAMBACKOK,
        SUM(CASE WHEN Judge_CAMFRONT = 'OK' THEN 1 ELSE 0 END) as CAMFRONTOK,

        SUM(CASE WHEN Judge_VP = 'NG' THEN 1 ELSE 0 END) as VPNG,
        SUM(CASE WHEN Judge_GAS = 'NG' THEN 1 ELSE 0 END) as GASOILNG,
        SUM(CASE WHEN Judge_WI1WITH = 'NG' THEN 1 ELSE 0 END) as WI1WITHNG,
        SUM(CASE WHEN Judge_WI1START = 'NG' THEN 1 ELSE 0 END) as WI1STARTNG,
        SUM(CASE WHEN Judge_IP = 'NG' THEN 1 ELSE 0 END) as IPNG,
        SUM(CASE WHEN Judge_DF = 'NG' THEN 1 ELSE 0 END) as DFNG,
        SUM(CASE WHEN Judge_TEMP = 'NG' THEN 1 ELSE 0 END) as TEMPNG,
        SUM(CASE WHEN Judge_IOT = 'NG' THEN 1 ELSE 0 END) as IOTNG,
        SUM(CASE WHEN Judge_WI2 = 'NG' THEN 1 ELSE 0 END) as WI2NG,
        SUM(CASE WHEN Judge_PAN = 'NG' THEN 1 ELSE 0 END) as PANNG,
        SUM(CASE WHEN Judge_CAMBACK = 'NG' THEN 1 ELSE 0 END) as CAMBACKNG,
        SUM(CASE WHEN Judge_CAMFRONT = 'NG' THEN 1 ELSE 0 END) as CAMFRONTNG,

        SUM(CASE WHEN Judge_VP = 'PD' THEN 1 ELSE 0 END) as VPPENDING,
        SUM(CASE WHEN Judge_GAS = 'PD' THEN 1 ELSE 0 END) as GASOILPENDING,
        SUM(CASE WHEN Judge_WI1WITH = 'PD' THEN 1 ELSE 0 END) as WI1WITHPENDING,
        SUM(CASE WHEN Judge_WI1START = 'PD' THEN 1 ELSE 0 END) as WI1STARTPENDING,
        SUM(CASE WHEN Judge_IP = 'PD' THEN 1 ELSE 0 END) as IPPENDING,
        SUM(CASE WHEN Judge_DF = 'PD' THEN 1 ELSE 0 END) as DFPENDING,
        SUM(CASE WHEN Judge_TEMP = 'PD' THEN 1 ELSE 0 END) as TEMPPENDING,
        SUM(CASE WHEN Judge_IOT = 'PD' THEN 1 ELSE 0 END) as IOTPENDING,
        SUM(CASE WHEN Judge_WI2 = 'PD' THEN 1 ELSE 0 END) as WI2PENDING,
        SUM(CASE WHEN Judge_PAN = 'PD' THEN 1 ELSE 0 END) as PANPENDING,
        SUM(CASE WHEN Judge_CAMBACK = 'PD' THEN 1 ELSE 0 END) as CAMBACKPENDING,
        SUM(CASE WHEN Judge_CAMFRONT = 'PD' THEN 1 ELSE 0 END) as CAMFRONTPENDING,

        SUM(CASE WHEN Judge_Total = 'OK' THEN 1 ELSE 0 END) as TotalOK,
        SUM(CASE WHEN Judge_Total = 'NG' THEN 1 ELSE 0 END) as TotalNG
		FROM DataCheckFinal where TimeUpdate Between DateTimeFrom AND DateTimeTo;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UpdateConfigConnectPlc` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
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
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UpdateDataFinalCheck` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`TA`@`%` PROCEDURE `UpdateDataFinalCheck`(
    IN p_CodeBack VARCHAR(30),
    IN p_ReasonError VARCHAR(100),
    IN p_PersonConfirm VARCHAR(50)
)
BEGIN
    UPDATE DataCheckFinal
    SET
        ReasonError = p_ReasonError,
        PersonConfirm = p_PersonConfirm
    WHERE CodeBack = p_CodeBack;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-12-23 15:34:43
