-- phpMyAdmin SQL Dump
-- version 4.8.2
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2019. Jún 30. 21:09
-- Kiszolgáló verziója: 10.1.34-MariaDB
-- PHP verzió: 7.2.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `online_blood_bank`
--
CREATE DATABASE IF NOT EXISTS `online_blood_bank` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;
USE `online_blood_bank`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `blood_condition`
--

CREATE TABLE `blood_condition` (
  `blood_health_id` int(3) NOT NULL,
  `blood_health_type` varchar(50) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- A tábla adatainak kiíratása `blood_condition`
--

INSERT INTO `blood_condition` (`blood_health_id`, `blood_health_type`) VALUES
(1, 'Perfect'),
(2, 'Good'),
(3, 'poor');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `blood_donation`
--

CREATE TABLE `blood_donation` (
  `blood_donation_id` int(5) NOT NULL,
  `blood_donation_date` date NOT NULL,
  `blood_donation_member_id` int(5) NOT NULL,
  `blood_donation_blood` double NOT NULL COMMENT 'Hct',
  `blood_donation_plasma` double NOT NULL COMMENT 'Hct',
  `blood_donation_blood_condition` int(3) NOT NULL,
  `blood_donation_blood_type_id` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `blood_type`
--

CREATE TABLE `blood_type` (
  `blood_type_id` int(2) NOT NULL,
  `blood_type_name` varchar(10) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- A tábla adatainak kiíratása `blood_type`
--

INSERT INTO `blood_type` (`blood_type_id`, `blood_type_name`) VALUES
(3, '0'),
(1, 'A'),
(4, 'AB'),
(2, 'B');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `member`
--

CREATE TABLE `member` (
  `member_id` int(5) NOT NULL,
  `member_user_id` int(5) NOT NULL,
  `member_name` varchar(70) COLLATE utf8_unicode_ci NOT NULL,
  `member_address` int(100) NOT NULL,
  `member_born` date NOT NULL,
  `member_mobile` varchar(25) COLLATE utf8_unicode_ci NOT NULL,
  `member_email` varchar(75) COLLATE utf8_unicode_ci NOT NULL,
  `member_blood_type_id` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `rank`
--

CREATE TABLE `rank` (
  `rank_id` int(1) NOT NULL,
  `rank_name` varchar(20) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- A tábla adatainak kiíratása `rank`
--

INSERT INTO `rank` (`rank_id`, `rank_name`) VALUES
(0, 'admin'),
(1, 'receptionist'),
(2, 'member');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `user`
--

CREATE TABLE `user` (
  `user_id` int(5) NOT NULL,
  `user_name` varchar(30) COLLATE utf8_unicode_ci NOT NULL,
  `user_password` varchar(16) COLLATE utf8_unicode_ci NOT NULL,
  `user_rank_id` int(1) NOT NULL,
  `user_last_login` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- A tábla adatainak kiíratása `user`
--

INSERT INTO `user` (`user_id`, `user_name`, `user_password`, `user_rank_id`, `user_last_login`) VALUES
(1, 'teszt', 'teszt', 0, '2019-06-30 18:32:34'),
(2, 'user1', 'user1', 0, '2019-06-30 18:56:11'),
(3, 'user2', 'user2', 1, '2019-06-30 18:56:25');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `blood_condition`
--
ALTER TABLE `blood_condition`
  ADD PRIMARY KEY (`blood_health_id`);

--
-- A tábla indexei `blood_donation`
--
ALTER TABLE `blood_donation`
  ADD KEY `blood_donation_member_id` (`blood_donation_member_id`),
  ADD KEY `blood_donation_blood_health_id` (`blood_donation_blood_condition`),
  ADD KEY `blood_donation_blood_type_id` (`blood_donation_blood_type_id`);

--
-- A tábla indexei `blood_type`
--
ALTER TABLE `blood_type`
  ADD PRIMARY KEY (`blood_type_id`),
  ADD UNIQUE KEY `blood_type_name` (`blood_type_name`);

--
-- A tábla indexei `member`
--
ALTER TABLE `member`
  ADD PRIMARY KEY (`member_id`),
  ADD KEY `acceptor_user_id` (`member_user_id`),
  ADD KEY `member_blood_type_id` (`member_blood_type_id`);

--
-- A tábla indexei `rank`
--
ALTER TABLE `rank`
  ADD PRIMARY KEY (`rank_id`);

--
-- A tábla indexei `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `user_name` (`user_name`),
  ADD KEY `user_rank` (`user_rank_id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `blood_condition`
--
ALTER TABLE `blood_condition`
  MODIFY `blood_health_id` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `blood_type`
--
ALTER TABLE `blood_type`
  MODIFY `blood_type_id` int(2) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT a táblához `member`
--
ALTER TABLE `member`
  MODIFY `member_id` int(5) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `rank`
--
ALTER TABLE `rank`
  MODIFY `rank_id` int(1) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT a táblához `user`
--
ALTER TABLE `user`
  MODIFY `user_id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `blood_donation`
--
ALTER TABLE `blood_donation`
  ADD CONSTRAINT `blood_donation_ibfk_1` FOREIGN KEY (`blood_donation_blood_condition`) REFERENCES `blood_condition` (`blood_health_id`),
  ADD CONSTRAINT `blood_donation_ibfk_2` FOREIGN KEY (`blood_donation_member_id`) REFERENCES `member` (`member_id`),
  ADD CONSTRAINT `blood_donation_ibfk_3` FOREIGN KEY (`blood_donation_blood_type_id`) REFERENCES `blood_type` (`blood_type_id`);

--
-- Megkötések a táblához `member`
--
ALTER TABLE `member`
  ADD CONSTRAINT `member_ibfk_1` FOREIGN KEY (`member_user_id`) REFERENCES `user` (`user_id`);

--
-- Megkötések a táblához `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `user_ibfk_1` FOREIGN KEY (`user_rank_id`) REFERENCES `rank` (`rank_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
