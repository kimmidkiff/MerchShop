CREATE OR ALTER TRIGGER Update_Order_Total
ON Orderlines
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF (SELECT COUNT(*) FROM inserted) > 0
    BEGIN
        UPDATE o
        SET Total = (SELECT SUM(ol.SubTotal) FROM Orderlines ol WHERE ol.OrderId = o.OrderId)
        FROM Orders o
        JOIN inserted i ON o.OrderId = i.OrderId;
    END
    ELSE IF (SELECT COUNT(*) FROM deleted) > 0
    BEGIN
        UPDATE o
        SET Total = (SELECT SUM(ol.SubTotal) FROM Orderlines ol WHERE ol.OrderId = o.OrderId)
        FROM Orders o
        JOIN deleted d ON o.OrderId = d.OrderId;
    END
END;


