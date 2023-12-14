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
   

    -- Query for VP table
    SELECT Judge INTO rsVP FROM VP WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
	SELECT Judge INTO rsGAS FROM gas WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
      SELECT Judge INTO rsWI1WITH FROM wi1with WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
      SELECT Judge INTO rsWI1START FROM wi1start WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
      SELECT Judge INTO rsIP FROM  ip WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
      SELECT Judge INTO rsDF FROM  df WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
	SELECT Judge INTO rsTemp FROM  tempresult WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
   
   SELECT Judge INTO rsPAN FROM  pan WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
   SELECT Judge INTO rsWI2 FROM wi2  WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
   SELECT Judge INTO rsCAMBack FROM  camback WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
   SELECT Judge INTO rsCAMFront FROM camfront  WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
   
   
      SELECT ReasonError,PersonConfirm  INTO Reason, UserConfirm FROM DataCheckFinal where CodeBack = p_CodeModel  ORDER BY  TimeUpdate DESC LIMIT 1;

   IF(exists(select NameModel from modelcheckiot where NameModel = substring(p_CodeModel,1,12))) THEN
        SELECT Judge INTO rsIOT FROM  iot WHERE CodeBack = p_CodeModel ORDER BY TimePLC DESC LIMIT 1;
    ELSE
        SET rsIOT = 'NA';
    END IF;
   
   
   
IF(UPPER(rsVP) = 'OK' AND UPPER(rsGAS) = 'OK' AND UPPER(rsWI1START) = 'OK' AND UPPER(rsIP) = 'OK' AND UPPER(rsDF) = 'OK' AND UPPER(rsWI1WITH) = 'OK' AND UPPER(rsPAN) = 'OK' AND UPPER(rsWI2) = 'OK'
        AND (UPPER(rsIOT) = 'OK' or rsIOT = 'NA') AND UPPER(rsTemp) = 'OK' AND UPPER(rsCAMBack) = 'OK' AND UPPER(rsCAMFront) = 'OK') THEN
        SET rsTotal = 'OK';
    ELSE
        SET rsTotal = 'NG';
    END IF;
    SELECT rsVP AS JudgeVP, rsGAS AS JudgeGAS, rsWI1START AS JudgeWI1START, rsWI1WITH AS JudgeWI1WITH, rsIP AS JudgeIP,
        rsDF AS JudgeDF, rsTemp AS JudgeTEMP, rsIOT AS JudgeIOT, rsPAN AS JudgePAN, rsWI2 AS JudgeWI2, 
        rsCAMBack AS JudgeCAMBACK, rsCAMFront AS JudgeCAMFRONT,
        rsTotal AS JudgeTotal , Reason as ReasonError,UserConfirm as UserConfirm;
 
END