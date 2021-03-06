USE [Demo]
GO
/****** Object:  Table [dbo].[DataDictionary]    Script Date: 2022-02-25 12:41:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataDictionary](
	[DataNo] [nvarchar](64) NOT NULL,
	[DictionaryType] [nvarchar](64) NULL,
	[Name] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_DATADICTIONARY] PRIMARY KEY CLUSTERED 
(
	[DataNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataDictionaryType]    Script Date: 2022-02-25 12:41:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataDictionaryType](
	[DictionaryType] [nvarchar](64) NOT NULL,
	[Name] [nvarchar](64) NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_DATADICTIONARYTYPE] PRIMARY KEY CLUSTERED 
(
	[DictionaryType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DataDictionary]  WITH CHECK ADD  CONSTRAINT [FK_DataDictionary_DataDictionaryType] FOREIGN KEY([DictionaryType])
REFERENCES [dbo].[DataDictionaryType] ([DictionaryType])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DataDictionary] CHECK CONSTRAINT [FK_DataDictionary_DataDictionaryType]
GO
