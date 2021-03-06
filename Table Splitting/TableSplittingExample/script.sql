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
	[EmailAddress] [varchar](255) NULL,
	[MobileNumber] [varchar](13) NULL,
	[AlternateNumber] [varchar](13) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Employee] ([Id], [Name], [IsDeleted], [EmailAddress], [MobileNumber], [AlternateNumber]) VALUES (1, N'Jignesh', 0, N'jignesh@gmail.com', N'9898985864', NULL)
INSERT [dbo].[Employee] ([Id], [Name], [IsDeleted], [EmailAddress], [MobileNumber], [AlternateNumber]) VALUES (2, N'Rakesh', 0, N'rakesh@gmail.com', N'9879456987', NULL)
INSERT [dbo].[Employee] ([Id], [Name], [IsDeleted], [EmailAddress], [MobileNumber], [AlternateNumber]) VALUES (3, N'Tejas', 0, N'tejas@gmail.com', N'9879458632', NULL)
INSERT [dbo].[Employee] ([Id], [Name], [IsDeleted], [EmailAddress], [MobileNumber], [AlternateNumber]) VALUES (4, N'Rajesh', 1, N'rajesh@gmail.com', N'9426897523', NULL)
