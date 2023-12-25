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
 
END