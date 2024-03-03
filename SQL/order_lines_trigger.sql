CREATE OR ALTER TRIGGER Update_Orderline_Subtotal
ON Orderlines
AFTER INSERT, UPDATE
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE ol
	SET SubTotal = ol.Quantity * iv.SalePrice
	FROM Orderlines ol
	JOIN Inventory iv ON ol.InventoryID = iv.InventoryID;
END;