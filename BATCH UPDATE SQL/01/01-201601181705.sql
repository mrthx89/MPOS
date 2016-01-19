-- =============================================
-- Author:		Yanto Hariyono
-- Create date: 18-01-2016
-- Description:	Trigger Kartu Stok
-- =============================================
CREATE PROCEDURE SP_HitungSaldoStok 
@IDBarang BIGINT,
@Tanggal DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @NoID BIGINT
	DECLARE @IDJenisTransaksi INT

	-- CEK DULU TRANSAKSI PADA HARI ITU DAN SETELAHNYA
	DECLARE @TableTemp AS TABLE (PKID INT IDENTITY(1,1) PRIMARY KEY, NoID BIGINT, Tanggal DATETIME, IDBarang BIGINT, Saldo NUMERIC(18,2), HargaBeli Money, HargaJual Money, QtyBeli Numeric(18,2), IDJenisTransaksi INT)
	DECLARE @i AS INT, @iMax AS INT
	DECLARE @Saldo AS NUMERIC(18,2)
	DECLARE @TotalQtyBeli AS NUMERIC(18,2)
	DECLARE @HPP AS Money, @HPPSebelum AS Money, @IDTransaksi AS BIGINT
	DECLARE @HargaBeli AS Money, @HargaBeliSebelum AS Money

	INSERT INTO @TableTemp 
	SELECT NoID, CONVERT(DATE, Tanggal), IDBarang, SaldoAkhir, HargaBeliTerakhir, HargaJualTerakhir, TotalQtyBeli, IDJenisTransaksi
	FROM HKartuStok
	WHERE CONVERT(DATE, HKartuStok.Tanggal)>=CONVERT(DATE, @Tanggal) AND HKartuStok.IDBarang=@IDBarang
	ORDER BY CONVERT(DATE, HKartuStok.Tanggal), IDJenisTransaksi, IDTransaksi

	SELECT @i = 1, @iMax = MAX(PKID) FROM @TableTemp

	WHILE @i <= @iMax
	BEGIN
		SELECT 
		@IDJenisTransaksi = A.IDJenisTransaksi, 
		@IDTransaksi = A.IDTransaksi,
		@Tanggal = A.Tanggal,
		@HPPSebelum = NULL,
		@HargaBeliSebelum = NULL
		FROM HKartuStok AS A
		INNER JOIN @TableTemp AS B ON A.NoID = B.NoID
		WHERE B.PKID = @i

		IF @i = 1
			BEGIN
				SELECT @Saldo = ISNULL(SUM((HKartuStok.QtyMasuk-HKartuStok.QtyKeluar)*HKartuStok.Konversi),0)
				FROM HKartuStok
				INNER JOIN HJenisTransaksi ON HJenisTransaksi.NoID=HKartuStok.IDJenisTransaksi 
				WHERE HKartuStok.IDJenisTransaksi <= @IDJenisTransaksi AND HKartuStok.IDBarang = @IDBarang AND HKartuStok.IDTransaksi < @IDTransaksi AND CONVERT(DATE, HKartuStok.Tanggal)<CONVERT(DATE, @Tanggal)

				SELECT @TotalQtyBeli = ISNULL(SUM(HKartuStok.QtyMasuk*HKartuStok.Konversi),0)
				FROM HKartuStok
				INNER JOIN HJenisTransaksi ON HJenisTransaksi.NoID=HKartuStok.IDJenisTransaksi 
				WHERE HKartuStok.IDJenisTransaksi = 1 AND HKartuStok.IDBarang = @IDBarang AND HKartuStok.IDTransaksi < @IDTransaksi AND CONVERT(DATE, HKartuStok.Tanggal)<CONVERT(DATE, @Tanggal)

				SELECT @HPPSebelum = TSource.HPP, @HargaBeliSebelum = TSource.HargaBeliTerakhir
				FROM (SELECT TOP 1 A.HPP, A.HargaBeliTerakhir
				FROM HKartuStok AS A
				WHERE A.IDJenisTransaksi = 1 AND A.IDBarang = @IDBarang AND A.IDTransaksi < @IDTransaksi AND CONVERT(DATE, A.Tanggal) < CONVERT(DATE, DATEADD(DAY, 1, @Tanggal))
				ORDER BY CONVERT(DATE, A.Tanggal) DESC, A.IDJenisTransaksi DESC, A.IDTransaksi DESC
				) AS TSource
			END
		ELSE
			BEGIN
				SET @HPPSebelum = @HPP
				SET @HargaBeliSebelum = @HargaBeli
			END

		-- Cari Harga Beli Terakhir
		IF @IDJenisTransaksi = 1
		BEGIN
			SELECT @HargaBeli = A.HargaBeliTerakhir
			FROM HKartuStok AS A
			INNER JOIN @TableTemp AS B ON A.NoID = B.NoID
			WHERE B.PKID = @i
		END
		ELSE
		BEGIN
			SET @HargaBeli = @HargaBeliSebelum
		END

		-- Cari HPP
		IF @HPPSebelum IS NULL
		BEGIN
			SELECT 
			@Saldo = ISNULL(@Saldo,0) + ISNULL((A.QtyMasuk-A.QtyKeluar)*Konversi,0),
			@TotalQtyBeli = ISNULL(@TotalQtyBeli,0) + CASE WHEN A.IDJenisTransaksi=1 THEN ISNULL(A.QtyMasuk*A.Konversi,0) ELSE 0 END,
			@HPP = A.HargaBeliTerakhir / A.Konversi
			FROM HKartuStok AS A
			INNER JOIN @TableTemp AS B ON A.NoID = B.NoID
			WHERE B.PKID = @i
		END
		ELSE IF @IDJenisTransaksi = 1
		BEGIN
			SELECT
			@HPP = ((ISNULL(@HPPSebelum, 0)*ISNULL(@Saldo,0))+(ISNULL(A.HargaBeliTerakhir,0)/A.Konversi*ISNULL((A.QtyMasuk-A.QtyKeluar)*Konversi,0))) / (ISNULL(@Saldo,0) + ISNULL((A.QtyMasuk-A.QtyKeluar)*Konversi,0))
			FROM HKartuStok AS A
			INNER JOIN @TableTemp AS B ON A.NoID = B.NoID
			WHERE B.PKID = @i

			SELECT 
			@Saldo = ISNULL(@Saldo,0) + ISNULL((A.QtyMasuk-A.QtyKeluar)*Konversi,0),
			@TotalQtyBeli = ISNULL(@TotalQtyBeli,0) + CASE WHEN A.IDJenisTransaksi=1 THEN ISNULL(A.QtyMasuk*A.Konversi,0) ELSE 0 END
			FROM HKartuStok AS A
			INNER JOIN @TableTemp AS B ON A.NoID = B.NoID
			WHERE B.PKID = @i
		END
		ELSE
		BEGIN
			SELECT 
			@Saldo = ISNULL(@Saldo,0) + ISNULL((A.QtyMasuk-A.QtyKeluar)*Konversi,0),
			@TotalQtyBeli = ISNULL(@TotalQtyBeli,0) + CASE WHEN A.IDJenisTransaksi=1 THEN ISNULL(A.QtyMasuk*A.Konversi,0) ELSE 0 END,
			@HPP = @HPPSebelum
			FROM HKartuStok AS A
			INNER JOIN @TableTemp AS B ON A.NoID = B.NoID
			WHERE B.PKID = @i
		END

		-- Teori Dwi Salah Kaprah Bikin Mummet
		--IF @IDJenisTransaksi = 1
		--BEGIN
		--	SELECT @HPP = CASE 
		--				  WHEN @TotalQtyBeli <= 0 THEN A.HargaBeliTerakhir / A.Konversi
		--				  WHEN @Saldo <= 0 THEN A.HargaBeliTerakhir / A.Konversi
		--				  WHEN @Saldo = @TotalQtyBeli THEN A.HargaBeliTerakhir / A.Konversi
		--				  ELSE 
		--				  ((ISNULL(@Saldo,0) * ISNULL(A.HargaBeliTerakhir / A.Konversi,0)) - ISNULL(@Saldo,0) * (ISNULL(@Saldo,0) * ISNULL(A.HargaBeliTerakhir / A.Konversi,0)) / @TotalQtyBeli) / @Saldo
		--				  END
		--	FROM HKartuStok AS A
		--	INNER JOIN @TableTemp AS B ON A.NoID = B.NoID
		--	WHERE B.PKID = @i
		--END
		--ELSE
		--BEGIN
		--	SELECT @HPP = TSource.HPP
		--	FROM (SELECT TOP 1 A.HPP
		--	FROM HKartuStok AS A 
		--	WHERE A.IDJenisTransaksi = 1 AND CONVERT(DATE, A.Tanggal) < CONVERT(DATE, DATEADD(DAY, 1, @Tanggal)) AND A.IDTransaksi <= @IDTransaksi AND A.IDBarang = @IDBarang
		--	ORDER BY CONVERT(DATE, A.Tanggal) DESC, A.IDJenisTransaksi DESC, A.IDTransaksi DESC
		--	) AS TSource
		--END

		IF @HPP IS NULL
			BEGIN
				SELECT @HPP = A.HargaBeliTerakhir / A.Konversi
				FROM HKartuStok AS A
				INNER JOIN @TableTemp AS B ON A.NoID = B.NoID
				WHERE B.PKID = @i
			END

		UPDATE HKartuStok SET 
		SaldoAkhir = ISNULL(@Saldo,0), 
		TotalQtyBeli = ISNULL(@TotalQtyBeli,0),
		HPP = ISNULL(@HPP, 0),
		HargaBeliTerakhir = ISNULL(@HargaBeli,0)
		FROM HKartuStok AS A
		INNER JOIN @TableTemp AS B ON A.NoID = B.NoID
		WHERE B.PKID = @i

		SET @i = @i + 1
	END
	
	DELETE FROM @TableTemp
END