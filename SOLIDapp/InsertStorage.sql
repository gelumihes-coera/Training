SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS ( SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE' AND SPECIFIC_NAME = 'InsertStorage')
	BEGIN
		DROP PROC InsertStorage
	END
GO
CREATE PROCEDURE InsertStorage
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @noOfInserts INT
	DECLARE @counter INT
	DECLARE @pid INT

	SET @counter = 0;
	SET @noOfInserts=300;
	SET @pid = (SELECT TOP 1 ID FROM Products);

	WHILE @counter < @noOfInserts
	BEGIN
		INSERT INTO [dbo].[Storages] (ProductId, Quantity) VALUES (@pid, ABS(Checksum(NewID()) % 5)+1)
		SET @counter = @counter+1
		SET @pid = @pid+1
	END
END
GO
