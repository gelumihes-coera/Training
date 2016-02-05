SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS ( SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE' AND SPECIFIC_NAME = 'Address_Update')
	BEGIN
		DROP PROC Address_Update
	END
GO
CREATE PROCEDURE Address_Update
	@StudentId INT,
	@Streeet NVARCHAR(30),
	@City NVARCHAR(20),
	@County NVARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Addresses
	SET StudentId=@StudentId, Streeet=@Streeet, City=@City, County=@County
	WHERE StudentId=@StudentId
END
GO
