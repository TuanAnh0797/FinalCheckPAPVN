CREATE DEFINER=`root`@`localhost` PROCEDURE `GetConfigCheckFinal`()
BEGIN
   SELECT  * FROM dataplc.configcheckfinal limit 1;
END