CREATE DATABASE PartitionTest;
GO

USE PartitionTest;
GO

ALTER DATABASE PartitionTest  
ADD FILEGROUP test1fg;  
GO  
ALTER DATABASE PartitionTest  
ADD FILEGROUP test2fg;  
GO  
ALTER DATABASE PartitionTest  
ADD FILEGROUP test3fg;  
GO  
ALTER DATABASE PartitionTest  
ADD FILEGROUP test4fg;   

ALTER DATABASE PartitionTest   
ADD FILE   
(  
    NAME = partitiontest1,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\partitiontest1.ndf',  
    SIZE = 5MB,  
    FILEGROWTH = 5MB  
)  
TO FILEGROUP test1fg;  
ALTER DATABASE PartitionTest   
ADD FILE   
(  
    NAME = partitiontest2,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\partitiontest2.ndf',  
    SIZE = 5MB,  
    FILEGROWTH = 5MB  
)  
TO FILEGROUP test2fg;  
GO  
ALTER DATABASE PartitionTest   
ADD FILE   
(  
    NAME = partitiontest3,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\partitiontest3.ndf',  
    SIZE = 5MB,  
    FILEGROWTH = 5MB  
)  
TO FILEGROUP test3fg;  
GO  
ALTER DATABASE PartitionTest   
ADD FILE   
(  
    NAME = partitiontest4,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\partitiontest4.ndf',  
    SIZE = 5MB,  
    FILEGROWTH = 5MB  
)  
TO FILEGROUP test4fg;  
GO  

CREATE PARTITION FUNCTION myRangePF1 (datetime2(0))  
    AS RANGE RIGHT FOR VALUES ('2022-04-01', '2022-05-01', '2022-06-01') ;  
GO  

CREATE PARTITION SCHEME myRangePS1  
    AS PARTITION myRangePF1  
    TO (test1fg, test2fg, test3fg, test4fg) ;  
GO  

CREATE TABLE PartitionTable (col1 datetime2(0) PRIMARY KEY, col2 char(10))  
    ON myRangePS1 (col1) ;  
GO  