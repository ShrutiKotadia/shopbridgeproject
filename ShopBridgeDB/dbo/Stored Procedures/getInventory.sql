CREATE proc getInventory
(
	@inId INT = NULL
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT inId, stName, dcPrice, stImageName, stDescription
	FROM tblInventory WITH(NOLOCK)
	WHERE flgIsDeleted = 0 AND
	(ISNULL(@inId,0) = 0 OR inId = @inId)
END