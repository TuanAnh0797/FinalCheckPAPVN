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
-- Table structure for table `suatu`
--

DROP TABLE IF EXISTS `suatu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `suatu` (
  `TimePLC` datetime DEFAULT NULL,
  `CodeBack` varchar(30) DEFAULT NULL,
  `CodeModel` varchar(30) DEFAULT NULL,
  `CodeSerial` varchar(30) DEFAULT NULL,
  `Judge` varchar(30) DEFAULT NULL,
  `IDSuaTu` int DEFAULT NULL,
  `ErrorCode` varchar(150) DEFAULT NULL,
  `ErrorName` varchar(150) DEFAULT NULL,
  `Phenomena` varchar(150) DEFAULT NULL,
  `Solution` varchar(150) DEFAULT NULL,
  `DescribeName` varchar(150) DEFAULT NULL,
  `ErrorEdit` varchar(150) DEFAULT NULL,
  `NameErrorEdit` varchar(150) DEFAULT NULL,
  `DeclarerCode` varchar(45) DEFAULT NULL,
  `DeclarerName` varchar(150) DEFAULT NULL,
  `PersonCode` varchar(45) DEFAULT NULL,
  `PersonName` varchar(150) DEFAULT NULL,
  `PQCComfirmCode` varchar(45) DEFAULT NULL,
  `PQCComfirmName` varchar(150) DEFAULT NULL,
  `CompleteDate` datetime DEFAULT NULL,
  `TimeInsert` datetime DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suatu`
--

LOCK TABLES `suatu` WRITE;
/*!40000 ALTER TABLE `suatu` DISABLE KEYS */;
INSERT INTO `suatu` VALUES ('2023-12-22 18:33:44','NR-B271TV-S13Z01843','NR-B271TV-S1','3Z01843','OK',57720,'U2','UỐN BẸP','uốn bẹp','chỉnh lại','bẹp lo2','SC1','CHỈNH LẠI','1131','Ngô Xuân Thìn','1126','Nguyễn Quốc Trọng','1142','RTC TEST QC','2023-12-22 18:33:51','2023-12-22 18:33:54'),('2023-12-22 18:46:43','NR-BX471CPSP3Z00449','NR-BX471CPSP','3Z00449','OK',57721,'Q2','QUẠT KHÔNG QUAY','cong chân kim','chninhr lại','quạt ko quay','SC1','CHỈNH LẠI','1131','Ngô Xuân Thìn','1126','Nguyễn Quốc Trọng','1142','RTC TEST QC','2023-12-22 18:46:49','2023-12-22 18:46:53'),('2023-12-22 18:57:43','NR-B171TV-S13Z02175','NR-B171TV-S1','3Z02175','OK',57722,'L1','LỐC KHÔNG CHẠY','chua rõ','cam lại','lốc ko chay','SR1','KIỂM TRA KHÔNG THẤY BẤT THƯỜNG CHO CHẠY LẠI','1131','Ngô Xuân Thìn','1126','Nguyễn Quốc Trọng','1142','RTC TEST QC','2023-12-22 18:57:49','2023-12-22 18:57:54'),('2023-12-22 21:24:38','NR-TV261BPKV3Z00752','NR-TV261BPKV','3Z00752','OK',57723,'N3','NHIỆT ĐỘ CENTER KHÔNG ĐẠT','chua rõ','rút gát hàn lại','centor ko đạt','SC2','CẮT HÀN LẠI','1131','Ngô Xuân Thìn','1126','Nguyễn Quốc Trọng','1142','RTC TEST QC','2023-12-22 21:24:55','2023-12-22 21:24:49'),('2023-12-22 21:32:52','NR-TV261BPKV3Z00999','NR-TV261BPKV','3Z00999','OK',57724,'N3','NHIỆT ĐỘ CENTER KHÔNG ĐẠT','chua rõ','cam lại','cen to ko dat','SR2','CẮM LẠI','1131','Ngô Xuân Thìn','1126','Nguyễn Quốc Trọng','1142','RTC TEST QC','2023-12-22 21:33:00','2023-12-22 21:33:02'),('2023-12-22 21:48:54','NR-DZ601YGKV3Z00138','NR-DZ601YGKV','3Z00138','OK',57725,'TX','LỖI TIẾP XÚC','chua rõ','cam lại','lỗi tiếp xúc','SR2','CẮM LẠI','1131','Ngô Xuân Thìn','1126','Nguyễn Quốc Trọng','1142','RTC TEST QC','2023-12-22 21:49:03','2023-12-22 21:49:05'),('2023-12-22 21:50:01','NR-TL351GPKV3Z01791','NR-TL351GPKV','3Z01791','OK',57726,'R21','NHĂN GASKET DOOR FC','chua rõ','sấy lại','han zong fc','SC8','SẤY LẠI','1131','Ngô Xuân Thìn','1126','Nguyễn Quốc Trọng','1142','RTC TEST QC','2023-12-22 21:50:12','2023-12-22 21:50:11'),('2023-12-22 22:22:10','NR-BX471GPKV3Z00493','NR-BX471GPKV','3Z00493','OK',57727,'HD01','RÒ GAS MỐI D01','uốn dryer làm gãy','cat hàn lại','không có','SC2','CẮT HÀN LẠI','1132','Trần Văn Linh','1124','Lê Huy','1142','RTC TEST QC','2023-12-22 22:22:14','2023-12-22 22:22:20'),('2023-12-22 22:31:17','NR-B171TV-S13Z02256','NR-B171TV-S1','3Z02256','OK',57728,'N3','NHIỆT ĐỘ CENTER KHÔNG ĐẠT','chua rõ','phoi tủ chạy lại','không có','SR1','KIỂM TRA KHÔNG THẤY BẤT THƯỜNG CHO CHẠY LẠI','1132','Trần Văn Linh','1124','Lê Huy','1142','RTC TEST QC','2023-12-22 22:31:22','2023-12-22 22:31:28'),('2023-12-22 23:06:56','NR-B271TV-S13Z01967','NR-B271TV-S1','3Z01967','OK',57729,'U2','UỐN BẸP','kẹp khuân làm bẹp L02','uốn chỉnh lại','không có','SC1','CHỈNH LẠI','1132','Trần Văn Linh','1124','Lê Huy','1142','RTC TEST QC','2023-12-22 23:07:02','2023-12-22 23:07:07'),('2023-12-22 23:10:01','NR-B171TV-S13Z02249','NR-B171TV-S1','3Z02249','OK',57730,'KH','LỖI KHÁC','thiếu hooc pan','bổ xung thêm','không có','SC9','BỔ SUNG THÊM LINH KIỆN','1132','Trần Văn Linh','1124','Lê Huy','1142','RTC TEST QC','2023-12-22 23:10:07','2023-12-22 23:10:11'),('2023-12-22 23:15:26','NR-BV320XSPH3Z01869','NR-BV320XSPH','3Z01869','OK',57731,'M11','ỐC VÀNG KHÔNG CÓ REN','chua tạo ren lỗ ốc lốc','tạo lại ren','không có','SQ1','TARO LẠI','1132','Trần Văn Linh','1124','Lê Huy','1142','RTC TEST QC','2023-12-22 23:15:40','2023-12-22 23:15:37'),('2023-12-22 23:55:22','NR-TL351GPKV3Z01788','NR-TL351GPKV','3Z01788','OK',57732,'S3','HỞ BOX','kênh from','vệ sinh lại','không có','SC6','VỆ SINH LẠI','1132','Trần Văn Linh','1124','Lê Huy','1142','RTC TEST QC','2023-12-22 23:55:28','2023-12-22 23:55:32'),('2023-12-23 00:01:36','NR-TX461CPKM3Z00104','NR-TX461CPKM','3Z00104','OK',57733,'T11','SẬP CENTER','chua rõ','chỉnh lại','không có','SC1','CHỈNH LẠI','1132','Trần Văn Linh','1124','Lê Huy','1142','RTC TEST QC','2023-12-23 00:01:40','2023-12-23 00:01:47'),('2023-12-23 00:23:59','NR-TL351GPKV3Z01790','NR-TL351GPKV','3Z01790','OK',57734,'HR03','RÒ GAS MỐI R03','lap kẹp uốn gãy','cat hàn lại','không có','SC2','CẮT HÀN LẠI','1132','Trần Văn Linh','1124','Lê Huy','1142','RTC TEST QC','2023-12-23 00:24:03','2023-12-23 00:24:10'),('2023-12-23 00:25:05','NR-B331VG-X13Z00739','NR-B331VG-X1','3Z00739','OK',57735,'U2','UỐN BẸP','uốn dryer làm bẹp','cat hàn lại','không có','SC2','CẮT HÀN LẠI','1132','Trần Văn Linh','1124','Lê Huy','1142','RTC TEST QC','2023-12-23 00:25:09','2023-12-23 00:25:16'),('2023-12-23 00:40:06','NR-DZ601YGKV3Z00131','NR-DZ601YGKV','3Z00131','OK',57736,'N5','NHIỆT ĐỘ FRENCH KHÔNG ĐẠT','chua rõ','phoi tủ chạy lại','không có','SR1','KIỂM TRA KHÔNG THẤY BẤT THƯỜNG CHO CHẠY LẠI','1132','Trần Văn Linh','1124','Lê Huy','1142','RTC TEST QC','2023-12-23 00:40:11','2023-12-23 00:40:17'),('2023-12-23 00:47:00','NR-B371TV-S13Z02767','NR-B371TV-S1','3Z02767','OK',57737,'L2','LỐC KÊU LẠ','hàn tac r03','cat hàn lại','không có','SC2','CẮT HÀN LẠI','1132','Trần Văn Linh','1124','Lê Huy','1142','RTC TEST QC','2023-12-23 00:47:04','2023-12-23 00:47:11'),('2023-12-23 00:58:14','NR-B271TV-S13Z01954','NR-B271TV-S1','3Z01954','OK',57738,'T24','KHÔNG LẮP ĐƯỢC COVER COMP','không lap dc cover moto','chỉnh lại tai lốc','không có','SC1','CHỈNH LẠI','1132','Trần Văn Linh','1124','Lê Huy','1142','RTC TEST QC','2023-12-23 00:58:17','2023-12-23 00:58:24'),('2023-12-23 01:11:12','NR-D541PG-H13Z00226','NR-D541PG-H1','3Z00226','OK',57739,'N3','NHIỆT ĐỘ CENTER KHÔNG ĐẠT','chua rõ','phoi tủ chạy lại','không có','SR1','KIỂM TRA KHÔNG THẤY BẤT THƯỜNG CHO CHẠY LẠI','1132','Trần Văn Linh','1124','Lê Huy','1142','RTC TEST QC','2023-12-23 01:11:17','2023-12-23 01:11:23'),('2023-12-23 01:53:43','NR-TL381VGMV3Z00633','NR-TL381VGMV','3Z00633','OK',57740,'KH','LỖI KHÁC','hỏ back chua rõ','chỉnh sua lại','không có','SC1','CHỈNH LẠI','1132','Trần Văn Linh','1124','Lê Huy','1142','RTC TEST QC','2023-12-23 01:53:47','2023-12-23 01:53:54'),('2023-12-23 02:47:54','NR-CW530XMMV3Z00491','NR-CW530XMMV','3Z00491','OK',57741,'PU6','PU 6 LỐC KO CHẠY','chua rõ','kt chạy lại','không có','SR1','KIỂM TRA KHÔNG THẤY BẤT THƯỜNG CHO CHẠY LẠI','1132','Trần Văn Linh','1124','Lê Huy','1142','RTC TEST QC','2023-12-23 02:47:58','2023-12-23 02:48:05'),('2023-12-23 02:51:51','NR-B171TV-S13Z02295','NR-B171TV-S1','3Z02295','OK',57742,'T24','KHÔNG LẮP ĐƯỢC COVER COMP','vênh tai lốc','chỉnh lại','không có','SC1','CHỈNH LẠI','1132','Trần Văn Linh','1124','Lê Huy','1142','RTC TEST QC','2023-12-23 02:51:55','2023-12-23 02:52:01'),('2023-12-23 02:52:26','NR-B331VG-X13Z00849','NR-B331VG-X1','3Z00849','OK',57743,'T24','KHÔNG LẮP ĐƯỢC COVER COMP','vênh tai lốc','chỉnh lại','không có','SC1','CHỈNH LẠI','1132','Trần Văn Linh','1124','Lê Huy','1142','RTC TEST QC','2023-12-23 02:52:29','2023-12-23 02:52:36'),('2023-12-23 03:03:43','NR-BW530XMMV3Z00912','NR-BW530XMMV','3Z00912','OK',57744,'nE','NANOE BẤT THƯỜNG','tụt chân kim nano','cam lại','không có','SR2','CẮM LẠI','1132','Trần Văn Linh','1124','Lê Huy','1142','RTC TEST QC','2023-12-23 03:03:48','2023-12-23 03:03:54'),('2023-12-23 04:16:13','NR-CW530XMMV3Z00473','NR-CW530XMMV','3Z00473','OK',57745,'N5','NHIỆT ĐỘ FRENCH KHÔNG ĐẠT','chua rõ','phoi tủ chạy lại','không có','SR1','KIỂM TRA KHÔNG THẤY BẤT THƯỜNG CHO CHẠY LẠI','1132','Trần Văn Linh','1124','Lê Huy','1142','RTC TEST QC','2023-12-23 04:16:19','2023-12-23 04:16:23');
/*!40000 ALTER TABLE `suatu` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-12-23 15:34:41
