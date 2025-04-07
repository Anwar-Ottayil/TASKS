CREATE DATABASE Book
USE Book
CREATE TABLE Books (BookID INT PRIMARY KEY,Title NVARCHAR(50),Author NVARCHAR(50));
SELECT * FROM Books;
insert into Books(BookID,Title,Author)values(1,'The c programming language','Brian W. Kernighan and Dennis M. Ritchie');
insert into Books(BookID,Title,Author)values(2,'Modern Cross-Platform Development','Mark j price');
insert into Books(BookID,Title,Author)values(3,'The C++ Programming Language','Bjarne Stroustrup');

CREATE TABLE Sales (SaleID INT PRIMARY KEY IDENTITY(1,1),BookID INT,SaleDate DATE,SaleAmount DECIMAL(10, 2),FOREIGN KEY (BookID) REFERENCES Books(BookID));
SELECT * FROM Sales;
insert into Sales (BookID,SaleDate,SaleAmount)values(2,'2025/04/12',2000);
insert into Sales (BookID,SaleDate,SaleAmount)values(1,'2025/04/10',1000);
insert into Sales (BookID,SaleDate,SaleAmount)values(3,'2025/03/01',3000);
insert into Sales (BookID,SaleDate,SaleAmount)values(2,'2025/04/22',2000);
insert into Sales (BookID,SaleDate,SaleAmount)values(2,'2025/04/30',2000);


SELECT Books.Title,SUM(Sales.SaleAmount) AS TOTALSALES FROM Sales JOIN Books ON Sales.BookID=Books.BookID GROUP BY Books.Title;
SELECT Books.Title,YEAR(Sales.SaleDate) AS SALESYEAR,SUM(Sales.SaleAmount) AS TOTALSALES FROM Sales JOIN Books ON Sales.BookID=Books.BookID GROUP BY Books.Title,YEAR(Sales.SaleDate);

SELECT Books.BookID,Books.Title,SUM(Sales.SaleAmount) AS TOTALSALES FROM Books INNER JOIN Sales ON Books.BookID = Sales.BookID GROUP BY Books.BookID,Books.Title HAVING SUM(Sales.SaleAmount) > 2000;  

CREATE PROCEDURE GetTotalSalesByTitleSimple
(
    @BookTitle VARCHAR(255)
)
AS
BEGIN
    SELECT 
        Books.BookID,
        Books.Title,
        SUM(Sales.SaleAmount) AS Total_Sales
    FROM 
        Books
    INNER JOIN 
        Sales  ON Books.BookID = Sales.BookID
    WHERE 
        Books.Title = @BookTitle
    GROUP BY 
        Books.BookID, Books.Title;
END;

EXEC GetTotalSalesByTitleSimple 'Modern Cross-Platform Development';


CREATE FUNCTION dbo.GetAverageSaleAmount()
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @Average DECIMAL(10,2);

    SELECT @Average = AVG(SaleAmount) FROM Sales;

    RETURN @Average;
END;

SELECT dbo.GetAverageSaleAmount() AS Average_Sale;
