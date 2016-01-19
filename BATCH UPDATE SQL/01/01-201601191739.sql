CREATE TRIGGER  [dbo].[HitungSaldoStok]
   ON  [dbo].[HKartuStok]
   AFTER INSERT, DELETE
AS 

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for trigger here
	DECLARE @IDBarang BIGINT
	DECLARE @Tanggal DATETIME
	DECLARE @NoID AS BIGINT

	DECLARE @TableTemp AS TABLE(PKID INT IDENTITY(1,1), NoID BIGINT)
	DECLARE @i AS INT, @iMax AS INT
	
	INSERT INTO @TableTemp
	SELECT NoID FROM inserted
	
	SELECT @i = 1, @iMax = MAX(PKID)
	FROM @TableTemp

	WHILE @i <= @iMax
	BEGIN 
		SELECT 
		@Tanggal = A.[Tanggal], 
		@IDBarang = A.[IDBarang],
		@NoID = A.[NoID]
		FROM inserted AS A
		INNER JOIN @TableTemp AS B ON A.NoID = B.NoID
		WHERE B.PKID = @i

		EXEC SP_HitungSaldoStok @IDBarang, @Tanggal

		SET @i = @i + 1
	END

	DELETE FROM @TableTemp
	--EXEC SP_HitungSaldoStok @IDBarang, @Tanggal
END