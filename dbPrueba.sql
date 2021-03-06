USE [DBPrueba]
GO
/****** Object:  Table [dbo].[ROLES]    Script Date: 6/7/2020 11:08:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROLES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ROLES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERROL]    Script Date: 6/7/2020 11:08:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERROL](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDUser] [int] NOT NULL,
	[IDRol] [int] NOT NULL,
 CONSTRAINT [PK_USERROL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIOS]    Script Date: 6/7/2020 11:08:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIOS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido1] [varchar](100) NOT NULL,
	[Apellido2] [varchar](100) NOT NULL,
	[Teléfono] [varchar](50) NOT NULL,
	[DIrección] [varchar](300) NOT NULL,
	[Correo] [varchar](100) NOT NULL,
 CONSTRAINT [PK_USUARIOS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ROLES] ON 

INSERT [dbo].[ROLES] ([ID], [Nombre]) VALUES (1, N'Role A')
INSERT [dbo].[ROLES] ([ID], [Nombre]) VALUES (2, N'Role B')
INSERT [dbo].[ROLES] ([ID], [Nombre]) VALUES (3, N'Role C')
SET IDENTITY_INSERT [dbo].[ROLES] OFF
GO
SET IDENTITY_INSERT [dbo].[USERROL] ON 

INSERT [dbo].[USERROL] ([ID], [IDUser], [IDRol]) VALUES (1, 2, 3)
SET IDENTITY_INSERT [dbo].[USERROL] OFF
GO
SET IDENTITY_INSERT [dbo].[USUARIOS] ON 

INSERT [dbo].[USUARIOS] ([ID], [Nombre], [Apellido1], [Apellido2], [Teléfono], [DIrección], [Correo]) VALUES (2, N'Daniel ', N'Gutierrez ', N'Alfaro ', N'5656565656', N'750 metros sur escuela Llano Brenes', N'ejemplo@hotmail.com')
SET IDENTITY_INSERT [dbo].[USUARIOS] OFF
GO
ALTER TABLE [dbo].[USERROL]  WITH CHECK ADD  CONSTRAINT [FK_USERROL_ROLES] FOREIGN KEY([IDRol])
REFERENCES [dbo].[ROLES] ([ID])
GO
ALTER TABLE [dbo].[USERROL] CHECK CONSTRAINT [FK_USERROL_ROLES]
GO
ALTER TABLE [dbo].[USERROL]  WITH CHECK ADD  CONSTRAINT [FK_USERROL_USUARIOS] FOREIGN KEY([IDUser])
REFERENCES [dbo].[USUARIOS] ([ID])
GO
ALTER TABLE [dbo].[USERROL] CHECK CONSTRAINT [FK_USERROL_USUARIOS]
GO
