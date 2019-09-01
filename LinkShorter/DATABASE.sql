-- --------------------------------------------------------
-- Хост:                         127.0.0.1
-- Версия сервера:               5.5.23 - MySQL Community Server (GPL)
-- Операционная система:         Win64
-- HeidiSQL Версия:              10.2.0.5599
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Дамп структуры базы данных short_url
DROP DATABASE IF EXISTS `short_url`;
CREATE DATABASE IF NOT EXISTS `short_url` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `short_url`;

-- Дамп структуры для таблица short_url.links
DROP TABLE IF EXISTS `links`;
CREATE TABLE IF NOT EXISTS `links` (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `Url` varchar(50) DEFAULT NULL,
  `ShortUrl` varchar(50) DEFAULT NULL,
  `Date` datetime DEFAULT NULL,
  `Counter` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `ShortUrl` (`ShortUrl`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы short_url.links: ~4 rows (приблизительно)
/*!40000 ALTER TABLE `links` DISABLE KEYS */;
INSERT INTO `links` (`Id`, `Url`, `ShortUrl`, `Date`, `Counter`) VALUES
	(15, 'https://vk.com', 'RFXJYP', '2019-09-01 21:51:39', 1),
	(18, 'https://vk.com/akalexx', 'ME', '2019-09-01 22:31:10', 7),
	(25, 'https://youtube.com', 'BIFDUH', '2019-09-01 22:54:21', 3),
	(28, 'http://rubbishletter.000webhostapp.com/', 'MYOLDSITE', '2019-09-02 00:09:57', 4);
/*!40000 ALTER TABLE `links` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
