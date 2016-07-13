USE BeerTap
GO


CREATE PROCEDURE dbo.Keg_Create
	@Quantity decimal(18, 0),
	@BrandId INT,
	@OfficeId INT
AS

INSERT dbo.Kegs (Quantity, BrandId, OfficeId)
VALUES (@Quantity, @BrandId, @OfficeId)

SELECT  ISNULL(SCOPE_IDENTITY(), 0)  

GO




