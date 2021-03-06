SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Employee] ([Id], [Name], [IsDeleted]) VALUES (1, N'Jignesh', 0)
INSERT [dbo].[Employee] ([Id], [Name], [IsDeleted]) VALUES (2, N'Rakesh', 0)
INSERT [dbo].[Employee] ([Id], [Name], [IsDeleted]) VALUES (3, N'Tejas', 0)
INSERT [dbo].[Employee] ([Id], [Name], [IsDeleted]) VALUES (4, N'Rajesh', 1)
