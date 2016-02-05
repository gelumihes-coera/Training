SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS ( SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE' AND SPECIFIC_NAME = 'InsertAddress')
	BEGIN
		DROP PROC InsertAddress
	END
GO
CREATE PROCEDURE InsertAddress
	@studentId INT,
	@street NVARCHAR(20),
	@city NVARCHAR(10),
	@county NVARCHAR(10)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Addresses(StudentId, Streeet, City, County)
	VALUES (@studentId, @street, @city, @county)
END
GO
