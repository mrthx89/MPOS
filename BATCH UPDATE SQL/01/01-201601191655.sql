-- =============================================
-- Author:		Yanto Hariyono
-- Create date: 18-01-2016
-- Description:	Update Master Barang Dari Pembelian
-- =============================================
CREATE PROCEDURE SP_UpdateBarangDariPembelian
@IDBeli BIGINT,
@IDUser BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @IDBarang AS BIGINT, @Dataterakhir BIT
	DECLARE @i AS INT, @iMax AS INT
	DECLARE @TableTemp AS TABLE (PKID INT IDENTITY(1,1) PRIMARY KEY, IDBarang BIGINT, IsUpdate BIT)

	INSERT INTO @TableTemp
	SELECT HBeliD.IDBarang, NULL
	FROM HBarang INNER JOIN HBeliD ON HBeliD.IDBarang=HBarang.NoID WHERE HBeliD.IDHeader = @IDBeli

	SELECT @i = 1, @iMax = MAX(PKID), @Dataterakhir = 0
	FROM @TableTemp

	WHILE @i <= @iMax
	BEGIN
		SELECT @IDBarang = IDBarang
		FROM @TableTemp WHERE PKID = @i

		SELECT @Dataterakhir = CASE WHEN COUNT(NoID) >= 1 THEN 1 ELSE 0 END
		FROM HKartuStok
		WHERE IDJenisTransaksi = 1 AND IDTransaksi > @IDBeli AND IDBarang = @IDBarang
		GROUP BY IDJenisTransaksi, IDTransaksi

		UPDATE @TableTemp SET IsUpdate = @Dataterakhir WHERE PKID = @i

		SET @i = @i + 1
	END

	SET @i = 1

	WHILE @i <= @iMax
	BEGIN
		SELECT @IDBarang = IDBarang, @Dataterakhir = IsUpdate
		FROM @TableTemp WHERE PKID = @i

		IF @Dataterakhir = 1
		BEGIN
			UPDATE HBarang SET 
			HPP=HBeliD.Jumlah/HBeliD.Qty, 
			IDSatuanBeli=HBeliD.IDSatuan, 
			KonversiBeli=HBeliD.Konversi, 
			HargaBeli=HBeliD.Jumlah/HBeliD.Qty, 
			HargaBeliNetto=HBeliD.Jumlah/HBeliD.Qty*HBeliD.Konversi, 
			KonversiJual=HBeliD.Konversi, 
			HargaJual=HBeliD.Jumlah/HBeliD.Qty*(1+(MarkUp/100)),
			IDUserLastUpdate=@IDUser, 
			LastUpdate=GETDATE()
            FROM HBarang 
			INNER JOIN HBeliD ON HBeliD.IDBarang=HBarang.NoID 
			WHERE HBeliD.IDHeader=@IDBeli AND HBeliD.IDBarang = @IDBarang

			SET @i = @i + 1
		END
	END
	
	DELETE FROM @TableTemp
END