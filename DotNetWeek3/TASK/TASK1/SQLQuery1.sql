CREATE DATABASE LIBRARY;
USE LIBRARY;
CREATE TABLE BOOKS(BookTitle VARCHAR(50),Author VARCHAR(50),Year_of_Publishing INT);
INSERT INTO BOOKS(BookTitle,Author,Year_of_Publishing)VALUES('The Glass palace','Amitav Gosh',2000);
INSERT INTO BOOKS(BookTitle,Author,Year_of_Publishing)VALUES('Indias struggle for independence','Bipin chandra',1987);
INSERT INTO BOOKS(BookTitle,Author,Year_of_Publishing)VALUES('The Inheritance of Loss','Kiran Deshayi',2000);
INSERT INTO BOOKS(BookTitle,Author,Year_of_Publishing)VALUES('The Inheritance of Loss','Kiran Deshayi',2000);
SELECT * FROM BOOKS;
SELECT * FROM BOOKS WHERE Year_of_Publishing= 2000;
SELECT * FROM BOOKS WHERE Author='Amitav Gosh';
SELECT DISTINCT Author FROM BOOKS; 

