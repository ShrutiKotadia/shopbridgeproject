create proc saveInventory
(
	@inId INT = NULL,
	@stName nvarchar(100),
	@stDescription nvarchar(1000),
	@dcPrice decimal(10,2),
	@stImageName varchar(100),
	@inSuccess INT OUT
)
AS
BEGIN
	IF ISNULL(@inId,0) = 0
	BEGIN	
		INSERT INTO tblInventory(stName, stDescription, dcPrice, stImageName)
		VALUES(@stName, @stDescription, @dcPrice, @stImageName)

		SET @inSuccess = 1
	END
	ELSE
	BEGIN
		UPDATE tblInventory
		SET stName = @stName,
			stDescription = @stDescription,
			dcPrice = @dcPrice,
			stImageName = CASE WHEN ISNULL(@stImageName,'') = '' THEN stImageName ELSE @stImageName END,
			dtModifiedOn = GETDATE()
		WHERE inId = @inId

		SET @inSuccess = 2
	END
END