DELETE FROM [dbo].[BookAuthors];

DELETE FROM [dbo].[Books];

DELETE FROM [dbo].[Authors];

SET IDENTITY_INSERT [dbo].[Books] ON;

INSERT INTO [dbo].[Books]( [Id]
                          ,[Name]
                          ,[ReleaseDate]
                          ,[Pages]
                          ,[Rating] )
VALUES
       (1
       ,N'Pro ASP.NET MVC 5 Platform'
       ,N'2014-04-18 00:00:00'
       ,428
       ,9);

INSERT INTO [dbo].[Books]( [Id]
                          ,[Name]
                          ,[ReleaseDate]
                          ,[Pages]
                          ,[Rating] )
VALUES
       (2
       ,N'Pro ASP.NET MVC 5 (Expert''s Voice in ASP.Net)'
       ,N'2013-12-23 00:00:00'
       ,832
       ,8);

INSERT INTO [dbo].[Books]( [Id]
                          ,[Name]
                          ,[ReleaseDate]
                          ,[Pages]
                          ,[Rating] )
VALUES
       (3
       ,N'Professional ASP.NET MVC 5'
       ,N'2014-08-04 00:00:00'
       ,624
       ,7);

INSERT INTO [dbo].[Books]( [Id]
                          ,[Name]
                          ,[ReleaseDate]
                          ,[Pages]
                          ,[Rating] )
VALUES
       (4
       ,N'The ASP.NET 2.0 Anthology: 101 Essential Tips, Tricks & Hacks'
       ,N'2007-09-18 00:00:00'
       ,500
       ,6);

INSERT INTO [dbo].[Books]( [Id]
                          ,[Name]
                          ,[ReleaseDate]
                          ,[Pages]
                          ,[Rating] )
VALUES
       (5
       ,N'C# 6.0 and the .NET 4.6 Framework'
       ,N'2015-11-08 00:00:00'
       ,1625
       ,1);

INSERT INTO [dbo].[Books]( [Id]
                          ,[Name]
                          ,[ReleaseDate]
                          ,[Pages]
                          ,[Rating] )
VALUES
       (6
       ,N'ASP.NET MVC 5 with Bootstrap and Knockout.js: Building Dynamic, Responsive Web Applications'
       ,N'2015-05-31 00:00:00'
       ,278
       ,3);

INSERT INTO [dbo].[Books]( [Id]
                          ,[Name]
                          ,[ReleaseDate]
                          ,[Pages]
                          ,[Rating] )
VALUES
       (7
       ,N'Knockout.js: Building Dynamic Client-Side Web Applications'
       ,N'2015-01-03 00:00:00'
       ,102
       ,4);

INSERT INTO [dbo].[Books]( [Id]
                          ,[Name]
                          ,[ReleaseDate]
                          ,[Pages]
                          ,[Rating] )
VALUES
       (8
       ,N'Learn ASP.NET MVC'
       ,N'2016-01-08 00:00:00'
       ,150
       ,2);

INSERT INTO [dbo].[Books]( [Id]
                          ,[Name]
                          ,[ReleaseDate]
                          ,[Pages]
                          ,[Rating] )
VALUES
       (9
       ,N'Front-end Development with ASP.NET MVC 6, AngularJS, and Bootstrap'
       ,N'2016-09-26 00:00:00'
       ,240
       ,5);

INSERT INTO [dbo].[Books]( [Id]
                          ,[Name]
                          ,[ReleaseDate]
                          ,[Pages]
                          ,[Rating] )
VALUES
       (10
       ,N'Pro AngularJS (Expert''s Voice in Web Development)'
       ,N'2014-03-27 00:00:00'
       ,688
       ,0);

INSERT INTO [dbo].[Books]( [Id]
                          ,[Name]
                          ,[ReleaseDate]
                          ,[Pages]
                          ,[Rating] )
VALUES
       (11
       ,N'Pro ASP.NET 4.5 in C#'
       ,N'2013-07-15 00:00:00'
       ,1228
       ,10);

INSERT INTO [dbo].[Books]( [Id]
                          ,[Name]
                          ,[ReleaseDate]
                          ,[Pages]
                          ,[Rating] )
VALUES
       (12
       ,N'Expert ASP.NET Web API 2 for MVC Developers'
       ,N'2015-08-15 00:00:00'
       ,688
       ,5);

INSERT INTO [dbo].[Books]( [Id]
                          ,[Name]
                          ,[ReleaseDate]
                          ,[Pages]
                          ,[Rating] )
VALUES
       (13
       ,N'Pro ASP.NET MVC 4'
       ,N'2013-01-16 00:00:00'
       ,756
       ,7);

INSERT INTO [dbo].[Books]( [Id]
                          ,[Name]
                          ,[ReleaseDate]
                          ,[Pages]
                          ,[Rating] )
VALUES
       (14
       ,N'Programming ASP.NET MVC 4: Developing Real-World Web Applications with ASP.NET MVC'
       ,N'2012-10-06 00:00:00'
       ,492
       ,1);

INSERT INTO [dbo].[Books]( [Id]
                          ,[Name]
                          ,[ReleaseDate]
                          ,[Pages]
                          ,[Rating] )
VALUES
       (15
       ,N'Programming Razor'
       ,N'2011-09-25 00:00:00'
       ,120
       ,3);

SET IDENTITY_INSERT [dbo].[Books] OFF;

SET IDENTITY_INSERT [dbo].[Authors] ON;

INSERT INTO [dbo].[Authors]( [Id]
                            ,[FirstName]
                            ,[LastName] )
VALUES
       (1
       ,N'Adam'
       ,N'Freeman');

INSERT INTO [dbo].[Authors]( [Id]
                            ,[FirstName]
                            ,[LastName] )
VALUES
       (2
       ,N'Jon'
       ,N'Galloway');

INSERT INTO [dbo].[Authors]( [Id]
                            ,[FirstName]
                            ,[LastName] )
VALUES
       (3
       ,N'Brad'
       ,N'Wilson');

INSERT INTO [dbo].[Authors]( [Id]
                            ,[FirstName]
                            ,[LastName] )
VALUES
       (4
       ,N'Scott'
       ,N'Allen');

INSERT INTO [dbo].[Authors]( [Id]
                            ,[FirstName]
                            ,[LastName] )
VALUES
       (5
       ,N'David'
       ,N'Matson');

INSERT INTO [dbo].[Authors]( [Id]
                            ,[FirstName]
                            ,[LastName] )
VALUES
       (6
       ,N'Jeff'
       ,N'Atwood');

INSERT INTO [dbo].[Authors]( [Id]
                            ,[FirstName]
                            ,[LastName] )
VALUES
       (7
       ,N'Wyatt'
       ,N'Barnett');

INSERT INTO [dbo].[Authors]( [Id]
                            ,[FirstName]
                            ,[LastName] )
VALUES
       (8
       ,N'Phil'
       ,N'Haack');

INSERT INTO [dbo].[Authors]( [Id]
                            ,[FirstName]
                            ,[LastName] )
VALUES
       (9
       ,N'Andrew'
       ,N'Troelsen');

INSERT INTO [dbo].[Authors]( [Id]
                            ,[FirstName]
                            ,[LastName] )
VALUES
       (10
       ,N'Philip'
       ,N'Japikse');

INSERT INTO [dbo].[Authors]( [Id]
                            ,[FirstName]
                            ,[LastName] )
VALUES
       (11
       ,N'Jamie'
       ,N'Munro');

INSERT INTO [dbo].[Authors]( [Id]
                            ,[FirstName]
                            ,[LastName] )
VALUES
       (12
       ,N'Arnaud'
       ,N'Weil');

INSERT INTO [dbo].[Authors]( [Id]
                            ,[FirstName]
                            ,[LastName] )
VALUES
       (13
       ,N'Simone'
       ,N'Chiaretta');

INSERT INTO [dbo].[Authors]( [Id]
                            ,[FirstName]
                            ,[LastName] )
VALUES
       (14
       ,N'Jess'
       ,N'Chadwick');

INSERT INTO [dbo].[Authors]( [Id]
                            ,[FirstName]
                            ,[LastName] )
VALUES
       (15
       ,N'Todd'
       ,N'Snyder');

INSERT INTO [dbo].[Authors]( [Id]
                            ,[FirstName]
                            ,[LastName] )
VALUES
       (16
       ,N'Hrusikesh'
       ,N'Panda');

SET IDENTITY_INSERT [dbo].[Authors] OFF;

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (1
       ,1);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (2
       ,1);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (10
       ,1);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (11
       ,1);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (12
       ,1);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (13
       ,1);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (3
       ,2);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (4
       ,2);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (3
       ,3);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (3
       ,4);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (4
       ,4);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (3
       ,5);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (4
       ,6);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (4
       ,7);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (4
       ,8);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (5
       ,9);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (5
       ,10);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (6
       ,11);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (7
       ,11);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (8
       ,12);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (9
       ,13);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (14
       ,14);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (15
       ,14);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (14
       ,15);

INSERT INTO [dbo].[BookAuthors]( [Book_Id]
                                ,[Author_Id] )
VALUES
       (14
       ,16);