SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetTransactions 
	@Year int,
	@Month int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		t.Id as TransactionId, 
		t.Name as TransactionName, 
		t.Year,
		t.Month,
		t.Amount,
		t.TransactionDate,
		t.DateCreated as TransactionAddedDate,
		c.Name as CategoryName
	FROM Transactions t
	JOIN Categories c on t.id=c.id
	WHERE t.Year = @Year and t.Month = @Month

END
GO