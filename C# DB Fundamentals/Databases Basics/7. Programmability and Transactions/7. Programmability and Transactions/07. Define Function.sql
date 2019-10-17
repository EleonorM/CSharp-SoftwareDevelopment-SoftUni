CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50)) 
RETURNS BIT
AS
BEGIN
	DECLARE @tempWord VARCHAR(50), @isMatch INT
	SET @tempWord = @word
	SET @isMatch = 1;
	WHILE (LEN(@tempWord) <> 0)
		BEGIN
		IF(CHARINDEX(SUBSTRING(@tempWord,1,1), @setOfLetters) < 1)
			BEGIN
			SET @isMatch = 0
			END
		SET @tempWord = STUFF(@tempWord,1,1,'')
		END

	RETURN @isMatch
END