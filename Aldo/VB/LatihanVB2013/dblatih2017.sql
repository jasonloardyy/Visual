-- phpMyAdmin SQL Dump
-- version 4.2.7.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 08, 2017 at 03:21 AM
-- Server version: 5.6.20
-- PHP Version: 5.5.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `dblatih2017`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_HapusDataPesawat`(IN IdPes CHAR(2))
BEGIN
Delete from pesawat where id_pesawat = Id_Pes ;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_TAMPIL`()
BEGIN
SELECT * FROM PESAWAT ;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Stand-in structure for view `data_pilot_pesawat`
--
CREATE TABLE IF NOT EXISTS `data_pilot_pesawat` (
`id_sertifikasi` int(11)
,`pilot` varchar(40)
,`nama` varchar(30)
);
-- --------------------------------------------------------

--
-- Table structure for table `pesawat`
--

CREATE TABLE IF NOT EXISTS `pesawat` (
  `Id_Pesawat` char(2) NOT NULL,
  `Nama` varchar(30) NOT NULL,
  `Jarak_Jelajah` int(11) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pesawat`
--

INSERT INTO `pesawat` (`Id_Pesawat`, `Nama`, `Jarak_Jelajah`) VALUES
('01', 'Boeing 747-400', 8430),
('02', 'Boeing 737-800', 3383),
('03', 'Airbus A340-300', 7120),
('04', 'British Aerospace Jet', 1502),
('05', 'Embraer ERJ-145', 1530),
('06', 'SAAB 340', 2128),
('07', 'Piper Archer III', 520),
('08', 'Tupolev 154', 4103),
('09', 'Lockheed L1011', 6900),
('10', 'Boeing 757-300', 4010),
('11', 'Boeing 777-300', 6441),
('12', 'Boeing 767-400ER', 6475),
('13', 'Airbus A320', 2605),
('14', 'Airbus A319', 1805),
('15', 'Boeing 727', 1504),
('16', 'Schwitzer 2-33', 30);

-- --------------------------------------------------------

--
-- Table structure for table `pilot`
--

CREATE TABLE IF NOT EXISTS `pilot` (
  `id_pilot` char(2) NOT NULL,
  `nama` varchar(40) NOT NULL,
  `gaji` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pilot`
--

INSERT INTO `pilot` (`id_pilot`, `nama`, `gaji`) VALUES
('01', 'Duncan Mcleod', 10200000),
('02', 'George', 9800000),
('03', 'Michael', 13000000),
('04', 'Fowler', 8900000),
('05', 'Williams', 10200000);

-- --------------------------------------------------------

--
-- Table structure for table `sertifikasi`
--

CREATE TABLE IF NOT EXISTS `sertifikasi` (
  `id_sertifikasi` int(11) NOT NULL,
  `id_pesawat` char(2) NOT NULL,
  `id_pilot` char(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sertifikasi`
--

INSERT INTO `sertifikasi` (`id_sertifikasi`, `id_pesawat`, `id_pilot`) VALUES
(1, '01', '01'),
(2, '03', '01'),
(3, '10', '01'),
(4, '07', '02'),
(5, '01', '03'),
(6, '03', '03'),
(7, '10', '03'),
(8, '12', '03'),
(9, '13', '05'),
(10, '14', '05');

-- --------------------------------------------------------

--
-- Stand-in structure for view `v_data_pilot_pesawat`
--
CREATE TABLE IF NOT EXISTS `v_data_pilot_pesawat` (
`pesawat` varchar(30)
,`jarak_jelajah` int(11)
,`pilot` varchar(40)
);
-- --------------------------------------------------------

--
-- Structure for view `data_pilot_pesawat`
--
DROP TABLE IF EXISTS `data_pilot_pesawat`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `data_pilot_pesawat` AS select `sertifikasi`.`id_sertifikasi` AS `id_sertifikasi`,`pilot`.`nama` AS `pilot`,`pesawat`.`Nama` AS `nama` from ((`sertifikasi` join `pilot` on((`sertifikasi`.`id_pilot` = `pilot`.`id_pilot`))) join `pesawat` on((`sertifikasi`.`id_pesawat` = `pesawat`.`Id_Pesawat`)));

-- --------------------------------------------------------

--
-- Structure for view `v_data_pilot_pesawat`
--
DROP TABLE IF EXISTS `v_data_pilot_pesawat`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_data_pilot_pesawat` AS select `a`.`Nama` AS `pesawat`,`a`.`Jarak_Jelajah` AS `jarak_jelajah`,`c`.`nama` AS `pilot` from ((`pesawat` `a` left join `sertifikasi` `b` on((`a`.`Id_Pesawat` = `b`.`id_pesawat`))) left join `pilot` `c` on((`b`.`id_pilot` = `c`.`id_pilot`)));

--
-- Indexes for dumped tables
--

--
-- Indexes for table `pesawat`
--
ALTER TABLE `pesawat`
 ADD PRIMARY KEY (`Id_Pesawat`);

--
-- Indexes for table `pilot`
--
ALTER TABLE `pilot`
 ADD PRIMARY KEY (`id_pilot`);

--
-- Indexes for table `sertifikasi`
--
ALTER TABLE `sertifikasi`
 ADD PRIMARY KEY (`id_sertifikasi`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
