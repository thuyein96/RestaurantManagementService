-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: restaurant_booking_db
-- ------------------------------------------------------
-- Server version	8.0.42

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
-- Table structure for table `bookings`
--

DROP TABLE IF EXISTS `bookings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bookings` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `BookingNumber` int NOT NULL,
  `NumberOfPeople` int NOT NULL,
  `SpecialRequest` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `IsConfirmed` tinyint(1) NOT NULL,
  `BookingSlotId` int NOT NULL DEFAULT '0',
  `CustomerId` int NOT NULL DEFAULT '0',
  `TableId` int NOT NULL DEFAULT '0',
  `CustomerId1` int DEFAULT NULL,
  `TableId1` int DEFAULT NULL,
  `TimeSlotId` int DEFAULT NULL,
  `BookingDate` date NOT NULL DEFAULT '0001-01-01',
  PRIMARY KEY (`Id`),
  KEY `IX_Bookings_BookingSlotId` (`BookingSlotId`),
  KEY `IX_Bookings_CustomerId` (`CustomerId`),
  KEY `IX_Bookings_TableId` (`TableId`),
  KEY `IX_Bookings_CustomerId1` (`CustomerId1`),
  KEY `IX_Bookings_TableId1` (`TableId1`),
  KEY `IX_Bookings_TimeSlotId` (`TimeSlotId`),
  CONSTRAINT `FK_Bookings_Customers_CustomerId` FOREIGN KEY (`CustomerId`) REFERENCES `customers` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Bookings_Customers_CustomerId1` FOREIGN KEY (`CustomerId1`) REFERENCES `customers` (`Id`),
  CONSTRAINT `FK_Bookings_Tables_TableId` FOREIGN KEY (`TableId`) REFERENCES `tables` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Bookings_Tables_TableId1` FOREIGN KEY (`TableId1`) REFERENCES `tables` (`Id`),
  CONSTRAINT `FK_Bookings_TimeSlots_BookingSlotId` FOREIGN KEY (`BookingSlotId`) REFERENCES `timeslots` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Bookings_TimeSlots_TimeSlotId` FOREIGN KEY (`TimeSlotId`) REFERENCES `timeslots` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bookings`
--

LOCK TABLES `bookings` WRITE;
/*!40000 ALTER TABLE `bookings` DISABLE KEYS */;
INSERT INTO `bookings` VALUES (6,0,2,'',1,1,1,1,NULL,NULL,NULL,'2025-05-17'),(7,0,2,'',1,3,1,3,NULL,NULL,NULL,'2025-05-23'),(8,0,3,'',1,2,1,6,NULL,NULL,NULL,'2025-05-24'),(10,0,3,'',1,4,1,10,NULL,NULL,NULL,'2025-05-14'),(11,0,2,'',1,3,1,6,NULL,NULL,NULL,'2025-05-24'),(12,0,2,'',1,3,1,5,NULL,NULL,NULL,'2025-05-24');
/*!40000 ALTER TABLE `bookings` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-04 16:41:02
