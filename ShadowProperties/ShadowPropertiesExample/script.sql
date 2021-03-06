SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Employee] ([Id], [Name], [CreatedDate]) VALUES (1, N'Jignesh', GETDATE())
GO
INSERT [dbo].[Employee] ([Id], [Name], [CreatedDate]) VALUES (2, N'Rakesh', GETDATE())
GO
INSERT [dbo].[Employee] ([Id], [Name], [CreatedDate]) VALUES (3, N'Tejas', GETDATE())
GO
INSERT [dbo].[Employee] ([Id], [Name], [CreatedDate]) VALUES (4, N'Rajesh', GETDATE())
GO
