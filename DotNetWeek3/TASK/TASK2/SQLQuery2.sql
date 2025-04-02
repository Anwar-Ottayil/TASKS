CREATE TABLE Author (AuthorID INT IDENTITY(1,1) PRIMARY KEY,Name VARCHAR(100) NOT NULL, Country VARCHAR(50) NOT NULL);
SELECT * FROM Author;
CREATE TABLE Publisher(PublisherID INT IDENTITY(1,1) PRIMARY KEY, Name VARCHAR(100) NOT NULL, Location VARCHAR(100) NOT NULL);
SELECT * FROM Publisher;
CREATE TABLE Book (BookID INT IDENTITY(1,1) PRIMARY KEY, Title VARCHAR(200) NOT NULL,AuthorID INT NOT NULL, PublisherID INT NOT NULL,Price DECIMAL(10,2)CHECK (Price>0),PublishedYear INT CHECK (PublishedYear BETWEEN 1500 AND 2100 ),FOREIGN KEY (AuthorID)REFERENCES Author(AuthorID)ON UPDATE CASCADE ON DELETE CASCADE,FOREIGN KEY (PublisherID)REFERENCES Publisher(PublisherID)ON UPDATE CASCADE ON DELETE CASCADE);
SELECT * FROM Book;
INSERT INTO Author (Name, Country)VALUES  ('Amitav Gosh','INDIA');
INSERT INTO Author (Name, Country)VALUES  ('Bipin Chandra','INDIA');
INSERT INTO Author (Name, Country)VALUES  ('Kiran Deshayi','INDIA');
SELECT * FROM Author;
INSERT INTO Publisher (Name,Location)VALUES ('DC BOOKS','KOLLAM'),('HILLTON','KOTTAYAM'),('MG BOOKS','TVM');
SELECT * FROM Publisher;
INSERT INTO Book(Title,AuthorID,PublisherID,Price,PublishedYear)VALUES('Harry Potter and the Philosopher''s stone',1,1,19.99,1997),('A Game of Thrones',2,2,24.99,1996),('The Hobbit',3,3,15.99,1937),('Harry Potter and the chamber of secrets',1,1,21.99,1998);
SELECT * FROM Book;
SELECT b.BookID,b.Title,a.Name AS Author,p.Name AS Publisher, b.Price,b.PublishedYear FROM Book b INNER JOIN Author a ON b.AuthorID=a.AuthorID INNER JOIN Publisher p ON b.PublisherID=p.PublisherID;
SELECT b.Title,a.Name AS Author FROM Book b LEFT JOIN Author a ON b.AuthorID=a.AuthorID;
SELECT b.Title, p.Name AS Publisher
FROM Book b
RIGHT JOIN Publisher p ON b.PublisherID = p.PublisherID;
SELECT b.Title, a.Name AS Author
FROM Book b
FULL OUTER JOIN Author a ON b.AuthorID = a.AuthorID;
UPDATE Author SET AuthorID=10 WHERE Name = 'J.K. Rowling';
DELETE FROM Author WHERE Name = 'J.R.R. Tolkien';
SELECT Title AS Name, 'Book' AS Type FROM Book UNION SELECT Name AS Name , 'Publisher' AS Type FROM Publisher;


