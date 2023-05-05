CREATE DATABASE  IF NOT EXISTS `member1` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `member1`;
-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: member1
-- ------------------------------------------------------
-- Server version	8.0.33

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
-- Table structure for table `userconstructor`
--

DROP TABLE IF EXISTS `userconstructor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userconstructor` (
  `userid` varchar(20) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `age` int DEFAULT NULL,
  `phonenumber` varchar(45) DEFAULT NULL COMMENT '회원 정보',
  `address` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userconstructor`
--

LOCK TABLES `userconstructor` WRITE;
/*!40000 ALTER TABLE `userconstructor` DISABLE KEYS */;
INSERT INTO `userconstructor` VALUES ('abc123','qwer123','조형준',26,'010-2676-3147','경기도'),('abc1234','qwer1234','조형',26,'010-2676-3146','경기도'),('shyan','523','김세현',21,'10424324352','수원시권선구'),('k2name','kk1118','김세현',21,'010402044794','수원시권선구'),('uknee','0519','김수현',20,'01040244794','수원시 권선구'),('hyuna','0000','김현아',23,'01023042340','광명'),('ohsung','123','권오성',25,'01040343043','서울시'),('sangjun','000','조상준',24,'01040343034','서울'),('kimsehyun','1234','김세세현',21,'01040244794','서울시 광진구'),('sehyun','3005','김세현',21,'01040244794','서울시 광진구 화양동'),('dje','3ere','김시성',20,'0104024944','서울시'),('SEOYOUNG','0518','서영',20,'01040244794','수원');
/*!40000 ALTER TABLE `userconstructor` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-05 21:19:06
