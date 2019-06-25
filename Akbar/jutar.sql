-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 25, 2019 at 06:05 AM
-- Server version: 10.1.37-MariaDB
-- PHP Version: 7.3.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `jutar`
--

-- --------------------------------------------------------

--
-- Table structure for table `tb_keranjang`
--

CREATE TABLE `tb_keranjang` (
  `no_meja` char(2) NOT NULL,
  `id_menu` int(2) NOT NULL,
  `nama_menu` varchar(25) NOT NULL,
  `harga_menu` int(7) NOT NULL,
  `qty` int(2) NOT NULL,
  `subtotal` int(7) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_keranjang`
--

INSERT INTO `tb_keranjang` (`no_meja`, `id_menu`, `nama_menu`, `harga_menu`, `qty`, `subtotal`) VALUES
('1', 3, 'AYAM GORENG PEDAS', 99999, 3, 0),
('2', 5, 'MIE PANGSIT', 1600, 2, 3200),
('4', 4, 'Nasi Goreng Ayam', 30000, 2, 60000),
('2', 5, 'MIE PANGSIT', 1600, 1, 1600),
('1', 4, 'Nasi Goreng Ayam', 30000, 1, 30000),
('1', 4, 'Nasi Goreng Ayam', 30000, 2, 60000),
('1', 5, 'MIE PANGSIT', 1600, 2, 3200),
('1', 3, 'AYAM GORENG PEDAS', 10000, 2, 20000),
('1', 5, 'MIE PANGSIT', 1600, 10, 16000),
('20', 4, 'Nasi Goreng Ayam', 30000, 20, 600000),
('1', 3, 'AYAM GORENG PEDAS', 10000, 2, 20000),
('', 3, 'AYAM GORENG PEDAS', 10000, 1, 10000),
('', 4, 'Nasi Goreng Ayam', 30000, 2, 60000),
('', 3, 'AYAM GORENG PEDAS', 10000, 1, 10000);

-- --------------------------------------------------------

--
-- Table structure for table `tb_meja`
--

CREATE TABLE `tb_meja` (
  `no_meja` int(2) DEFAULT NULL,
  `total` int(7) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_meja`
--

INSERT INTO `tb_meja` (`no_meja`, `total`) VALUES
(1, 129200),
(20, 600000),
(20, 600000),
(20, 600000),
(20, 600000),
(20, 600000),
(20, 600000),
(20, 600000);

-- --------------------------------------------------------

--
-- Table structure for table `tb_menu`
--

CREATE TABLE `tb_menu` (
  `id_menu` int(2) NOT NULL,
  `nama_menu` varchar(25) NOT NULL,
  `harga_menu` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_menu`
--

INSERT INTO `tb_menu` (`id_menu`, `nama_menu`, `harga_menu`) VALUES
(3, 'AYAM GORENG PEDAS', 10000),
(4, 'Nasi Goreng Ayam', 30000),
(5, 'MIE PANGSIT', 1600);

-- --------------------------------------------------------

--
-- Table structure for table `tb_transaksi`
--

CREATE TABLE `tb_transaksi` (
  `id_transaksi` int(7) NOT NULL,
  `tgl_pembelian` date NOT NULL,
  `mb` char(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tb_transaksi_detail`
--

CREATE TABLE `tb_transaksi_detail` (
  `id_transaksi_detail` int(7) NOT NULL,
  `id_menu` int(2) NOT NULL,
  `harga_menu` int(5) NOT NULL,
  `porsi` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tb_menu`
--
ALTER TABLE `tb_menu`
  ADD PRIMARY KEY (`id_menu`);

--
-- Indexes for table `tb_transaksi`
--
ALTER TABLE `tb_transaksi`
  ADD PRIMARY KEY (`id_transaksi`);

--
-- Indexes for table `tb_transaksi_detail`
--
ALTER TABLE `tb_transaksi_detail`
  ADD PRIMARY KEY (`id_transaksi_detail`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tb_menu`
--
ALTER TABLE `tb_menu`
  MODIFY `id_menu` int(2) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `tb_transaksi`
--
ALTER TABLE `tb_transaksi`
  MODIFY `id_transaksi` int(7) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
