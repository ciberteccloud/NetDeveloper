USE Chinook
GO

CREATE PROCEDURE dbo.CustomerInvoice
	@invoiceId int,
	@email nvarchar(60)	
AS
BEGIN	
	SET NOCOUNT ON;

	SELECT
	inv.BillingCountry,
	line.Quantity, 
	line.UnitPrice,
	inv.Total, 
	cust.FirstName, 
	cust.LastName, 
	cust.Email 
	FROM dbo.Invoice inv
	INNER JOIN dbo.InvoiceLine line on line.InvoiceId=inv.InvoiceId
	INNER JOIN dbo.Customer cust on cust.CustomerId=inv.CustomerId
	WHERE cust.Email=@email AND line.InvoiceId=@invoiceId
END
GO
