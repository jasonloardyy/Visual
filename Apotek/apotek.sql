-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 28, 2019 at 09:08 AM
-- Server version: 10.1.37-MariaDB
-- PHP Version: 7.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `apotek`
--

-- --------------------------------------------------------

--
-- Table structure for table `antrian`
--

CREATE TABLE `antrian` (
  `id_antrian` int(4) NOT NULL,
  `id_penjualan` varchar(10) NOT NULL,
  `nama` varchar(16) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `golongan`
--

CREATE TABLE `golongan` (
  `id_golongan` char(1) NOT NULL,
  `nama_golongan` varchar(16) NOT NULL,
  `counter` int(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `golongan`
--

INSERT INTO `golongan` (`id_golongan`, `nama_golongan`, `counter`) VALUES
('B', 'OBAT BEBAS', 2),
('K', 'OBAT KERAS', 1),
('N', 'NARKOTIK', 1),
('P', 'PSIKOTROPIK', 0),
('T', 'BEBAS TERBATAS', 0);

-- --------------------------------------------------------

--
-- Table structure for table `kategori`
--

CREATE TABLE `kategori` (
  `id_kategori` char(1) NOT NULL,
  `nama_kategori` varchar(16) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `kategori`
--

INSERT INTO `kategori` (`id_kategori`, `nama_kategori`) VALUES
('B', 'BEBAS'),
('D', 'DAGANG');

-- --------------------------------------------------------

--
-- Table structure for table `keranjang`
--

CREATE TABLE `keranjang` (
  `id_antrian` int(4) NOT NULL,
  `id_obat` char(8) NOT NULL,
  `nama_obat` varchar(32) NOT NULL,
  `qty` int(4) NOT NULL,
  `harga` decimal(9,0) NOT NULL,
  `subtotal` decimal(9,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `obat`
--

CREATE TABLE `obat` (
  `id_obat` char(8) NOT NULL,
  `nama_obat` varchar(32) NOT NULL,
  `id_kategori` char(1) NOT NULL,
  `id_golongan` char(1) NOT NULL,
  `id_produksi` char(1) NOT NULL,
  `id_sediaan` char(2) NOT NULL,
  `id_satuan` char(2) NOT NULL,
  `tgl_expired` date NOT NULL,
  `stok` int(4) NOT NULL,
  `harga` decimal(9,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `obat`
--

INSERT INTO `obat` (`id_obat`, `nama_obat`, `id_kategori`, `id_golongan`, `id_produksi`, `id_sediaan`, `id_satuan`, `tgl_expired`, `stok`, `harga`) VALUES
('BBI01002', 'SANMOL', 'B', 'B', 'I', '01', '12', '2033-07-14', 1000, '15000'),
('DKL01001', 'FLUDEN', 'D', 'K', 'L', '01', '12', '2019-04-15', 200, '10000');

--
-- Triggers `obat`
--
DELIMITER $$
CREATE TRIGGER `update_counter_golongan` AFTER INSERT ON `obat` FOR EACH ROW BEGIN
UPDATE golongan g SET g.counter = g.counter+1 WHERE g.id_golongan = NEW.id_golongan;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `penjualan`
--

CREATE TABLE `penjualan` (
  `id_penjualan` varchar(10) NOT NULL,
  `tanggal` date NOT NULL,
  `jenis_penjualan` char(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `penjualan_detail`
--

CREATE TABLE `penjualan_detail` (
  `id_penjualan` varchar(10) NOT NULL,
  `id_obat` char(8) NOT NULL,
  `harga` decimal(9,0) NOT NULL,
  `qty` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `produksi`
--

CREATE TABLE `produksi` (
  `id_produksi` char(1) NOT NULL,
  `nama_produksi` varchar(16) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `produksi`
--

INSERT INTO `produksi` (`id_produksi`, `nama_produksi`) VALUES
('I', 'IMPOR'),
('L', 'LOKAL'),
('X', 'KHUSUS');

-- --------------------------------------------------------

--
-- Table structure for table `satuan`
--

CREATE TABLE `satuan` (
  `id_satuan` int(2) NOT NULL,
  `nama_satuan` varchar(16) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `satuan`
--

INSERT INTO `satuan` (`id_satuan`, `nama_satuan`) VALUES
(12, 'STRIP'),
(14, 'ASD');

-- --------------------------------------------------------

--
-- Table structure for table `sediaan`
--

CREATE TABLE `sediaan` (
  `id_sediaan` char(2) NOT NULL,
  `nama_sediaan` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sediaan`
--

INSERT INTO `sediaan` (`id_sediaan`, `nama_sediaan`) VALUES
('01', 'KAPSUL'),
('02', 'KAPSUL LUNAK'),
('23', 'POWDER'),
('24', 'BEDAK'),
('43', 'INJEKSI');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `golongan`
--
ALTER TABLE `golongan`
  ADD PRIMARY KEY (`id_golongan`);

--
-- Indexes for table `kategori`
--
ALTER TABLE `kategori`
  ADD PRIMARY KEY (`id_kategori`);

--
-- Indexes for table `obat`
--
ALTER TABLE `obat`
  ADD PRIMARY KEY (`id_obat`);

--
-- Indexes for table `penjualan`
--
ALTER TABLE `penjualan`
  ADD PRIMARY KEY (`id_penjualan`);

--
-- Indexes for table `produksi`
--
ALTER TABLE `produksi`
  ADD PRIMARY KEY (`id_produksi`);

--
-- Indexes for table `satuan`
--
ALTER TABLE `satuan`
  ADD PRIMARY KEY (`id_satuan`);

--
-- Indexes for table `sediaan`
--
ALTER TABLE `sediaan`
  ADD PRIMARY KEY (`id_sediaan`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `satuan`
--
ALTER TABLE `satuan`
  MODIFY `id_satuan` int(2) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
