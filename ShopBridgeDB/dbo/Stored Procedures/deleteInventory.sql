CREATE proc deleteInventory
(
	@inId INT,
	@inSuccess INT OUTPUT
)
AS
BEGIN
	UPDATE tblInventory
	SET flgIsDeleted = 1,
		dtModifiedOn = GETDATE()
	WHERE inId = @inId
	SET @inSuccess = 1
END