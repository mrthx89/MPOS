/*
Navicat SQL Server Data Transfer

Source Server         : localhost
Source Server Version : 110000
Source Host           : (local):1433
Source Database       : DBMPOS
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 105000
File Encoding         : 65001

Date: 2015-12-15 22:26:05
*/


-- ----------------------------
-- Table structure for [HBarang]
-- ----------------------------
DROP TABLE [HBarang]
GO
CREATE TABLE [HBarang] (
[NoID] int NOT NULL ,
[IDKategori] int NULL ,
[Barcode] varchar(20) NULL ,
[Kode] varchar(20) NULL ,
[Nama] varchar(50) NULL ,
[Keterangan] varchar(100) NULL ,
[Alias] varchar(50) NULL ,
[QtyMax] numeric(18,3) NULL ,
[QtyMin] numeric(18,3) NULL ,
[IDSupplier1] int NULL ,
[IDSupplier2] int NULL ,
[IDSupplier3] int NULL ,
[IDSatuanBeli] int NULL ,
[HargaBeli] money NULL ,
[KonversiBeli] numeric(18,3) NULL ,
[HargaBeliNetto] money NULL ,
[HPP] money NULL ,
[SaldoStok] numeric(18,3) NULL ,
[IDSatuanJual] int NULL ,
[KonversiJual] numeric(18,3) NULL ,
[MarkUp] numeric(18,2) NULL ,
[HargaJual] money NULL ,
[IsAktif] bit NULL ,
[IDUserLastUpdate] int NULL ,
[LastUpdate] datetime NULL ,
[IsPoin] bit NULL ,
[Photo] image NULL 
)


GO

-- ----------------------------
-- Records of HBarang
-- ----------------------------
BEGIN TRANSACTION
GO
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HBarangDBarcode]
-- ----------------------------
DROP TABLE [HBarangDBarcode]
GO
CREATE TABLE [HBarangDBarcode] (
[NoID] int NOT NULL ,
[IDBarang] int NULL ,
[Barcode] varchar(20) NULL 
)


GO

-- ----------------------------
-- Records of HBarangDBarcode
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [HBarangDBarcode] ([NoID], [IDBarang], [Barcode]) VALUES (N'1', N'1', N'10200018');
INSERT INTO [HBarangDBarcode] ([NoID], [IDBarang], [Barcode]) VALUES (N'2', N'2', N'10100011');
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HBarangDHargaJual]
-- ----------------------------
DROP TABLE [HBarangDHargaJual]
GO
CREATE TABLE [HBarangDHargaJual] (
[NoID] int NOT NULL ,
[IDBarang] int NULL ,
[HargaJual] money NULL ,
[Qty1] numeric(18,3) NULL ,
[Qty2] numeric(18,3) NULL 
)


GO

-- ----------------------------
-- Records of HBarangDHargaJual
-- ----------------------------
BEGIN TRANSACTION
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HBeli]
-- ----------------------------
DROP TABLE [HBeli]
GO
CREATE TABLE [HBeli] (
[NoID] int NOT NULL ,
[Kode] varchar(30) NULL ,
[IDSupplier] int NULL ,
[Tanggal] datetime NULL ,
[TglTempo] datetime NULL ,
[Reff] varchar(50) NULL ,
[Keterangan] varchar(150) NULL ,
[Total] money NULL ,
[IDUserEntri] int NULL ,
[TglEntri] datetime NULL ,
[IDUserEdit] int NULL ,
[TglEdit] datetime NULL 
)


GO

-- ----------------------------
-- Records of HBeli
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [HBeli] ([NoID], [Kode], [IDSupplier], [Tanggal], [TglTempo], [Reff], [Keterangan], [Total], [IDUserEntri], [TglEntri], [IDUserEdit], [TglEdit]) VALUES (N'1', N'BL/2014/VI/00001', N'4', N'2014-06-19 00:00:00.000', N'2014-07-03 00:00:00.000', N'', N'', N'6500000.0000', N'1', N'2014-06-19 09:28:22.450', N'1', N'2014-12-31 17:16:06.540');
INSERT INTO [HBeli] ([NoID], [Kode], [IDSupplier], [Tanggal], [TglTempo], [Reff], [Keterangan], [Total], [IDUserEntri], [TglEntri], [IDUserEdit], [TglEdit]) VALUES (N'2', N'BL/2014/XII/00001', N'4', N'2014-12-31 00:00:00.000', N'2015-01-14 00:00:00.000', N'', N'', N'2000000.0000', N'1', N'2014-12-31 16:57:53.997', N'1', N'2014-12-31 17:16:03.487');
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HBeliD]
-- ----------------------------
DROP TABLE [HBeliD]
GO
CREATE TABLE [HBeliD] (
[NoID] int NOT NULL ,
[IDHeader] int NULL ,
[IDBarang] int NULL ,
[IDSatuan] int NULL ,
[Konversi] numeric(18,3) NULL ,
[Qty] numeric(18,2) NULL ,
[Harga] money NULL ,
[DiscProsen1] numeric(18,2) NULL ,
[DiscProsen2] numeric(18,2) NULL ,
[DiscRp] money NULL ,
[Jumlah] money NULL 
)


GO

-- ----------------------------
-- Records of HBeliD
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [HBeliD] ([NoID], [IDHeader], [IDBarang], [IDSatuan], [Konversi], [Qty], [Harga], [DiscProsen1], [DiscProsen2], [DiscRp], [Jumlah]) VALUES (N'1', N'1', N'1', N'3', N'40.000', N'5.00', N'500000.0000', N'.00', N'.00', N'.0000', N'2500000.0000');
INSERT INTO [HBeliD] ([NoID], [IDHeader], [IDBarang], [IDSatuan], [Konversi], [Qty], [Harga], [DiscProsen1], [DiscProsen2], [DiscRp], [Jumlah]) VALUES (N'2', N'1', N'2', N'3', N'100.000', N'10.00', N'400000.0000', N'.00', N'.00', N'.0000', N'4000000.0000');
INSERT INTO [HBeliD] ([NoID], [IDHeader], [IDBarang], [IDSatuan], [Konversi], [Qty], [Harga], [DiscProsen1], [DiscProsen2], [DiscRp], [Jumlah]) VALUES (N'3', N'2', N'2', N'3', N'100.000', N'5.00', N'400000.0000', N'.00', N'.00', N'.0000', N'2000000.0000');
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HGudang]
-- ----------------------------
DROP TABLE [HGudang]
GO
CREATE TABLE [HGudang] (
[NoID] int NOT NULL ,
[Kode] varchar(20) NULL ,
[Nama] varchar(50) NULL ,
[Alamat] varchar(150) NULL ,
[PenanggungJawab] varchar(50) NULL ,
[IsAktif] bit NULL 
)


GO

-- ----------------------------
-- Records of HGudang
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [HGudang] ([NoID], [Kode], [Nama], [Alamat], [PenanggungJawab], [IsAktif]) VALUES (N'1', N'GDU', N'GUDANG UTAMA', N'-', N'-', N'1');
INSERT INTO [HGudang] ([NoID], [Kode], [Nama], [Alamat], [PenanggungJawab], [IsAktif]) VALUES (N'2', N'GDBS', N'GUDANG BS', N'', N'', N'1');
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HJenisTransaksi]
-- ----------------------------
DROP TABLE [HJenisTransaksi]
GO
CREATE TABLE [HJenisTransaksi] (
[NoID] int NOT NULL ,
[Kode] varchar(10) NULL ,
[Nama] varchar(50) NULL ,
[NoUrut] smallint NULL 
)


GO

-- ----------------------------
-- Records of HJenisTransaksi
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [HJenisTransaksi] ([NoID], [Kode], [Nama], [NoUrut]) VALUES (N'1', N'BL', N'Pembelian', N'1');
INSERT INTO [HJenisTransaksi] ([NoID], [Kode], [Nama], [NoUrut]) VALUES (N'2', N'JL', N'Penjualan', N'2');
INSERT INTO [HJenisTransaksi] ([NoID], [Kode], [Nama], [NoUrut]) VALUES (N'3', N'RB', N'Retur Beli', N'3');
INSERT INTO [HJenisTransaksi] ([NoID], [Kode], [Nama], [NoUrut]) VALUES (N'4', N'RJ', N'Retur Jual', N'4');
INSERT INTO [HJenisTransaksi] ([NoID], [Kode], [Nama], [NoUrut]) VALUES (N'5', N'PY', N'Penyesuaian', N'5');
INSERT INTO [HJenisTransaksi] ([NoID], [Kode], [Nama], [NoUrut]) VALUES (N'6', N'PM', N'Pemakaian', N'6');
INSERT INTO [HJenisTransaksi] ([NoID], [Kode], [Nama], [NoUrut]) VALUES (N'7', N'SO', N'Sales Order', N'7');
INSERT INTO [HJenisTransaksi] ([NoID], [Kode], [Nama], [NoUrut]) VALUES (N'8', N'TP', N'Tukar Poin', N'8');
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HJual]
-- ----------------------------
DROP TABLE [HJual]
GO
CREATE TABLE [HJual] (
[NoID] int NOT NULL ,
[Kode] varchar(30) NULL ,
[IDCustomer] int NULL ,
[IDSalesman] int NULL ,
[Tanggal] datetime NULL ,
[TglTempo] datetime NULL ,
[Reff] varchar(50) NULL ,
[Keterangan] varchar(150) NULL ,
[Total] money NULL ,
[Bayar] money NULL ,
[Sisa] money NULL ,
[TotalPoin] numeric(18,2) NULL ,
[IDUserEntri] int NULL ,
[TglEntri] datetime NULL ,
[IDUserEdit] int NULL ,
[TglEdit] datetime NULL 
)


GO

-- ----------------------------
-- Records of HJual
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [HJual] ([NoID], [Kode], [IDCustomer], [IDSalesman], [Tanggal], [TglTempo], [Reff], [Keterangan], [Total], [Bayar], [Sisa], [TotalPoin], [IDUserEntri], [TglEntri], [IDUserEdit], [TglEdit]) VALUES (N'1', N'JL/2014/VI/00001', N'1', N'3', N'2014-06-20 00:00:00.000', N'2014-06-20 00:00:00.000', N'', N'', N'542000.0000', N'.0000', N'542000.0000', N'2.00', N'1', N'2014-06-20 03:54:17.370', N'1', N'2014-12-31 17:15:52.147');
INSERT INTO [HJual] ([NoID], [Kode], [IDCustomer], [IDSalesman], [Tanggal], [TglTempo], [Reff], [Keterangan], [Total], [Bayar], [Sisa], [TotalPoin], [IDUserEntri], [TglEntri], [IDUserEdit], [TglEdit]) VALUES (N'2', N'JL/2014/VI/00002', N'2', N'5', N'2014-06-27 00:00:00.000', N'2014-06-27 00:00:00.000', N'', N'', N'384000.0000', N'.0000', N'384000.0000', N'1.00', N'1', N'2014-06-27 05:27:32.330', N'1', N'2014-12-31 17:15:47.993');
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HJualD]
-- ----------------------------
DROP TABLE [HJualD]
GO
CREATE TABLE [HJualD] (
[NoID] int NOT NULL ,
[IDSalesOrderD] int NULL ,
[IDHeader] int NULL ,
[IDBarang] int NULL ,
[IDSatuan] int NULL ,
[Konversi] numeric(18,3) NULL ,
[Qty] numeric(18,2) NULL ,
[Harga] money NULL ,
[DiscProsen1] numeric(18,2) NULL ,
[DiscProsen2] numeric(18,2) NULL ,
[DiscRp] money NULL ,
[Jumlah] money NULL ,
[Keterangan] varchar(150) NULL 
)


GO

-- ----------------------------
-- Records of HJualD
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [HJualD] ([NoID], [IDSalesOrderD], [IDHeader], [IDBarang], [IDSatuan], [Konversi], [Qty], [Harga], [DiscProsen1], [DiscProsen2], [DiscRp], [Jumlah], [Keterangan]) VALUES (N'1', N'1', N'1', N'1', N'1', N'1.000', N'10.00', N'1400.0000', N'.00', N'.00', N'.0000', N'14000.0000', N'');
INSERT INTO [HJualD] ([NoID], [IDSalesOrderD], [IDHeader], [IDBarang], [IDSatuan], [Konversi], [Qty], [Harga], [DiscProsen1], [DiscProsen2], [DiscRp], [Jumlah], [Keterangan]) VALUES (N'2', N'2', N'1', N'2', N'1', N'1.000', N'5.00', N'4800.0000', N'.00', N'.00', N'.0000', N'24000.0000', N'');
INSERT INTO [HJualD] ([NoID], [IDSalesOrderD], [IDHeader], [IDBarang], [IDSatuan], [Konversi], [Qty], [Harga], [DiscProsen1], [DiscProsen2], [DiscRp], [Jumlah], [Keterangan]) VALUES (N'3', N'2', N'1', N'2', N'1', N'1.000', N'5.00', N'4800.0000', N'.00', N'.00', N'.0000', N'24000.0000', N'');
INSERT INTO [HJualD] ([NoID], [IDSalesOrderD], [IDHeader], [IDBarang], [IDSatuan], [Konversi], [Qty], [Harga], [DiscProsen1], [DiscProsen2], [DiscRp], [Jumlah], [Keterangan]) VALUES (N'4', N'-1', N'1', N'2', N'1', N'1.000', N'100.00', N'4800.0000', N'.00', N'.00', N'.0000', N'480000.0000', N'');
INSERT INTO [HJualD] ([NoID], [IDSalesOrderD], [IDHeader], [IDBarang], [IDSatuan], [Konversi], [Qty], [Harga], [DiscProsen1], [DiscProsen2], [DiscRp], [Jumlah], [Keterangan]) VALUES (N'5', N'-1', N'2', N'2', N'1', N'1.000', N'80.00', N'4800.0000', N'.00', N'.00', N'.0000', N'384000.0000', N'');
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HKartuPiutang]
-- ----------------------------
DROP TABLE [HKartuPiutang]
GO
CREATE TABLE [HKartuPiutang] (
[NoID] int NOT NULL IDENTITY(1,1) ,
[IDKontak] int NULL ,
[KodeReff] varchar(30) NULL ,
[Tanggal] datetime NULL ,
[IDJenisTransaksi] int NULL ,
[IDTransaksi] int NULL ,
[SaldoMasuk] numeric(18) NULL ,
[SaldoKeluar] numeric(18) NULL 
)


GO
DBCC CHECKIDENT(N'[HKartuPiutang]', RESEED, 20)
GO

-- ----------------------------
-- Records of HKartuPiutang
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [HKartuPiutang] ON
GO
INSERT INTO [HKartuPiutang] ([NoID], [IDKontak], [KodeReff], [Tanggal], [IDJenisTransaksi], [IDTransaksi], [SaldoMasuk], [SaldoKeluar]) VALUES (N'18', N'1', N'RJ/2014/VI/00001', N'2014-06-21 00:00:00.000', N'4', N'1', N'0', N'542000');
INSERT INTO [HKartuPiutang] ([NoID], [IDKontak], [KodeReff], [Tanggal], [IDJenisTransaksi], [IDTransaksi], [SaldoMasuk], [SaldoKeluar]) VALUES (N'19', N'2', N'JL/2014/VI/00002', N'2014-06-27 00:00:00.000', N'2', N'2', N'384000', N'0');
INSERT INTO [HKartuPiutang] ([NoID], [IDKontak], [KodeReff], [Tanggal], [IDJenisTransaksi], [IDTransaksi], [SaldoMasuk], [SaldoKeluar]) VALUES (N'20', N'1', N'JL/2014/VI/00001', N'2014-06-20 00:00:00.000', N'2', N'1', N'542000', N'0');
GO
SET IDENTITY_INSERT [HKartuPiutang] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HKartuPoin]
-- ----------------------------
DROP TABLE [HKartuPoin]
GO
CREATE TABLE [HKartuPoin] (
[NoID] int NOT NULL IDENTITY(1,1) ,
[IDCustomer] int NULL ,
[KodeReff] varchar(30) NULL ,
[Tanggal] datetime NULL ,
[IDJenisTransaksi] int NULL ,
[IDTransaksi] int NULL ,
[PoinMasuk] numeric(18) NULL ,
[PoinKeluar] numeric(18) NULL 
)


GO
DBCC CHECKIDENT(N'[HKartuPoin]', RESEED, 12)
GO

-- ----------------------------
-- Records of HKartuPoin
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [HKartuPoin] ON
GO
INSERT INTO [HKartuPoin] ([NoID], [IDCustomer], [KodeReff], [Tanggal], [IDJenisTransaksi], [IDTransaksi], [PoinMasuk], [PoinKeluar]) VALUES (N'6', N'1', N'JL/2014/XI/00001', N'2014-11-20 00:00:00.000', N'2', N'3', N'2', N'0');
INSERT INTO [HKartuPoin] ([NoID], [IDCustomer], [KodeReff], [Tanggal], [IDJenisTransaksi], [IDTransaksi], [PoinMasuk], [PoinKeluar]) VALUES (N'11', N'2', N'JL/2014/VI/00002', N'2014-06-27 00:00:00.000', N'2', N'2', N'1', N'0');
INSERT INTO [HKartuPoin] ([NoID], [IDCustomer], [KodeReff], [Tanggal], [IDJenisTransaksi], [IDTransaksi], [PoinMasuk], [PoinKeluar]) VALUES (N'12', N'1', N'JL/2014/VI/00001', N'2014-06-20 00:00:00.000', N'2', N'1', N'2', N'0');
GO
SET IDENTITY_INSERT [HKartuPoin] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HKartuStok]
-- ----------------------------
DROP TABLE [HKartuStok]
GO
CREATE TABLE [HKartuStok] (
[NoID] int NOT NULL IDENTITY(1,1) ,
[IDKontak] int NULL ,
[KodeReff] varchar(30) NULL ,
[Tanggal] datetime NULL ,
[IDBarang] int NULL ,
[IDJenisTransaksi] int NULL ,
[IDTransaksi] int NULL ,
[IDSatuan] int NULL ,
[Konversi] numeric(18,3) NULL ,
[QtyMasuk] numeric(18) NULL ,
[QtyKeluar] numeric(18) NULL ,
[SaldoAkhir] numeric(18) NULL ,
[HPP] money NULL ,
[HargaBeliTerakhir] money NULL 
)


GO
DBCC CHECKIDENT(N'[HKartuStok]', RESEED, 140)
GO

-- ----------------------------
-- Records of HKartuStok
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [HKartuStok] ON
GO
INSERT INTO [HKartuStok] ([NoID], [IDKontak], [KodeReff], [Tanggal], [IDBarang], [IDJenisTransaksi], [IDTransaksi], [IDSatuan], [Konversi], [QtyMasuk], [QtyKeluar], [SaldoAkhir], [HPP], [HargaBeliTerakhir]) VALUES (N'127', N'1', N'RJ/2014/VI/00001', N'2014-06-21 00:00:00.000', N'1', N'4', N'1', N'1', N'1.000', N'10', N'0', N'222', N'1400.0000', N'1400.0000');
INSERT INTO [HKartuStok] ([NoID], [IDKontak], [KodeReff], [Tanggal], [IDBarang], [IDJenisTransaksi], [IDTransaksi], [IDSatuan], [Konversi], [QtyMasuk], [QtyKeluar], [SaldoAkhir], [HPP], [HargaBeliTerakhir]) VALUES (N'128', N'1', N'RJ/2014/VI/00001', N'2014-06-21 00:00:00.000', N'2', N'4', N'1', N'1', N'1.000', N'5', N'0', N'993', N'4800.0000', N'4800.0000');
INSERT INTO [HKartuStok] ([NoID], [IDKontak], [KodeReff], [Tanggal], [IDBarang], [IDJenisTransaksi], [IDTransaksi], [IDSatuan], [Konversi], [QtyMasuk], [QtyKeluar], [SaldoAkhir], [HPP], [HargaBeliTerakhir]) VALUES (N'129', N'1', N'RJ/2014/VI/00001', N'2014-06-21 00:00:00.000', N'2', N'4', N'1', N'1', N'1.000', N'5', N'0', N'993', N'4800.0000', N'4800.0000');
INSERT INTO [HKartuStok] ([NoID], [IDKontak], [KodeReff], [Tanggal], [IDBarang], [IDJenisTransaksi], [IDTransaksi], [IDSatuan], [Konversi], [QtyMasuk], [QtyKeluar], [SaldoAkhir], [HPP], [HargaBeliTerakhir]) VALUES (N'130', N'1', N'RJ/2014/VI/00001', N'2014-06-21 00:00:00.000', N'2', N'4', N'1', N'1', N'1.000', N'100', N'0', N'1088', N'4800.0000', N'4800.0000');
INSERT INTO [HKartuStok] ([NoID], [IDKontak], [KodeReff], [Tanggal], [IDBarang], [IDJenisTransaksi], [IDTransaksi], [IDSatuan], [Konversi], [QtyMasuk], [QtyKeluar], [SaldoAkhir], [HPP], [HargaBeliTerakhir]) VALUES (N'131', N'2', N'JL/2014/VI/00002', N'2014-06-27 00:00:00.000', N'2', N'2', N'2', N'1', N'1.000', N'0', N'80', N'1148', N'4800.0000', N'4800.0000');
INSERT INTO [HKartuStok] ([NoID], [IDKontak], [KodeReff], [Tanggal], [IDBarang], [IDJenisTransaksi], [IDTransaksi], [IDSatuan], [Konversi], [QtyMasuk], [QtyKeluar], [SaldoAkhir], [HPP], [HargaBeliTerakhir]) VALUES (N'132', N'1', N'JL/2014/VI/00001', N'2014-06-20 00:00:00.000', N'1', N'2', N'1', N'1', N'1.000', N'0', N'10', N'232', N'1400.0000', N'1400.0000');
INSERT INTO [HKartuStok] ([NoID], [IDKontak], [KodeReff], [Tanggal], [IDBarang], [IDJenisTransaksi], [IDTransaksi], [IDSatuan], [Konversi], [QtyMasuk], [QtyKeluar], [SaldoAkhir], [HPP], [HargaBeliTerakhir]) VALUES (N'133', N'1', N'JL/2014/VI/00001', N'2014-06-20 00:00:00.000', N'2', N'2', N'1', N'1', N'1.000', N'0', N'5', N'893', N'4800.0000', N'4800.0000');
INSERT INTO [HKartuStok] ([NoID], [IDKontak], [KodeReff], [Tanggal], [IDBarang], [IDJenisTransaksi], [IDTransaksi], [IDSatuan], [Konversi], [QtyMasuk], [QtyKeluar], [SaldoAkhir], [HPP], [HargaBeliTerakhir]) VALUES (N'134', N'1', N'JL/2014/VI/00001', N'2014-06-20 00:00:00.000', N'2', N'2', N'1', N'1', N'1.000', N'0', N'5', N'893', N'4800.0000', N'4800.0000');
INSERT INTO [HKartuStok] ([NoID], [IDKontak], [KodeReff], [Tanggal], [IDBarang], [IDJenisTransaksi], [IDTransaksi], [IDSatuan], [Konversi], [QtyMasuk], [QtyKeluar], [SaldoAkhir], [HPP], [HargaBeliTerakhir]) VALUES (N'135', N'1', N'JL/2014/VI/00001', N'2014-06-20 00:00:00.000', N'2', N'2', N'1', N'1', N'1.000', N'0', N'100', N'1178', N'4800.0000', N'4800.0000');
INSERT INTO [HKartuStok] ([NoID], [IDKontak], [KodeReff], [Tanggal], [IDBarang], [IDJenisTransaksi], [IDTransaksi], [IDSatuan], [Konversi], [QtyMasuk], [QtyKeluar], [SaldoAkhir], [HPP], [HargaBeliTerakhir]) VALUES (N'136', N'1', N'PY/2014/VI/00001', N'2014-06-19 00:00:00.000', N'1', N'5', N'1', N'2', N'1.000', N'12', N'0', N'224', N'870.0000', N'870.0000');
INSERT INTO [HKartuStok] ([NoID], [IDKontak], [KodeReff], [Tanggal], [IDBarang], [IDJenisTransaksi], [IDTransaksi], [IDSatuan], [Konversi], [QtyMasuk], [QtyKeluar], [SaldoAkhir], [HPP], [HargaBeliTerakhir]) VALUES (N'137', N'1', N'PY/2014/VI/00001', N'2014-06-19 00:00:00.000', N'2', N'5', N'1', N'3', N'12.000', N'-1', N'0', N'976', N'50.0000', N'50.0000');
INSERT INTO [HKartuStok] ([NoID], [IDKontak], [KodeReff], [Tanggal], [IDBarang], [IDJenisTransaksi], [IDTransaksi], [IDSatuan], [Konversi], [QtyMasuk], [QtyKeluar], [SaldoAkhir], [HPP], [HargaBeliTerakhir]) VALUES (N'138', N'4', N'BL/2014/XII/00001', N'2014-12-31 00:00:00.000', N'2', N'1', N'2', N'3', N'100.000', N'5', N'0', N'1908', N'400000.0000', N'400000.0000');
INSERT INTO [HKartuStok] ([NoID], [IDKontak], [KodeReff], [Tanggal], [IDBarang], [IDJenisTransaksi], [IDTransaksi], [IDSatuan], [Konversi], [QtyMasuk], [QtyKeluar], [SaldoAkhir], [HPP], [HargaBeliTerakhir]) VALUES (N'139', N'4', N'BL/2014/VI/00001', N'2014-06-19 00:00:00.000', N'1', N'1', N'1', N'3', N'40.000', N'5', N'0', N'412', N'500000.0000', N'500000.0000');
INSERT INTO [HKartuStok] ([NoID], [IDKontak], [KodeReff], [Tanggal], [IDBarang], [IDJenisTransaksi], [IDTransaksi], [IDSatuan], [Konversi], [QtyMasuk], [QtyKeluar], [SaldoAkhir], [HPP], [HargaBeliTerakhir]) VALUES (N'140', N'4', N'BL/2014/VI/00001', N'2014-06-19 00:00:00.000', N'2', N'1', N'1', N'3', N'100.000', N'10', N'0', N'1988', N'400000.0000', N'400000.0000');
GO
SET IDENTITY_INSERT [HKartuStok] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HKategori]
-- ----------------------------
DROP TABLE [HKategori]
GO
CREATE TABLE [HKategori] (
[NoID] int NOT NULL ,
[IDKategori] int NULL ,
[Kode] varchar(10) NULL ,
[Nama] varchar(50) NULL ,
[Keterangan] varchar(150) NULL ,
[IsAktif] bit NULL 
)


GO

-- ----------------------------
-- Records of HKategori
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [HKategori] ([NoID], [IDKategori], [Kode], [Nama], [Keterangan], [IsAktif]) VALUES (N'1', N'0', N'100', N'SUSU', N'', N'1');
INSERT INTO [HKategori] ([NoID], [IDKategori], [Kode], [Nama], [Keterangan], [IsAktif]) VALUES (N'2', N'0', N'200', N'DIAMPERS', N'', N'1');
INSERT INTO [HKategori] ([NoID], [IDKategori], [Kode], [Nama], [Keterangan], [IsAktif]) VALUES (N'3', N'0', N'300', N'ROKOK', N'', N'1');
INSERT INTO [HKategori] ([NoID], [IDKategori], [Kode], [Nama], [Keterangan], [IsAktif]) VALUES (N'4', N'1', N'101', N'INDOMILK', N'', N'1');
INSERT INTO [HKategori] ([NoID], [IDKategori], [Kode], [Nama], [Keterangan], [IsAktif]) VALUES (N'5', N'1', N'102', N'FRISIAN FLAG', N'', N'1');
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HKontak]
-- ----------------------------
DROP TABLE [HKontak]
GO
CREATE TABLE [HKontak] (
[NoID] int NOT NULL ,
[Kode] varchar(10) NULL ,
[Nama] varchar(50) NULL ,
[Alamat] varchar(100) NULL ,
[Kota] varchar(20) NULL ,
[Telp] varchar(20) NULL ,
[HP] varchar(20) NULL ,
[ContactPerson] varchar(50) NULL ,
[Keterangan] varchar(150) NULL ,
[JTSupplier] numeric(18) NULL ,
[JTCustomer] numeric(18) NULL ,
[LimitHutang] money NULL ,
[LimitPiutang] money NULL ,
[IsAktif] bit NULL ,
[IsSupplier] bit NULL DEFAULT ((0)) ,
[IsCustomer] bit NULL DEFAULT ((0)) ,
[IsPegawai] bit NULL ,
[IDSalesman] int NULL 
)


GO

-- ----------------------------
-- Records of HKontak
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [HKontak] ([NoID], [Kode], [Nama], [Alamat], [Kota], [Telp], [HP], [ContactPerson], [Keterangan], [JTSupplier], [JTCustomer], [LimitHutang], [LimitPiutang], [IsAktif], [IsSupplier], [IsCustomer], [IsPegawai], [IDSalesman]) VALUES (N'1', N'YH', N'YH', N'SIMOWAU INDAH BLOK B-46B
SEPANJANG', N'SIDOARJO', N'-', N'085777109441', N'', N'', N'0', N'0', N'.0000', N'.0000', N'1', N'0', N'1', N'0', N'3');
INSERT INTO [HKontak] ([NoID], [Kode], [Nama], [Alamat], [Kota], [Telp], [HP], [ContactPerson], [Keterangan], [JTSupplier], [JTCustomer], [LimitHutang], [LimitPiutang], [IsAktif], [IsSupplier], [IsCustomer], [IsPegawai], [IDSalesman]) VALUES (N'2', N'WA', N'WINDI ASTRID', N'F', N'', N'', N'', N'', N'', N'0', N'0', N'.0000', N'.0000', N'1', N'0', N'1', N'0', N'5');
INSERT INTO [HKontak] ([NoID], [Kode], [Nama], [Alamat], [Kota], [Telp], [HP], [ContactPerson], [Keterangan], [JTSupplier], [JTCustomer], [LimitHutang], [LimitPiutang], [IsAktif], [IsSupplier], [IsCustomer], [IsPegawai], [IDSalesman]) VALUES (N'3', N'BD', N'BUDI', N'', N'', N'', N'', N'', N'', N'0', N'0', N'.0000', N'.0000', N'1', N'0', N'0', N'1', N'-1');
INSERT INTO [HKontak] ([NoID], [Kode], [Nama], [Alamat], [Kota], [Telp], [HP], [ContactPerson], [Keterangan], [JTSupplier], [JTCustomer], [LimitHutang], [LimitPiutang], [IsAktif], [IsSupplier], [IsCustomer], [IsPegawai], [IDSalesman]) VALUES (N'4', N'S001', N'PASAR SENIN', N'', N'', N'', N'', N'', N'', N'14', N'0', N'.0000', N'.0000', N'1', N'1', N'0', N'0', N'-1');
INSERT INTO [HKontak] ([NoID], [Kode], [Nama], [Alamat], [Kota], [Telp], [HP], [ContactPerson], [Keterangan], [JTSupplier], [JTCustomer], [LimitHutang], [LimitPiutang], [IsAktif], [IsSupplier], [IsCustomer], [IsPegawai], [IDSalesman]) VALUES (N'5', N'C001', N'ENGGAR', N'', N'', N'', N'', N'', N'', N'0', N'0', N'.0000', N'.0000', N'1', N'0', N'0', N'1', N'0');
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HMenu]
-- ----------------------------
DROP TABLE [HMenu]
GO
CREATE TABLE [HMenu] (
[NoID] int NOT NULL IDENTITY(1,1) ,
[Kode] varchar(30) NULL ,
[Caption] varchar(150) NULL ,
[CaptionInDaftar] varchar(150) NULL ,
[ObjectToRun] varchar(50) NULL ,
[Icon] numeric(18) NULL ,
[NoUrut] numeric(18) NULL ,
[IsAktif] bit NULL DEFAULT ((1)) ,
[IDParent] int NULL ,
[IsBarSubItem] bit NULL ,
[IDBarSubItem] int NULL ,
[TypeMenu] smallint NULL DEFAULT ((0)) ,
[IsBeginGroup] bit NULL DEFAULT ((0)) 
)


GO
DBCC CHECKIDENT(N'[HMenu]', RESEED, 33)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'HMenu', 
'COLUMN', N'TypeMenu')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'0: Default, 1: Large, 2: Small'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'HMenu'
, @level2type = 'COLUMN', @level2name = N'TypeMenu'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'0: Default, 1: Large, 2: Small'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'HMenu'
, @level2type = 'COLUMN', @level2name = N'TypeMenu'
GO

-- ----------------------------
-- Records of HMenu
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [HMenu] ON
GO
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'1', N'Master', N'Master', null, null, N'0', N'1', N'1', N'-1', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'2', N'Pembelian', N'Pembelian', null, null, N'1', N'2', N'1', N'-1', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'3', N'Penjualan', N'Penjualan', null, null, N'2', N'3', N'1', N'-1', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'4', N'Internal', N'Internal', null, null, N'3', N'4', N'0', N'-1', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'5', N'SettingAwal', N'Setting Awal', null, null, N'4', N'5', N'0', N'-1', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'6', N'Laporan', N'Laporan', null, null, N'5', N'6', N'1', N'-1', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'8', N'DaftarSatuan', N'Daftar Satuan', N'Daftar Satuan', N'DaftarSatuan', N'0', N'1', N'1', N'1', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'9', N'DaftarKategori', N'Daftar Kategori', N'Daftar Kategori', N'DaftarKategori', N'0', N'2', N'1', N'1', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'10', N'DaftarBarang', N'Daftar Barang', N'Daftar Barang', N'DaftarBarang', N'0', N'4', N'1', N'1', null, null, N'1', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'11', N'DaftarSupplierCustomer', N'Daftar Supplier, Customer, dan Salesman', N'Daftar Supplier, Customer, dan Salesman', N'DaftarSupplierCustomer', N'0', N'3', N'1', N'1', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'12', N'DaftarPembelian', N'Daftar Pembelian', N'Daftar Pembelian', N'DaftarPembelian', N'1', N'1', N'1', N'2', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'13', N'DaftarPembayaranHutang', N'Daftar Pembayaran Hutang', N'Daftar Pembayaran Hutang', N'DaftarPembayaranHutang', N'1', N'3', N'0', N'2', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'14', N'DaftarPenjualanPOS', N'Daftar Penjualan POS', N'Daftar Penjualan POS', N'DaftarPenjualanPOS', N'2', N'1', N'0', N'3', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'15', N'DaftarPenjualan', N'Daftar Penjualan Customer', N'Daftar Penjualan Customer', N'DaftarPenjualan', N'2', N'2', N'1', N'3', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'16', N'DaftarPembayaranPiutang', N'Daftar Pembayaran Piutang', N'Daftar Pembayaran Piutang', N'DaftarPembayaranPiutang', N'2', N'4', N'1', N'3', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'17', N'DaftarReturPembelian', N'Daftar Retur Pembelian', N'Daftar Retur Pembelian', N'DaftarReturPembelian', N'1', N'2', N'0', N'2', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'18', N'DaftarReturPenjualan', N'Daftar Retur Penjualan', N'Daftar Retur Penjualan', N'DaftarReturPenjualan', N'2', N'3', N'1', N'3', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'19', N'SettingPoin', N'Setting Poin', N'Setting Poin', N'SettingPoin', N'0', N'6', N'1', N'1', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'20', N'DaftarGudang', N'Daftar Gudang', N'Daftar Gudang', N'DaftarGudang', N'0', N'5', N'1', N'1', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'21', N'DaftarTukarPoin', N'Daftar Tukar Poin', N'Daftar Tukar Poin', N'DaftarTukarPoin', N'0', N'7', N'1', N'1', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'22', N'DaftarPenyesuaian', N'Daftar Penyesuaian Stok', N'Daftar Penyesuaian Stok', N'DaftarPenyesuaian', N'1', N'2', N'1', N'2', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'24', N'DaftarSalesOrder', N'Daftar Sales Order', N'Daftar Sales Order', N'DaftarSalesOrder', N'2', N'0', N'1', N'3', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'25', N'LaporanKartuStok', N'Laporan Kartu Stok', N'Laporan Kartu Stok', N'LaporanKartuStok', N'5', N'1', N'1', N'6', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'26', N'LaporanSaldoStok', N'Laporan Saldo Stok', N'Laporan Saldo Stok', N'LaporanSaldoStok', N'5', N'2', N'1', N'6', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'27', N'LaporanSaldoPiutang', N'Laporan Saldo Piutang', N'Laporan Saldo Piutang', N'LaporanSaldoPiutang', N'5', N'3', N'1', N'6', null, null, N'0', N'1');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'28', N'LaporanSOMenggantung', N'Laporan SO Menggantung', N'Laporan SO Menggantung', N'LaporanSOMenggantung', N'5', N'4', N'1', N'6', null, null, N'0', N'1');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'29', N'LaporanPenjualan', N'Laporan Penjualan', N'Laporan Penjualan', N'LaporanPenjualan', N'5', N'5', N'0', N'6', N'1', null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'30', N'LaporanPenjualanPerSales', N'Laporan Penjualan Per Sales', N'Laporan Penjualan Per Sales', N'LaporanPenjualanPerSales', N'5', N'5', N'1', N'6', null, null, N'0', N'1');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'31', N'LaporanPenjualanPalingLaku', N'Laporan Penjualan Paling Laku', N'Laporan Penjualan Paling Laku', N'LaporanPenjualanPalingLaku', N'5', N'6', N'1', N'6', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'32', N'LaporanPenjualanPerCustomer', N'Laporan Penjualan Per Customer', N'Laporan Penjualan Per Customer', N'LaporanPenjualanPerCustomer', N'5', N'7', N'1', N'6', null, null, N'0', N'0');
INSERT INTO [HMenu] ([NoID], [Kode], [Caption], [CaptionInDaftar], [ObjectToRun], [Icon], [NoUrut], [IsAktif], [IDParent], [IsBarSubItem], [IDBarSubItem], [TypeMenu], [IsBeginGroup]) VALUES (N'33', N'LaporanPembelianDetil', N'Laporan Pembelian Detil', N'Laporan Pembelian Detil', N'LaporanPembelianDetil', N'5', N'8', N'1', N'6', null, null, N'0', N'1');
GO
SET IDENTITY_INSERT [HMenu] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HPenyesuaian]
-- ----------------------------
DROP TABLE [HPenyesuaian]
GO
CREATE TABLE [HPenyesuaian] (
[NoID] int NOT NULL ,
[Kode] varchar(30) NULL ,
[Tanggal] datetime NULL ,
[Reff] varchar(50) NULL ,
[Keterangan] varchar(150) NULL ,
[Total] money NULL ,
[IDUserEntri] int NULL ,
[TglEntri] datetime NULL ,
[IDUserEdit] int NULL ,
[TglEdit] datetime NULL 
)


GO

-- ----------------------------
-- Records of HPenyesuaian
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [HPenyesuaian] ([NoID], [Kode], [Tanggal], [Reff], [Keterangan], [Total], [IDUserEntri], [TglEntri], [IDUserEdit], [TglEdit]) VALUES (N'1', N'PY/2014/VI/00001', N'2014-06-19 00:00:00.000', N'', N'', N'10390.0000', N'1', N'2014-06-19 01:46:57.600', N'1', N'2014-12-31 17:15:59.860');
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HPenyesuaianD]
-- ----------------------------
DROP TABLE [HPenyesuaianD]
GO
CREATE TABLE [HPenyesuaianD] (
[NoID] int NOT NULL ,
[IDHeader] int NULL ,
[IDBarang] int NULL ,
[IDSatuan] int NULL ,
[Konversi] numeric(18,3) NULL ,
[Qty] numeric(18,2) NULL ,
[HargaPokok] money NULL ,
[Jumlah] money NULL ,
[Keterangan] varchar(150) NULL 
)


GO

-- ----------------------------
-- Records of HPenyesuaianD
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [HPenyesuaianD] ([NoID], [IDHeader], [IDBarang], [IDSatuan], [Konversi], [Qty], [HargaPokok], [Jumlah], [Keterangan]) VALUES (N'1', N'1', N'1', N'2', N'1.000', N'12.00', N'870.0000', N'10440.0000', N'');
INSERT INTO [HPenyesuaianD] ([NoID], [IDHeader], [IDBarang], [IDSatuan], [Konversi], [Qty], [HargaPokok], [Jumlah], [Keterangan]) VALUES (N'2', N'1', N'2', N'3', N'12.000', N'-1.00', N'50.0000', N'-50.0000', N'');
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HReturJual]
-- ----------------------------
DROP TABLE [HReturJual]
GO
CREATE TABLE [HReturJual] (
[NoID] int NOT NULL ,
[Kode] varchar(30) NULL ,
[IDCustomer] int NULL ,
[Tanggal] datetime NULL ,
[TglTempo] datetime NULL ,
[Reff] varchar(50) NULL ,
[Keterangan] varchar(150) NULL ,
[Total] money NULL ,
[Bayar] money NULL ,
[Sisa] money NULL ,
[IDUserEntri] int NULL ,
[TglEntri] datetime NULL ,
[IDUserEdit] int NULL ,
[TglEdit] datetime NULL 
)


GO

-- ----------------------------
-- Records of HReturJual
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [HReturJual] ([NoID], [Kode], [IDCustomer], [Tanggal], [TglTempo], [Reff], [Keterangan], [Total], [Bayar], [Sisa], [IDUserEntri], [TglEntri], [IDUserEdit], [TglEdit]) VALUES (N'1', N'RJ/2014/VI/00001', N'1', N'2014-06-21 00:00:00.000', N'2014-06-21 00:00:00.000', N'', N'', N'542000.0000', N'.0000', N'542000.0000', N'1', N'2014-06-21 07:09:37.527', N'1', N'2014-12-31 17:15:44.200');
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HReturJualD]
-- ----------------------------
DROP TABLE [HReturJualD]
GO
CREATE TABLE [HReturJualD] (
[NoID] int NOT NULL ,
[IDJualD] int NULL ,
[IDHeader] int NULL ,
[IDBarang] int NULL ,
[IDSatuan] int NULL ,
[Konversi] numeric(18,3) NULL ,
[Qty] numeric(18,2) NULL ,
[Harga] money NULL ,
[DiscProsen1] numeric(18,2) NULL ,
[DiscProsen2] numeric(18,2) NULL ,
[DiscRp] money NULL ,
[Jumlah] money NULL ,
[Keterangan] varchar(150) NULL 
)


GO

-- ----------------------------
-- Records of HReturJualD
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [HReturJualD] ([NoID], [IDJualD], [IDHeader], [IDBarang], [IDSatuan], [Konversi], [Qty], [Harga], [DiscProsen1], [DiscProsen2], [DiscRp], [Jumlah], [Keterangan]) VALUES (N'1', N'1', N'1', N'1', N'1', N'1.000', N'10.00', N'1400.0000', N'.00', N'.00', N'.0000', N'14000.0000', N'');
INSERT INTO [HReturJualD] ([NoID], [IDJualD], [IDHeader], [IDBarang], [IDSatuan], [Konversi], [Qty], [Harga], [DiscProsen1], [DiscProsen2], [DiscRp], [Jumlah], [Keterangan]) VALUES (N'2', N'2', N'1', N'2', N'1', N'1.000', N'5.00', N'4800.0000', N'.00', N'.00', N'.0000', N'24000.0000', N'');
INSERT INTO [HReturJualD] ([NoID], [IDJualD], [IDHeader], [IDBarang], [IDSatuan], [Konversi], [Qty], [Harga], [DiscProsen1], [DiscProsen2], [DiscRp], [Jumlah], [Keterangan]) VALUES (N'3', N'3', N'1', N'2', N'1', N'1.000', N'5.00', N'4800.0000', N'.00', N'.00', N'.0000', N'24000.0000', N'');
INSERT INTO [HReturJualD] ([NoID], [IDJualD], [IDHeader], [IDBarang], [IDSatuan], [Konversi], [Qty], [Harga], [DiscProsen1], [DiscProsen2], [DiscRp], [Jumlah], [Keterangan]) VALUES (N'4', N'4', N'1', N'2', N'1', N'1.000', N'100.00', N'4800.0000', N'.00', N'.00', N'.0000', N'480000.0000', N'');
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HSalesOrder]
-- ----------------------------
DROP TABLE [HSalesOrder]
GO
CREATE TABLE [HSalesOrder] (
[NoID] int NOT NULL ,
[Kode] varchar(30) NULL ,
[IDCustomer] int NULL ,
[IDSalesman] int NULL ,
[Tanggal] datetime NULL ,
[TglTempo] datetime NULL ,
[Reff] varchar(50) NULL ,
[Keterangan] varchar(150) NULL ,
[Total] money NULL ,
[IDUserEntri] int NULL ,
[TglEntri] datetime NULL ,
[IDUserEdit] int NULL ,
[TglEdit] datetime NULL 
)


GO

-- ----------------------------
-- Records of HSalesOrder
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [HSalesOrder] ([NoID], [Kode], [IDCustomer], [IDSalesman], [Tanggal], [TglTempo], [Reff], [Keterangan], [Total], [IDUserEntri], [TglEntri], [IDUserEdit], [TglEdit]) VALUES (N'1', N'SO/2014/VI/00001', N'1', N'3', N'2014-06-19 00:00:00.000', N'2014-06-19 00:00:00.000', N'', N'', N'62000.0000', N'1', N'2014-06-19 09:32:57.653', N'1', N'2014-12-31 17:15:55.513');
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HSalesOrderD]
-- ----------------------------
DROP TABLE [HSalesOrderD]
GO
CREATE TABLE [HSalesOrderD] (
[NoID] int NOT NULL ,
[IDHeader] int NULL ,
[IDBarang] int NULL ,
[IDSatuan] int NULL ,
[Konversi] numeric(18,3) NULL ,
[Qty] numeric(18,2) NULL ,
[Harga] money NULL ,
[DiscProsen1] numeric(18,2) NULL ,
[DiscProsen2] numeric(18,2) NULL ,
[DiscRp] money NULL ,
[Jumlah] money NULL ,
[Keterangan] varchar(150) NULL 
)


GO

-- ----------------------------
-- Records of HSalesOrderD
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [HSalesOrderD] ([NoID], [IDHeader], [IDBarang], [IDSatuan], [Konversi], [Qty], [Harga], [DiscProsen1], [DiscProsen2], [DiscRp], [Jumlah], [Keterangan]) VALUES (N'1', N'1', N'1', N'1', N'1.000', N'10.00', N'1400.0000', N'.00', N'.00', N'.0000', N'14000.0000', N'');
INSERT INTO [HSalesOrderD] ([NoID], [IDHeader], [IDBarang], [IDSatuan], [Konversi], [Qty], [Harga], [DiscProsen1], [DiscProsen2], [DiscRp], [Jumlah], [Keterangan]) VALUES (N'2', N'1', N'2', N'1', N'1.000', N'10.00', N'4800.0000', N'.00', N'.00', N'.0000', N'48000.0000', N'');
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HSatuan]
-- ----------------------------
DROP TABLE [HSatuan]
GO
CREATE TABLE [HSatuan] (
[NoID] int NOT NULL ,
[Kode] varchar(10) NULL ,
[Nama] varchar(50) NULL ,
[Konversi] numeric(18,3) NULL ,
[IsAktif] bit NULL 
)


GO

-- ----------------------------
-- Records of HSatuan
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [HSatuan] ([NoID], [Kode], [Nama], [Konversi], [IsAktif]) VALUES (N'1', N'PCS', N'PCS', N'.000', N'1');
INSERT INTO [HSatuan] ([NoID], [Kode], [Nama], [Konversi], [IsAktif]) VALUES (N'2', N'LSN', N'LUSIN', N'.000', N'1');
INSERT INTO [HSatuan] ([NoID], [Kode], [Nama], [Konversi], [IsAktif]) VALUES (N'3', N'CRT', N'CARTON', N'.000', N'1');
INSERT INTO [HSatuan] ([NoID], [Kode], [Nama], [Konversi], [IsAktif]) VALUES (N'4', N'DUS', N'DUS', N'.000', N'1');
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HSettingPoin]
-- ----------------------------
DROP TABLE [HSettingPoin]
GO
CREATE TABLE [HSettingPoin] (
[NoID] int NOT NULL ,
[MinimumBelanjaDapatPoin] money NULL ,
[SyaratBelanjaDapatPoin] money NULL ,
[IsKelipatan] bit NULL ,
[NilaiPoin] numeric(18) NULL ,
[IsCustomer] bit NULL 
)


GO

-- ----------------------------
-- Records of HSettingPoin
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [HSettingPoin] ([NoID], [MinimumBelanjaDapatPoin], [SyaratBelanjaDapatPoin], [IsKelipatan], [NilaiPoin], [IsCustomer]) VALUES (N'1', N'200000.0000', N'200000.0000', N'1', N'1', N'1');
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HTukarPoin]
-- ----------------------------
DROP TABLE [HTukarPoin]
GO
CREATE TABLE [HTukarPoin] (
[NoID] int NOT NULL ,
[Kode] varchar(10) NULL ,
[Tanggal] datetime NULL ,
[IDCustomer] int NULL ,
[SaldoPoin] numeric(18) NULL ,
[TukarPoin] numeric(18) NULL ,
[Keteragan] varchar(150) NULL 
)


GO

-- ----------------------------
-- Records of HTukarPoin
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [HTukarPoin] ([NoID], [Kode], [Tanggal], [IDCustomer], [SaldoPoin], [TukarPoin], [Keteragan]) VALUES (N'1', N'TP00001', N'2014-06-15 00:00:00.000', N'2', N'50', N'10', N'BINGKISAN');
INSERT INTO [HTukarPoin] ([NoID], [Kode], [Tanggal], [IDCustomer], [SaldoPoin], [TukarPoin], [Keteragan]) VALUES (N'2', N'TP00002', N'2014-06-15 00:00:00.000', N'1', N'60', N'5', N'UUJ');
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HUser]
-- ----------------------------
DROP TABLE [HUser]
GO
CREATE TABLE [HUser] (
[NoID] int NOT NULL ,
[Kode] varchar(20) NULL ,
[Nama] varchar(20) NULL ,
[Password] varchar(20) NULL ,
[IsAktif] bit NULL ,
[IsSupervisor] bit NULL DEFAULT ((0)) 
)


GO

-- ----------------------------
-- Records of HUser
-- ----------------------------
BEGIN TRANSACTION
GO
INSERT INTO [HUser] ([NoID], [Kode], [Nama], [Password], [IsAktif], [IsSupervisor]) VALUES (N'1', N'ADM', N'ADMINISTRATOR', N'–', N'1', N'1');
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [HUserD]
-- ----------------------------
DROP TABLE [HUserD]
GO
CREATE TABLE [HUserD] (
[NoID] int NOT NULL IDENTITY(1,1) ,
[IDUser] int NULL ,
[IDMenu] int NULL ,
[Enable] bit NULL DEFAULT ((1)) ,
[Visible] bit NULL DEFAULT ((1)) 
)


GO
DBCC CHECKIDENT(N'[HUserD]', RESEED, 102)
GO

-- ----------------------------
-- Records of HUserD
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [HUserD] ON
GO
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'11', N'1', N'1', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'12', N'1', N'2', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'13', N'1', N'3', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'16', N'1', N'6', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'17', N'1', N'7', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'18', N'1', N'8', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'19', N'1', N'9', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'20', N'1', N'11', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'21', N'1', N'10', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'67', N'2', N'1', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'68', N'2', N'2', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'69', N'2', N'3', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'70', N'2', N'6', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'71', N'2', N'8', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'72', N'2', N'9', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'73', N'2', N'10', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'74', N'2', N'11', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'75', N'2', N'12', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'76', N'2', N'13', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'77', N'2', N'14', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'78', N'2', N'15', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'79', N'2', N'16', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'80', N'2', N'17', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'81', N'2', N'18', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'82', N'1', N'12', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'85', N'1', N'15', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'86', N'1', N'16', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'88', N'1', N'18', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'89', N'1', N'19', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'90', N'1', N'20', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'91', N'1', N'21', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'92', N'1', N'22', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'93', N'1', N'24', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'94', N'1', N'25', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'95', N'1', N'26', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'96', N'1', N'27', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'97', N'1', N'28', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'99', N'1', N'30', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'100', N'1', N'31', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'101', N'1', N'32', N'1', N'1');
INSERT INTO [HUserD] ([NoID], [IDUser], [IDMenu], [Enable], [Visible]) VALUES (N'102', N'1', N'33', N'1', N'1');
GO
SET IDENTITY_INSERT [HUserD] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [sysdiagrams]
-- ----------------------------
DROP TABLE [sysdiagrams]
GO
CREATE TABLE [sysdiagrams] (
[name] sysname NOT NULL ,
[principal_id] int NOT NULL ,
[diagram_id] int NOT NULL IDENTITY(1,1) ,
[version] int NULL ,
[definition] varbinary(MAX) NULL 
)


GO

-- ----------------------------
-- Records of sysdiagrams
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [sysdiagrams] ON
GO
SET IDENTITY_INSERT [sysdiagrams] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for [TRBatchSQLUpdates]
-- ----------------------------
DROP TABLE [TRBatchSQLUpdates]
GO
CREATE TABLE [TRBatchSQLUpdates] (
[NoID] bigint NOT NULL IDENTITY(1,1) ,
[Kode] varchar(255) NULL ,
[Filename] varchar(255) NULL ,
[DateUpdate] datetime NULL ,
[SqlScript] varchar(MAX) NULL 
)


GO

-- ----------------------------
-- Records of TRBatchSQLUpdates
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [TRBatchSQLUpdates] ON
GO
SET IDENTITY_INSERT [TRBatchSQLUpdates] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Procedure structure for [sp_alterdiagram]
-- ----------------------------
DROP PROCEDURE [sp_alterdiagram]
GO

	CREATE PROCEDURE [sp_alterdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();	 
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
	
GO

-- ----------------------------
-- Procedure structure for [sp_creatediagram]
-- ----------------------------
DROP PROCEDURE [sp_creatediagram]
GO

	CREATE PROCEDURE [sp_creatediagram]
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID(); 
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert; 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
	
GO

-- ----------------------------
-- Procedure structure for [sp_dropdiagram]
-- ----------------------------
DROP PROCEDURE [sp_dropdiagram]
GO

	CREATE PROCEDURE [sp_dropdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
	
GO

-- ----------------------------
-- Procedure structure for [sp_helpdiagramdefinition]
-- ----------------------------
DROP PROCEDURE [sp_helpdiagramdefinition]
GO

	CREATE PROCEDURE [sp_helpdiagramdefinition]
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert; 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
	
GO

-- ----------------------------
-- Procedure structure for [sp_helpdiagrams]
-- ----------------------------
DROP PROCEDURE [sp_helpdiagrams]
GO

	CREATE PROCEDURE [sp_helpdiagrams]
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
	
GO

-- ----------------------------
-- Procedure structure for [sp_renamediagram]
-- ----------------------------
DROP PROCEDURE [sp_renamediagram]
GO

	CREATE PROCEDURE [sp_renamediagram]
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
	
GO

-- ----------------------------
-- Procedure structure for [sp_upgraddiagrams]
-- ----------------------------
DROP PROCEDURE [sp_upgraddiagrams]
GO

	CREATE PROCEDURE [sp_upgraddiagrams]
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
	
GO

-- ----------------------------
-- Function structure for [fn_diagramobjects]
-- ----------------------------
DROP FUNCTION [fn_diagramobjects]
GO

	CREATE FUNCTION [fn_diagramobjects]() 
	RETURNS int
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		declare @id_upgraddiagrams		int
		declare @id_sysdiagrams			int
		declare @id_helpdiagrams		int
		declare @id_helpdiagramdefinition	int
		declare @id_creatediagram	int
		declare @id_renamediagram	int
		declare @id_alterdiagram 	int 
		declare @id_dropdiagram		int
		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 
			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')

		if @id_upgraddiagrams is not null
			select @InstalledObjects = @InstalledObjects + 1
		if @id_sysdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 2
		if @id_helpdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 4
		if @id_helpdiagramdefinition is not null
			select @InstalledObjects = @InstalledObjects + 8
		if @id_creatediagram is not null
			select @InstalledObjects = @InstalledObjects + 16
		if @id_renamediagram is not null
			select @InstalledObjects = @InstalledObjects + 32
		if @id_alterdiagram  is not null
			select @InstalledObjects = @InstalledObjects + 64
		if @id_dropdiagram is not null
			select @InstalledObjects = @InstalledObjects + 128
		
		return @InstalledObjects 
	END
	
GO

-- ----------------------------
-- Indexes structure for table HBarang
-- ----------------------------
CREATE INDEX [IX_IDKategori] ON [HBarang]
([IDKategori] ASC) 
GO
CREATE INDEX [IX_Kode] ON [HBarang]
([Kode] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table [HBarang]
-- ----------------------------
ALTER TABLE [HBarang] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HBarangDBarcode
-- ----------------------------
CREATE UNIQUE INDEX [IX_Barcode] ON [HBarangDBarcode]
([Barcode] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table [HBarangDBarcode]
-- ----------------------------
ALTER TABLE [HBarangDBarcode] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HBarangDHargaJual
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HBarangDHargaJual]
-- ----------------------------
ALTER TABLE [HBarangDHargaJual] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HBeli
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HBeli]
-- ----------------------------
ALTER TABLE [HBeli] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HBeliD
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HBeliD]
-- ----------------------------
ALTER TABLE [HBeliD] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HGudang
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HGudang]
-- ----------------------------
ALTER TABLE [HGudang] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HJenisTransaksi
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HJenisTransaksi]
-- ----------------------------
ALTER TABLE [HJenisTransaksi] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HJual
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HJual]
-- ----------------------------
ALTER TABLE [HJual] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HJualD
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HJualD]
-- ----------------------------
ALTER TABLE [HJualD] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HKartuPiutang
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HKartuPiutang]
-- ----------------------------
ALTER TABLE [HKartuPiutang] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HKartuPoin
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HKartuPoin]
-- ----------------------------
ALTER TABLE [HKartuPoin] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HKartuStok
-- ----------------------------
CREATE INDEX [IX_Tanggal] ON [HKartuStok]
([Tanggal] ASC) 
GO
CREATE INDEX [IX_IDBarang] ON [HKartuStok]
([IDBarang] ASC) 
GO
CREATE INDEX [IX_HPP] ON [HKartuStok]
([HPP] ASC, [HargaBeliTerakhir] ASC) 
GO
CREATE INDEX [IX_Qty] ON [HKartuStok]
([QtyMasuk] ASC, [QtyKeluar] ASC, [Konversi] ASC, [SaldoAkhir] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table [HKartuStok]
-- ----------------------------
ALTER TABLE [HKartuStok] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Triggers structure for table [HKartuStok]
-- ----------------------------
DROP TRIGGER [HitungSaldoStok]
GO
CREATE TRIGGER [HitungSaldoStok]
ON [HKartuStok]
AFTER INSERT
AS


BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for trigger here
	
	DECLARE @NoID INT
	DECLARE @Tanggal DATETIME
	DECLARE @IDBarang BIGINT
	DECLARE @Saldo NUMERIC(18,2)
	
	DECLARE @I INT
	DECLARE @MaxNoID INT
	
	SELECT @MaxNoID = MAX(INSERTED.[NoID])
	FROM INSERTED
	
	SELECT @NoID = MIN(INSERTED.[NoID])
	FROM INSERTED
	
	SET @I=1
	
	WHILE @NoID <= @MaxNoID
		BEGIN
			SELECT @NoID = [NoID]
			FROM INSERTED WHERE INSERTED.[NoID]=@NoID
			
			SELECT @Tanggal = [Tanggal]
			FROM INSERTED WHERE INSERTED.[NoID]=@NoID
			
			SELECT @IDBarang = [IDBarang]
			FROM INSERTED WHERE INSERTED.[NoID]=@NoID
			
			SELECT @Saldo = ([QtyMasuk]+[QtyKeluar])*[Konversi]
			FROM INSERTED WHERE INSERTED.[NoID]=@NoID
			
			-- Insert statements for trigger here
			UPDATE HKartuStok
			SET SaldoAkhir = ISNULL((SELECT SUM((HKartuStok.QtyMasuk-HKartuStok.QtyKeluar)*HKartuStok.Konversi)+@Saldo FROM HKartuStok INNER JOIN HJenisTransaksi ON HJenisTransaksi.NoID=HKartuStok.IDJenisTransaksi WHERE HKartuStok.NoID<>@NoID AND CONVERT(DATE, HKartuStok.Tanggal)<CONVERT(DATE, DATEADD(d, 1, @Tanggal)) AND HKartuStok.IDBarang=@IDBarang),0)+ISNULL(@Saldo,0)
			WHERE NoID=@NoID
			
			SET @NoID = @NoID+1
		END
END

GO

-- ----------------------------
-- Indexes structure for table HKategori
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HKategori]
-- ----------------------------
ALTER TABLE [HKategori] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HKontak
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HKontak]
-- ----------------------------
ALTER TABLE [HKontak] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HMenu
-- ----------------------------
CREATE UNIQUE INDEX [IX_Kode] ON [HMenu]
([Kode] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table [HMenu]
-- ----------------------------
ALTER TABLE [HMenu] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HPenyesuaian
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HPenyesuaian]
-- ----------------------------
ALTER TABLE [HPenyesuaian] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HPenyesuaianD
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HPenyesuaianD]
-- ----------------------------
ALTER TABLE [HPenyesuaianD] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HReturJual
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HReturJual]
-- ----------------------------
ALTER TABLE [HReturJual] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HReturJualD
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HReturJualD]
-- ----------------------------
ALTER TABLE [HReturJualD] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HSalesOrder
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HSalesOrder]
-- ----------------------------
ALTER TABLE [HSalesOrder] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HSalesOrderD
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HSalesOrderD]
-- ----------------------------
ALTER TABLE [HSalesOrderD] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HSatuan
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HSatuan]
-- ----------------------------
ALTER TABLE [HSatuan] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HSettingPoin
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HSettingPoin]
-- ----------------------------
ALTER TABLE [HSettingPoin] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HTukarPoin
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HTukarPoin]
-- ----------------------------
ALTER TABLE [HTukarPoin] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HUser
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [HUser]
-- ----------------------------
ALTER TABLE [HUser] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table HUserD
-- ----------------------------
CREATE UNIQUE INDEX [IX_IDMenu] ON [HUserD]
([IDMenu] ASC, [IDUser] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table [HUserD]
-- ----------------------------
ALTER TABLE [HUserD] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Indexes structure for table sysdiagrams
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [sysdiagrams]
-- ----------------------------
ALTER TABLE [sysdiagrams] ADD PRIMARY KEY ([diagram_id])
GO

-- ----------------------------
-- Uniques structure for table [sysdiagrams]
-- ----------------------------
ALTER TABLE [sysdiagrams] ADD UNIQUE ([principal_id] ASC, [name] ASC)
GO

-- ----------------------------
-- Indexes structure for table TRBatchSQLUpdates
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [TRBatchSQLUpdates]
-- ----------------------------
ALTER TABLE [TRBatchSQLUpdates] ADD PRIMARY KEY ([NoID])
GO

-- ----------------------------
-- Foreign Key structure for table [HBarang]
-- ----------------------------
ALTER TABLE [HBarang] ADD FOREIGN KEY ([IDKategori]) REFERENCES [HKategori] ([NoID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [HBarang] ADD FOREIGN KEY ([IDSatuanBeli]) REFERENCES [HSatuan] ([NoID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [HBarang] ADD FOREIGN KEY ([IDSatuanJual]) REFERENCES [HSatuan] ([NoID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO