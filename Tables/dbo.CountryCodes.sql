CREATE TABLE [dbo].[CountryCodes]
(
[Code] [nvarchar] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CountryCodes] ADD CONSTRAINT [PK_CountryCodes] PRIMARY KEY CLUSTERED ([Code]) ON [PRIMARY]
GO
