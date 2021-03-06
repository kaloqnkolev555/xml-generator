SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID (N'error_codes_master', N'U') IS NOT NULL
	DROP TABLE [dbo].[error_codes_master];

CREATE TABLE [dbo].[error_codes_master](
    [id] [int] IDENTITY(1,1) NOT NULL,
	[error_code] [int] NOT NULL,
	[error_description] [nvarchar](255) NOT NULL,
	[language_code] [nvarchar](50) NULL
PRIMARY KEY CLUSTERED
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(101, 'Area name is missing', 'en')
INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(102, 'No area(s) to delete', 'en')
INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(103, 'No area was selected to rename', 'en')
INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(104, 'No area was selected to update object mapping', 'en')
INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(105, 'Area name is not unique', 'en')

INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(201, 'Variant name is missing', 'en')
INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(202, 'No variant(s) to delete', 'en')
INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(203, 'No variant was selected to rename', 'en')
INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(204, 'No variant was selected to update object mapping', 'en')
INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(205, 'Variant name is not unique', 'en')

INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(301, 'Configuration name is missing', 'en')
INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(302, 'No configuration(s) to delete', 'en')
INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(303, 'No configuration was selected to rename', 'en')
INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(304, 'No configuration was selected to update variant mapping', 'en')
INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(305, 'Configuration name and variant already exists', 'en')
INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(306, 'No variants were provided for mapping', 'en')

INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(401, 'Object name is missing', 'en')
INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(402, 'No object(s) to delete', 'en')
INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(403, 'No object was selected to rename', 'en')
INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(404, 'No object was selected to update area mapping', 'en')
INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(405, 'Object name is not unique', 'en')

INSERT INTO [dbo].[error_codes_master] ([error_code], [error_description], [language_code]) VALUES(501, 'Table name is missing', 'en')