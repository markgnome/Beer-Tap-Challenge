USE BeerTap
GO


CREATE PROCEDURE dbo.Office_Update
	@Name nvarchar(50),
	@Description nvarchar(200),
	@LocationId INT,
	@Id INT 

AS

UPDATE dbo.Offices
SET Name = @Name,
	[Description] = @Description,
	LocationId = @LocationId

WHERE Id = @Id



GO