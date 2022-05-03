USE AdventureWorks2016
GO
ALTER TABLE Production.TransactionHistoryArchive  
DROP CONSTRAINT PK_TransactionHistoryArchive_TransactionID;   
GO
CREATE CLUSTERED INDEX IX_TransactionHistoryArchive_Quantity  
    ON Production.TransactionHistoryArchive (Quantity);   
GO