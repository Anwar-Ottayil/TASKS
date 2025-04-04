use library
SELECT * FROM BOOKS


CREATE PROCEDURE BOOK_TITLES 
AS
BEGIN
SELECT Title FROM Book
END

BOOK_TITLES

CREATE PROCEDURE SPECIFIC_AUTHOR @AUTHOR VARCHAR(50)
AS
BEGIN
SELECT * FROM BOOKS WHERE Author=@AUTHOR
END

SPECIFIC_AUTHOR 'Kiran Deshayi'

CREATE FUNCTION DBO.COUNTBOOKSBYAUTHOR(@AUTHORNAME NVARCHAR(255))
RETURNS INT
AS
BEGIN
	RETURN(
	SELECT COUNT(*)
	FROM BOOKS
	WHERE Author=@AUTHORNAME);
END;

SELECT DBO.COUNTBOOKSBYAUTHOR('Kiran Deshayi') AS NumberOfBooks;




