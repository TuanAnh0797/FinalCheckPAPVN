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
-- Table structure for table `tempdetail`
--

DROP TABLE IF EXISTS `tempdetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tempdetail` (
  `TimePLC` datetime DEFAULT NULL,
  `CodeBack` varchar(30) DEFAULT NULL,
  `CodeModel` varchar(20) DEFAULT NULL,
  `CodeSerial` varchar(10) DEFAULT NULL,
  `Judge` varchar(10) DEFAULT NULL,
  `NamePoint1` varchar(30) DEFAULT NULL,
  `Standard1` varchar(20) DEFAULT NULL,
  `Actual1` varchar(20) DEFAULT NULL,
  `Result1` varchar(10) DEFAULT NULL,
  `NamePoint2` varchar(30) DEFAULT NULL,
  `Standard2` varchar(20) DEFAULT NULL,
  `Actual2` varchar(20) DEFAULT NULL,
  `Result2` varchar(10) DEFAULT NULL,
  `NamePoint3` varchar(30) DEFAULT NULL,
  `Standard3` varchar(20) DEFAULT NULL,
  `Actual3` varchar(20) DEFAULT NULL,
  `Result3` varchar(10) DEFAULT NULL,
  `NamePoint4` varchar(30) DEFAULT NULL,
  `Standard4` varchar(20) DEFAULT NULL,
  `Actual4` varchar(20) DEFAULT NULL,
  `Result4` varchar(10) DEFAULT NULL,
  `NamePoint5` varchar(30) DEFAULT NULL,
  `Standard5` varchar(20) DEFAULT NULL,
  `Actual5` varchar(20) DEFAULT NULL,
  `Result5` varchar(10) DEFAULT NULL,
  `NamePoint6` varchar(30) DEFAULT NULL,
  `Standard6` varchar(20) DEFAULT NULL,
  `Actual6` varchar(20) DEFAULT NULL,
  `Result6` varchar(10) DEFAULT NULL,
  `NamePoint7` varchar(30) DEFAULT NULL,
  `Standard7` varchar(20) DEFAULT NULL,
  `Actual7` varchar(20) DEFAULT NULL,
  `Result7` varchar(10) DEFAULT NULL,
  `NamePoint8` varchar(30) DEFAULT NULL,
  `Standard8` varchar(20) DEFAULT NULL,
  `Actual8` varchar(20) DEFAULT NULL,
  `Result8` varchar(10) DEFAULT NULL,
  `NamePoint9` varchar(30) DEFAULT NULL,
  `Standard9` varchar(20) DEFAULT NULL,
  `Actual9` varchar(20) DEFAULT NULL,
  `Result9` varchar(10) DEFAULT NULL,
  `NamePoint10` varchar(30) DEFAULT NULL,
  `Standard10` varchar(20) DEFAULT NULL,
  `Actual10` varchar(20) DEFAULT NULL,
  `Result10` varchar(10) DEFAULT NULL,
  `NamePoint11` varchar(30) DEFAULT NULL,
  `Standard11` varchar(20) DEFAULT NULL,
  `Actual11` varchar(20) DEFAULT NULL,
  `Result11` varchar(10) DEFAULT NULL,
  `NamePoint12` varchar(30) DEFAULT NULL,
  `Standard12` varchar(20) DEFAULT NULL,
  `Actual12` varchar(20) DEFAULT NULL,
  `Result12` varchar(10) DEFAULT NULL,
  `NamePoint13` varchar(30) DEFAULT NULL,
  `Standard13` varchar(20) DEFAULT NULL,
  `Actual13` varchar(20) DEFAULT NULL,
  `Result13` varchar(10) DEFAULT NULL,
  `NamePoint14` varchar(30) DEFAULT NULL,
  `Standard14` varchar(20) DEFAULT NULL,
  `Actual14` varchar(20) DEFAULT NULL,
  `Result14` varchar(10) DEFAULT NULL,
  `NamePoint15` varchar(30) DEFAULT NULL,
  `Standard15` varchar(20) DEFAULT NULL,
  `Actual15` varchar(20) DEFAULT NULL,
  `Result15` varchar(10) DEFAULT NULL,
  `TimeInsert` datetime DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tempdetail`
--

LOCK TABLES `tempdetail` WRITE;
/*!40000 ALTER TABLE `tempdetail` DISABLE KEYS */;
/*!40000 ALTER TABLE `tempdetail` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-12-16 18:29:49
