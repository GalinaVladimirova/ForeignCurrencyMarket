USE [ForeignCurrencyMarket.FCMContext]
GO

/****** Object:  Table [dbo].[Currencies]    Script Date: 14.07.2020 11:36:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Currencies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CharCode] [nvarchar](max) NULL,
	[Nominal] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [float] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Currencies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


