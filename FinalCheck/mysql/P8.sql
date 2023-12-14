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
END