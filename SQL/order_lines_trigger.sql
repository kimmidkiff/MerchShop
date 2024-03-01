CREATE OR ALTER TRIGGER Update_Orderline_Subtotal
ON Orderline
AFTER INSERT, UPDATE
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE ol
	SET SubTotal = ol.Quantity * iv.SalePrice
	FROM Orderline ol
	JOIN Orders o ON ol.OrderID = o.OrderID
	JOIN Inventory iv ON ol.InventoryID = iv.InventoryID;
END;
