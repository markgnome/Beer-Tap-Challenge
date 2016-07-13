USE BeerTap
GO

ALTER PROCEDURE dbo.Location_Update
	@Id INT,
	@City nvarchar(50),
	@Country nvarchar(50)
AS

UPDATE Locations
SET City = @City,
	Country = @Country
WHERE Id = @Id


GO
