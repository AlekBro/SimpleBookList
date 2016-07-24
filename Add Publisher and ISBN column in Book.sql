
IF NOT EXISTS (SELECT TOP 1 *
           FROM [sys].[columns]
           WHERE [name] = N'Publisher')
    BEGIN
        ALTER TABLE [dbo].[Books] ADD Publisher NVARCHAR(100) NULL;
    END;
    
IF NOT EXISTS (SELECT TOP 1 *
           FROM [sys].[columns]
           WHERE [name] = N'ISBN')
    BEGIN
        ALTER TABLE [dbo].[Books] ADD ISBN NVARCHAR(20) NULL;
    END;
    
