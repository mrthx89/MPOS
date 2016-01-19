ALTER TRIGGER  [dbo].[HitungSaldoStok]
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

	SELECT 
	@Tanggal = [Tanggal], 
	@IDBarang = [IDBarang],
	@NoID = [NoID]
	FROM inserted

	IF @NoID IS NULL
	BEGIN
		SELECT 
		@Tanggal = [Tanggal], 
		@IDBarang = [IDBarang],
		@NoID = [NoID]
		FROM deleted
	END

	EXEC SP_HitungSaldoStok @IDBarang, @Tanggal
END