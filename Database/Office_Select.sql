USE BeerTap
GO

ALTER PROCEDURE dbo.Office_Select
	@OfficeId INT 
AS

IF (@OfficeId != 0)
	SELECT 
		o.Id,
		o.Name, 
		o.[Description],
		o.LocationId,
		k.Id as 'KegId',
		k.BrandId,
		k.Quantity
	FROM Offices o
		LEFT JOIN BeerTaps b ON o.Id = b.OfficeId
		LEFT JOIN Kegs k ON b.KegId = k.Id
	WHERE 
		o.Id = @OfficeId
ELSE
	SELECT 
		o.Id,
		o.Name, 
		o.[Description],
		o.LocationId,
		k.Id as 'KegId',
		k.BrandId,
		k.Quantity
	FROM Offices o
		LEFT JOIN BeerTaps b ON o.Id = b.OfficeId
		LEFT JOIN Kegs k ON b.KegId = k.Id
GO