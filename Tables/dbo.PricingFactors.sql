CREATE TABLE [dbo].[PricingFactors]
(
[Id] [bigint] NOT NULL IDENTITY(1, 1),
[CustomerNumber] [bigint] NULL,
[CountryCode] [nvarchar] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Factor] [bigint] NOT NULL,
[Date] [date] NOT NULL,
[ProductGroup] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PricingFactors] ADD CONSTRAINT [PK_PricingFactors] PRIMARY KEY CLUSTERED ([Id]) ON [PRIMARY]
GO
