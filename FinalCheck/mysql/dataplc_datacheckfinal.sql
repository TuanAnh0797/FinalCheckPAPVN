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
-- Table structure for table `datacheckfinal`
--

DROP TABLE IF EXISTS `datacheckfinal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `datacheckfinal` (
  `CodeBack` varchar(30) DEFAULT NULL,
  `Judge_VP` varchar(8) DEFAULT NULL,
  `Judge_GAS` varchar(8) DEFAULT NULL,
  `Judge_WI1WITH` varchar(8) DEFAULT NULL,
  `Judge_WI1START` varchar(8) DEFAULT NULL,
  `Judge_IP` varchar(8) DEFAULT NULL,
  `Judge_DF` varchar(8) DEFAULT NULL,
  `Judge_TEMP` varchar(8) DEFAULT NULL,
  `Judge_IOT` varchar(8) DEFAULT NULL,
  `Judge_WI2` varchar(8) DEFAULT NULL,
  `Judge_PAN` varchar(8) DEFAULT NULL,
  `Judge_CAMBACK` varchar(8) DEFAULT NULL,
  `Judge_CAMFRONT` varchar(8) DEFAULT NULL,
  `Judge_Total` varchar(8) DEFAULT NULL,
  `ReasonError` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `PersonConfirm` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `TimeUpdate` datetime DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `datacheckfinal`
--

LOCK TABLES `datacheckfinal` WRITE;
/*!40000 ALTER TABLE `datacheckfinal` DISABLE KEYS */;
/*!40000 ALTER TABLE `datacheckfinal` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-12-16 18:29:50
