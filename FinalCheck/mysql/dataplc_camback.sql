CREATE DATABASE  IF NOT EXISTS `dataplc` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `dataplc`;
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
-- Table structure for table `camback`
--

DROP TABLE IF EXISTS `camback`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `camback` (
  `TimePLC` datetime DEFAULT NULL,
  `CodeBack` varchar(30) DEFAULT NULL,
  `CodeModel` varchar(20) DEFAULT NULL,
  `CodeSerial` varchar(20) DEFAULT NULL,
  `Judge` varchar(2) DEFAULT NULL,
  `VitSidePhai` varchar(2) DEFAULT NULL,
  `VitSideTrai` varchar(2) DEFAULT NULL,
  `Hookpan` varchar(2) DEFAULT NULL,
  `PWE` varchar(2) DEFAULT NULL,
  `VitPWE` varchar(2) DEFAULT NULL,
  `InPadComp` varchar(2) DEFAULT NULL,
  `ClampPipe` varchar(2) DEFAULT NULL,
  `VitClampPipe` varchar(2) DEFAULT NULL,
  `BoxPCB` varchar(2) DEFAULT NULL,
  `VitBoxPCB` varchar(2) DEFAULT NULL,
  `ChotComp` varchar(2) DEFAULT NULL,
  `BanhXePhai` varchar(2) DEFAULT NULL,
  `BanhXeTrai` varchar(2) DEFAULT NULL,
  `CapPipe` varchar(2) DEFAULT NULL,
  `RubberPipe` varchar(2) DEFAULT NULL,
  `InsPadComp` varchar(2) DEFAULT NULL,
  `DayNoiDat` varchar(2) DEFAULT NULL,
  `VitDayNoiDatSidePhai` varchar(2) DEFAULT NULL,
  `WiringDiagram` varchar(2) DEFAULT NULL,
  `CoverComp` varchar(2) DEFAULT NULL,
  `VitCoverComp` varchar(2) DEFAULT NULL,
  `Hanger` varchar(2) DEFAULT NULL,
  `TimeInsert` datetime DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `camback`
--

LOCK TABLES `camback` WRITE;
/*!40000 ALTER TABLE `camback` DISABLE KEYS */;
/*!40000 ALTER TABLE `camback` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-12-14 23:20:12
