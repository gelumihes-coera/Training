SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS ( SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE' AND SPECIFIC_NAME = 'Student_GetByID')
	BEGIN
		DROP PROC Student_GetByID
	END
GO
CREATE PROCEDURE Student_GetByID
	@studentId INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Students
	WHERE Id = @studentId
END
GO
