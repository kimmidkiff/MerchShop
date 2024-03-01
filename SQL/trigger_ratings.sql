CREATE OR ALTER TRIGGER Update_Rating_Overall
ON  VendorReviews

AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF (SELECT COUNT(*) FROM inserted) > 0
    BEGIN
        UPDATE v
        SET OverallRating = (SELECT AVG(vr.ReviewScore) FROM VendorReviews vr WHERE vr.VendorID = v.VendorId)
        FROM Vendors v
        JOIN inserted i ON v.VendorID = vr.VendorId;
    END
    ELSE IF (SELECT COUNT(*) FROM deleted) > 0
    BEGIN
        UPDATE r
        SET OverallRating = (SELECT AVG(vr.ReviewScore) FROM VendorReviews vr WHERE vr.VendorID = v.VendorID)
        FROM Vendors v
        JOIN deleted d ON v.VendorId = d.VendorId;
    END
END;