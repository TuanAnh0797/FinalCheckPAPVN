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
END