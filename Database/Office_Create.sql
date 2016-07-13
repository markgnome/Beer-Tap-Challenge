USE BeerTap
GO


CREATE PROCEDURE dbo.Office_Create
	@Name nvarchar(50),
	@Description nvarchar(200),
	@LocationId INT


AS

INSERT dbo.Offices (Name, [Description], LocationId)
VALUES (@Name,  @Description, @LocationId)

SELECT  ISNULL(SCOPE_IDENTITY(), 0)  

GO


