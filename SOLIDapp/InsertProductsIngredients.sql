SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS ( SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE' AND SPECIFIC_NAME = 'InsertProductsIngredients')
	BEGIN
		DROP PROC InsertProductsIngredients
	END
GO
CREATE PROCEDURE InsertProductsIngredients
	AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @noOfInserts INT
	DECLARE @counter INT
	DECLARE @pid INT
	DECLARE @iid INT
	DECLARE @i INT

	SET @counter = 0;
	SET @noOfInserts = 300;
	SET @pid = (SELECT TOP 1 ID FROM Products);

	WHILE @counter < @noOfInserts
	BEGIN
		SET @i=0
		WHILE @i < 5
		BEGIN
			SET @iid = (SELECT TOP 1 ID FROM Ingredients ORDER BY NEWID());
			INSERT INTO [dbo].[ProductsIngredients] (ProductId, IngredientId) VALUES (@pid, @iid)
			SET @i=@i+1
		END
		SET @pid = @pid+1
		SET @counter = @counter+1
	END
END
GO
