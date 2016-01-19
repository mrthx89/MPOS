ALTER TRIGGER  [dbo].[HitungSaldoStok]
   ON  [dbo].[HKartuStok]
   AFTER INSERT
AS 

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for trigger here
	
	DECLARE @NoID BIGINT
	DECLARE @Tanggal DATETIME
	DECLARE @IDBarang BIGINT
	DECLARE @IDJenisTransaksi INT

	SELECT @NoID = [NoID]
	FROM INSERTED WHERE INSERTED.[NoID]=@NoID
			
	SELECT @Tanggal = [Tanggal]
	FROM INSERTED WHERE INSERTED.[NoID]=@NoID
			
	SELECT @IDBarang = [IDBarang]
	FROM INSERTED WHERE INSERTED.[NoID]=@NoID
	
	SELECT @IDJenisTransaksi = IDJenisTransaksi
	FROM INSERTED WHERE INSERTED.[NoID]=@NoID

	---- Update Saldo Akhir dan Qty Beli
	--UPDATE HKartuStok
	--SET SaldoAkhir = ISNULL((SELECT SUM((HKartuStok.QtyMasuk-HKartuStok.QtyKeluar)*HKartuStok.Konversi)
	--FROM HKartuStok 
	--INNER JOIN HJenisTransaksi ON HJenisTransaksi.NoID=HKartuStok.IDJenisTransaksi 
	--WHERE HKartuStok.NoID<>@NoID AND CONVERT(DATE, HKartuStok.Tanggal)<CONVERT(DATE, DATEADD(d, 1, @Tanggal)) AND HKartuStok.IDBarang=@IDBarang AND HKartuStok.IDJenisTransaksi<=@IDJenisTransaksi),0)+ISNULL(@Saldo,0),
	--TotalQtyBeli = ISNULL((SELECT SUM(HKartuStok.QtyMasuk*HKartuStok.Konversi)
	--FROM HKartuStok 
	--INNER JOIN HJenisTransaksi ON HJenisTransaksi.NoID=HKartuStok.IDJenisTransaksi 
	--WHERE HKartuStok.NoID<>@NoID AND CONVERT(DATE, HKartuStok.Tanggal)<CONVERT(DATE, DATEADD(d, 1, @Tanggal)) AND HKartuStok.IDBarang=@IDBarang AND HKartuStok.IDJenisTransaksi = 1),0)+ISNULL(@Saldo,0)
	--WHERE NoID=@NoID

	-- CEK DULU TRANSAKSI PADA HARI ITU DAN SETELAHNYA
	DECLARE @TableTemp AS TABLE (PKID INT IDENTITY(1,1) PRIMARY KEY, NoID BIGINT, Tanggal DATETIME, IDBarang BIGINT, Saldo NUMERIC(18,2), HargaBeli Money, HargaJual Money, QtyBeli Numeric(18,2), IDJenisTransaksi INT)
	DECLARE @i AS INT, @iMax AS INT
	DECLARE @Saldo AS NUMERIC(18,2)
	DECLARE @TotalQtyBeli AS NUMERIC(18,2)
	DECLARE @HPP AS Money

	INSERT INTO @TableTemp 
	SELECT NoID, CONVERT(DATE, Tanggal), IDBarang, SaldoAkhir, HargaBeliTerakhir, HargaJualTerakhir, TotalQtyBeli, IDJenisTransaksi
	FROM HKartuStok
	WHERE CONVERT(DATE, HKartuStok.Tanggal)>=CONVERT(DATE, @Tanggal) AND HKartuStok.IDBarang=@IDBarang
	ORDER BY CONVERT(DATE, HKartuStok.Tanggal), IDJenisTransaksi

	SELECT @i = 1, @iMax = MAX(NoID) FROM @TableTemp

	WHILE @i <= @iMax
	BEGIN
		IF @i = 1
			BEGIN
				SELECT @Saldo = ISNULL(SUM((HKartuStok.QtyMasuk-HKartuStok.QtyKeluar)*HKartuStok.Konversi),0)
				FROM HKartuStok
				INNER JOIN HJenisTransaksi ON HJenisTransaksi.NoID=HKartuStok.IDJenisTransaksi 
				WHERE CONVERT(DATE, HKartuStok.Tanggal)<CONVERT(DATE, @Tanggal) AND HKartuStok.IDBarang=@IDBarang

				SELECT @TotalQtyBeli = ISNULL(SUM(HKartuStok.QtyMasuk*HKartuStok.Konversi),0)
				FROM HKartuStok
				INNER JOIN HJenisTransaksi ON HJenisTransaksi.NoID=HKartuStok.IDJenisTransaksi 
				WHERE CONVERT(DATE, HKartuStok.Tanggal)<CONVERT(DATE, @Tanggal) AND HKartuStok.IDBarang=@IDBarang AND HKartuStok.IDJenisTransaksi = 1
			END
		ELSE
			BEGIN
				SELECT @Saldo = ISNULL(@Saldo,0) + ISNULL((QtyMasuk-QtyKeluar)*Konversi,0)
				FROM HKartuStok
				INNER JOIN @TableTemp AS B ON HKartuStok.NoID = B.NoID
				WHERE B.PKID = @i

				SELECT @TotalQtyBeli = ISNULL(@TotalQtyBeli,0) + CASE WHEN HKartuStok.IDJenisTransaksi=1 THEN ISNULL((QtyMasuk-QtyKeluar)*Konversi,0) ELSE 0 END
				FROM HKartuStok
				INNER JOIN @TableTemp AS B ON HKartuStok.NoID = B.NoID
				WHERE B.PKID = @i
			END
		
		SELECT @HPP = CASE 
					  WHEN @TotalQtyBeli = 0 THEN A.HargaBeliTerakhir 
					  WHEN @Saldo <= 0 THEN A.HargaBeliTerakhir
					  ELSE 
					  (ISNULL(@Saldo,0) * ISNULL(A.HargaJualTerakhir,0)) - ISNULL(@Saldo,0) * (ISNULL(@Saldo,0) * ISNULL(A.HargaJualTerakhir,0)) / @TotalQtyBeli 
					  END
		FROM HKartuStok AS A
		INNER JOIN @TableTemp AS B ON A.NoID = B.NoID
		WHERE B.PKID = @i

		UPDATE HKartuStok SET 
		SaldoAkhir = ISNULL(@Saldo,0), 
		TotalQtyBeli = ISNULL(@TotalQtyBeli,0),
		HPP = ISNULL(@HPP, 0)
		FROM HKartuStok AS A
		INNER JOIN @TableTemp AS B ON A.NoID = B.NoID
		WHERE B.PKID = @i

		SET @i = @i + 1
	END
	
	DELETE FROM @TableTemp
END