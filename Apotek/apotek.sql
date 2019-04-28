/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50505
Source Host           : localhost:3306
Source Database       : apotek

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2019-04-28 23:42:32
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `antrian`
-- ----------------------------
DROP TABLE IF EXISTS `antrian`;
CREATE TABLE `antrian` (
  `id_antrian` varchar(4) NOT NULL,
  `id_penjualan` varchar(13) NOT NULL,
  `nama` varchar(16) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of antrian
-- ----------------------------

-- ----------------------------
-- Table structure for `golongan`
-- ----------------------------
DROP TABLE IF EXISTS `golongan`;
CREATE TABLE `golongan` (
  `id_golongan` char(1) NOT NULL,
  `nama_golongan` varchar(16) NOT NULL,
  `counter` int(3) NOT NULL,
  PRIMARY KEY (`id_golongan`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of golongan
-- ----------------------------
INSERT INTO `golongan` VALUES ('B', 'OBAT BEBAS', '2');
INSERT INTO `golongan` VALUES ('K', 'OBAT KERAS', '1');
INSERT INTO `golongan` VALUES ('N', 'NARKOTIK', '1');
INSERT INTO `golongan` VALUES ('P', 'PSIKOTROPIK', '0');
INSERT INTO `golongan` VALUES ('T', 'BEBAS TERBATAS', '0');

-- ----------------------------
-- Table structure for `kategori`
-- ----------------------------
DROP TABLE IF EXISTS `kategori`;
CREATE TABLE `kategori` (
  `id_kategori` char(1) NOT NULL,
  `nama_kategori` varchar(16) NOT NULL,
  PRIMARY KEY (`id_kategori`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of kategori
-- ----------------------------
INSERT INTO `kategori` VALUES ('B', 'BEBAS');
INSERT INTO `kategori` VALUES ('D', 'DAGANG');

-- ----------------------------
-- Table structure for `keranjang`
-- ----------------------------
DROP TABLE IF EXISTS `keranjang`;
CREATE TABLE `keranjang` (
  `id_antrian` varchar(4) NOT NULL,
  `no` int(3) NOT NULL,
  `id_obat` char(8) NOT NULL,
  `nama_obat` varchar(32) NOT NULL,
  `qty` int(4) NOT NULL,
  `harga` decimal(9,0) NOT NULL,
  `subtotal` decimal(9,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of keranjang
-- ----------------------------
INSERT INTO `keranjang` VALUES ('0001', '1', 'DKL01001', 'FLUDEN', '1', '10000', '10000');

-- ----------------------------
-- Table structure for `obat`
-- ----------------------------
DROP TABLE IF EXISTS `obat`;
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
  `harga` decimal(9,0) NOT NULL,
  PRIMARY KEY (`id_obat`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of obat
-- ----------------------------
INSERT INTO `obat` VALUES ('BBI01002', 'SANMOL', 'B', 'B', 'I', '01', '12', '2033-07-14', '1000', '15000');
INSERT INTO `obat` VALUES ('DKL01001', 'FLUDEN', 'D', 'K', 'L', '01', '12', '2019-04-15', '200', '10000');

-- ----------------------------
-- Table structure for `penjualan`
-- ----------------------------
DROP TABLE IF EXISTS `penjualan`;
CREATE TABLE `penjualan` (
  `id_penjualan` varchar(13) NOT NULL,
  `tanggal` date NOT NULL,
  `jenis_penjualan` char(1) NOT NULL,
  PRIMARY KEY (`id_penjualan`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of penjualan
-- ----------------------------

-- ----------------------------
-- Table structure for `penjualan_detail`
-- ----------------------------
DROP TABLE IF EXISTS `penjualan_detail`;
CREATE TABLE `penjualan_detail` (
  `id_penjualan` varchar(13) NOT NULL,
  `id_obat` char(8) NOT NULL,
  `harga` decimal(9,0) NOT NULL,
  `qty` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of penjualan_detail
-- ----------------------------

-- ----------------------------
-- Table structure for `produksi`
-- ----------------------------
DROP TABLE IF EXISTS `produksi`;
CREATE TABLE `produksi` (
  `id_produksi` char(1) NOT NULL,
  `nama_produksi` varchar(16) NOT NULL,
  PRIMARY KEY (`id_produksi`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of produksi
-- ----------------------------
INSERT INTO `produksi` VALUES ('I', 'IMPOR');
INSERT INTO `produksi` VALUES ('L', 'LOKAL');
INSERT INTO `produksi` VALUES ('X', 'KHUSUS');

-- ----------------------------
-- Table structure for `satuan`
-- ----------------------------
DROP TABLE IF EXISTS `satuan`;
CREATE TABLE `satuan` (
  `id_satuan` int(2) NOT NULL AUTO_INCREMENT,
  `nama_satuan` varchar(16) NOT NULL,
  PRIMARY KEY (`id_satuan`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of satuan
-- ----------------------------
INSERT INTO `satuan` VALUES ('12', 'STRIP');
INSERT INTO `satuan` VALUES ('14', 'ASD');

-- ----------------------------
-- Table structure for `sediaan`
-- ----------------------------
DROP TABLE IF EXISTS `sediaan`;
CREATE TABLE `sediaan` (
  `id_sediaan` char(2) NOT NULL,
  `nama_sediaan` varchar(32) NOT NULL,
  PRIMARY KEY (`id_sediaan`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of sediaan
-- ----------------------------
INSERT INTO `sediaan` VALUES ('01', 'KAPSUL');
INSERT INTO `sediaan` VALUES ('02', 'KAPSUL LUNAK');
INSERT INTO `sediaan` VALUES ('23', 'POWDER');
INSERT INTO `sediaan` VALUES ('24', 'BEDAK');
INSERT INTO `sediaan` VALUES ('43', 'INJEKSI');
DROP TRIGGER IF EXISTS `update_counter_golongan`;
DELIMITER ;;
CREATE TRIGGER `update_counter_golongan` AFTER INSERT ON `obat` FOR EACH ROW BEGIN
UPDATE golongan g SET g.counter = g.counter+1 WHERE g.id_golongan = NEW.id_golongan;
END
;;
DELIMITER ;
