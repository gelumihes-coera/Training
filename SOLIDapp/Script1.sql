SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS ( SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE' AND SPECIFIC_NAME = 'InsertProducts')
	BEGIN
		DROP PROC InsertProducts
	END
GO
CREATE PROCEDURE InsertProducts
	@noOfInserts INT 
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @counter INT
	SET @counter = 0;
	WHILE @counter < @noOfInserts
	BEGIN
		INSERT INTO [dbo].[Products] (Name, Price, StatusCode)
		 VALUES (CONCAT('Product_',@counter), RAND(), 0)
		SET @counter = @counter+1
	END
END
GO
