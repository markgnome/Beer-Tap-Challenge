USE BeerTap
GO

ALTER PROCEDURE dbo.Location_Add 
	@City nvarchar(50),
	@Country nvarchar(50),
	@Result INT OUTPUT 
AS

INSERT dbo.Locations (City, Country)
VALUES (@City,  @Country)

SELECT @Result = ISNULL(SCOPE_IDENTITY(), 0)  


GO