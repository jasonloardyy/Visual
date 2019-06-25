-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 25, 2019 at 06:06 AM
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
-- Database: `dbcatering`
--

-- --------------------------------------------------------

--
-- Table structure for table `detail_paket`
--

CREATE TABLE `detail_paket` (
  `id_paket` char(3) NOT NULL,
  `id_makanan` char(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `detail_transaksi`
--

CREATE TABLE `detail_transaksi` (
  `id_transaksi` char(7) NOT NULL,
  `id_menu` char(3) NOT NULL,
  `harga` int(7) DEFAULT NULL,
  `porsi` int(3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `keranjang_paket`
--

CREATE TABLE `keranjang_paket` (
  `id_paket` int(3) NOT NULL,
  `id_makanan` int(3) NOT NULL,
  `nama_makanan` varchar(25) NOT NULL,
  `harga_makanan` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbkonsumen`
--

CREATE TABLE `tbkonsumen` (
  `id_konsumen` int(3) NOT NULL,
  `nama_konsumen` varchar(25) NOT NULL,
  `alamat` text NOT NULL,
  `telepon` int(12) DEFAULT NULL,
  `jenis_konsumen` char(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbkonsumen`
--

INSERT INTO `tbkonsumen` (`id_konsumen`, `nama_konsumen`, `alamat`, `telepon`, `jenis_konsumen`) VALUES
(2, 'CELOH', 'KOPRES', 2131231, 'I'),
(3, 'tet', 'fhfhgf', 565756, 'I');

-- --------------------------------------------------------

--
-- Table structure for table `tbkurir`
--

CREATE TABLE `tbkurir` (
  `id_kurir` int(2) NOT NULL,
  `nama_kurir` varchar(30) NOT NULL,
  `status` char(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbmakanan`
--

CREATE TABLE `tbmakanan` (
  `id_makanan` int(3) NOT NULL,
  `nama_makanan` varchar(25) NOT NULL,
  `harga_makanan` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbmakanan`
--

INSERT INTO `tbmakanan` (`id_makanan`, `nama_makanan`, `harga_makanan`) VALUES
(3, 'Ayam Goreng', 10000),
(4, 'Nasi Goreng', 25000),
(5, 'Daging a$ap', 5000),
(6, 'Kangkung', 3000);

-- --------------------------------------------------------

--
-- Table structure for table `tbpaket`
--

CREATE TABLE `tbpaket` (
  `id_paket` int(3) NOT NULL,
  `nama_paket` varchar(25) NOT NULL,
  `harga_paket` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- --------------------------------------------------------

--
-- Table structure for table `tbpengantaran`
--

CREATE TABLE `tbpengantaran` (
  `id_transaksi` char(3) NOT NULL,
  `id_kurir` char(3) NOT NULL,
  `status` char(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbtransaksi`
--

CREATE TABLE `tbtransaksi` (
  `id_transaksi` char(7) NOT NULL,
  `harga` int(9) NOT NULL,
  `id_konsumen` char(3) NOT NULL,
  `tgl_pemesanan` date NOT NULL,
  `status` char(1) NOT NULL,
  `jenis` char(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbkonsumen`
--
ALTER TABLE `tbkonsumen`
  ADD PRIMARY KEY (`id_konsumen`);

--
-- Indexes for table `tbkurir`
--
ALTER TABLE `tbkurir`
  ADD PRIMARY KEY (`id_kurir`);

--
-- Indexes for table `tbmakanan`
--
ALTER TABLE `tbmakanan`
  ADD PRIMARY KEY (`id_makanan`);

--
-- Indexes for table `tbpaket`
--
ALTER TABLE `tbpaket`
  ADD PRIMARY KEY (`id_paket`);

--
-- Indexes for table `tbtransaksi`
--
ALTER TABLE `tbtransaksi`
  ADD PRIMARY KEY (`id_transaksi`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbkonsumen`
--
ALTER TABLE `tbkonsumen`
  MODIFY `id_konsumen` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `tbkurir`
--
ALTER TABLE `tbkurir`
  MODIFY `id_kurir` int(2) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbmakanan`
--
ALTER TABLE `tbmakanan`
  MODIFY `id_makanan` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `tbpaket`
--
ALTER TABLE `tbpaket`
  MODIFY `id_paket` int(3) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
