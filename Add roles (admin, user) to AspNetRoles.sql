IF NOT EXISTS (SELECT TOP 1 *
           FROM [dbo].[AspNetRoles]
           WHERE [name] = N'admin')
    BEGIN
        INSERT INTO [dbo].[AspNetRoles] ([Id],[Name]) VALUES ((SELECT ISNULL(MAX(ID) + 1, 1) FROM [dbo].[AspNetRoles]), 'admin');
    END;

IF NOT EXISTS (SELECT TOP 1 *
           FROM [dbo].[AspNetRoles]
           WHERE [name] = N'user')
    BEGIN
        INSERT INTO [dbo].[AspNetRoles] ([Id],[Name]) VALUES ((SELECT ISNULL(MAX(ID) + 1, 1) FROM [dbo].[AspNetRoles]), 'user');
    END;