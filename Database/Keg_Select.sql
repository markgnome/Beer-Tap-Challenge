USE BeerTap
GO

CREATE PROCEDURE dbo.Keg_Select
	@KegId INT 
AS

IF (@KegId != 0)
	SELECT 
		k.Id as 'KegId',
		k.BrandId,
		k.Quantity, 
		k.OfficeId
	FROM Kegs k
	WHERE 
		k.Id = @KegId
ELSE
	SELECT 
		k.Id as 'KegId',
		k.BrandId,
		k.Quantity, 
		k.OfficeId
	FROM Kegs k
GO