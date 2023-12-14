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

END