USE [capitoshka]
GO
/****** Object:  Table [dbo].[Child]    Script Date: 27.06.2024 3:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Child](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[Patronymic] [nvarchar](100) NULL,
	[Birthday] [date] NULL,
	[IDParent] [int] NULL,
 CONSTRAINT [PK_Child] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Direction]    Script Date: 27.06.2024 3:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Direction](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_Direction] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 27.06.2024 3:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[IDTypeOfEvents] [int] NULL,
	[StartDate] [date] NULL,
	[ExpirationDate] [date] NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 27.06.2024 3:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[IDDirection] [int] NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupParticipant]    Script Date: 27.06.2024 3:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupParticipant](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDPedagog] [int] NULL,
	[IDGroup] [int] NULL,
	[IDEvents] [int] NULL,
 CONSTRAINT [PK_GroupParticipant] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListGroups]    Script Date: 27.06.2024 3:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListGroups](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDGroup] [int] NULL,
	[IDChild] [int] NULL,
	[StartDate] [date] NULL,
	[ExpirationDate] [date] NULL,
 CONSTRAINT [PK_ListGroups] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parents]    Script Date: 27.06.2024 3:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parents](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[Patronymic] [nvarchar](100) NULL,
	[Birthday] [date] NULL,
	[PlaceOfWork] [nvarchar](100) NULL,
	[Phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Parents] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 27.06.2024 3:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfEvents]    Script Date: 27.06.2024 3:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfEvents](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NULL,
 CONSTRAINT [PK_TypeOfEvents] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 27.06.2024 3:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[Patronymic] [nvarchar](100) NULL,
	[Phone] [nvarchar](100) NULL,
	[Birthday] [date] NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Post] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Child] ON 

INSERT [dbo].[Child] ([ID], [Surname], [Name], [Patronymic], [Birthday], [IDParent]) VALUES (1, N'Григорьева', N'Мария', N'Дмитриевна', CAST(N'2010-10-25' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Child] OFF
GO
SET IDENTITY_INSERT [dbo].[Direction] ON 

INSERT [dbo].[Direction] ([ID], [Name]) VALUES (1, N'Народные танцы')
INSERT [dbo].[Direction] ([ID], [Name]) VALUES (2, N'Рисование')
INSERT [dbo].[Direction] ([ID], [Name]) VALUES (3, N'Лепка из глины')
INSERT [dbo].[Direction] ([ID], [Name]) VALUES (4, N'Шахматы')
INSERT [dbo].[Direction] ([ID], [Name]) VALUES (5, N'Фортепиано')
INSERT [dbo].[Direction] ([ID], [Name]) VALUES (6, N'Квиллинг')
INSERT [dbo].[Direction] ([ID], [Name]) VALUES (7, N'Декупаж')
INSERT [dbo].[Direction] ([ID], [Name]) VALUES (8, N'Йога')
SET IDENTITY_INSERT [dbo].[Direction] OFF
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([ID], [Name], [IDTypeOfEvents], [StartDate], [ExpirationDate]) VALUES (1, N'Звездопад', 6, CAST(N'2024-06-27' AS Date), CAST(N'2024-07-03' AS Date))
INSERT [dbo].[Events] ([ID], [Name], [IDTypeOfEvents], [StartDate], [ExpirationDate]) VALUES (2, N'Музыкалити', 6, CAST(N'2024-06-23' AS Date), CAST(N'2024-08-01' AS Date))
SET IDENTITY_INSERT [dbo].[Events] OFF
GO
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([ID], [Name], [IDDirection]) VALUES (1, N'Бобрики', 4)
INSERT [dbo].[Group] ([ID], [Name], [IDDirection]) VALUES (2, N'Темные лошадки', 4)
INSERT [dbo].[Group] ([ID], [Name], [IDDirection]) VALUES (3, N'Клавиши города', 5)
INSERT [dbo].[Group] ([ID], [Name], [IDDirection]) VALUES (4, N'Калинка', 1)
INSERT [dbo].[Group] ([ID], [Name], [IDDirection]) VALUES (5, N'Народники', 1)
INSERT [dbo].[Group] ([ID], [Name], [IDDirection]) VALUES (6, N'Кисточки и баночки', 2)
INSERT [dbo].[Group] ([ID], [Name], [IDDirection]) VALUES (7, N'Искусники', 2)
INSERT [dbo].[Group] ([ID], [Name], [IDDirection]) VALUES (8, N'Антистресс', 8)
INSERT [dbo].[Group] ([ID], [Name], [IDDirection]) VALUES (9, N'Мастер Салфетка', 7)
INSERT [dbo].[Group] ([ID], [Name], [IDDirection]) VALUES (10, N'Закуточки', 6)
INSERT [dbo].[Group] ([ID], [Name], [IDDirection]) VALUES (11, N'Дракончики', 6)
INSERT [dbo].[Group] ([ID], [Name], [IDDirection]) VALUES (12, N'Глиняные человечки', 3)
INSERT [dbo].[Group] ([ID], [Name], [IDDirection]) VALUES (13, N'Капелька', 2)
INSERT [dbo].[Group] ([ID], [Name], [IDDirection]) VALUES (14, N'Пупсики', 8)
INSERT [dbo].[Group] ([ID], [Name], [IDDirection]) VALUES (15, N'Лучики', 7)
SET IDENTITY_INSERT [dbo].[Group] OFF
GO
SET IDENTITY_INSERT [dbo].[Parents] ON 

INSERT [dbo].[Parents] ([ID], [Surname], [Name], [Patronymic], [Birthday], [PlaceOfWork], [Phone]) VALUES (1, N'Григорьев', N'Дмитрий', N'Флексеевич', CAST(N'1978-12-10' AS Date), N'ЛеруаМерлен', N'89023456723')
SET IDENTITY_INSERT [dbo].[Parents] OFF
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([ID], [Name]) VALUES (1, N'Адмнистратор')
INSERT [dbo].[Post] ([ID], [Name]) VALUES (2, N'Педагог')
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeOfEvents] ON 

INSERT [dbo].[TypeOfEvents] ([ID], [Name]) VALUES (6, N'Концерт   ')
INSERT [dbo].[TypeOfEvents] ([ID], [Name]) VALUES (7, N'Вебинар   ')
INSERT [dbo].[TypeOfEvents] ([ID], [Name]) VALUES (8, N'Выставка  ')
INSERT [dbo].[TypeOfEvents] ([ID], [Name]) VALUES (10, N'Тренинги  ')
INSERT [dbo].[TypeOfEvents] ([ID], [Name]) VALUES (15, N'          ')
SET IDENTITY_INSERT [dbo].[TypeOfEvents] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Surname], [Name], [Patronymic], [Phone], [Birthday], [Login], [Password], [Post]) VALUES (1, N'Анисимова', N'Павла', N'Андреевна', N'89023456782', CAST(N'1990-08-25' AS Date), N'Admin', N'admin90', 1)
INSERT [dbo].[Users] ([ID], [Surname], [Name], [Patronymic], [Phone], [Birthday], [Login], [Password], [Post]) VALUES (2, N'Егоров', N'Андрей', N'Семенович', N'89828904563', CAST(N'2003-11-01' AS Date), N'Sotrud', N'sOtrud4', 2)
INSERT [dbo].[Users] ([ID], [Surname], [Name], [Patronymic], [Phone], [Birthday], [Login], [Password], [Post]) VALUES (4, N'Бугай', N'Полина', N'Валерьевна', N'89125673421', CAST(N'2005-06-16' AS Date), N'Bugai', N'Bugai67', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Child]  WITH CHECK ADD  CONSTRAINT [FK_Child_Parents] FOREIGN KEY([IDParent])
REFERENCES [dbo].[Parents] ([ID])
GO
ALTER TABLE [dbo].[Child] CHECK CONSTRAINT [FK_Child_Parents]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_TypeOfEvents] FOREIGN KEY([IDTypeOfEvents])
REFERENCES [dbo].[TypeOfEvents] ([ID])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_TypeOfEvents]
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_Direction] FOREIGN KEY([IDDirection])
REFERENCES [dbo].[Direction] ([ID])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_Direction]
GO
ALTER TABLE [dbo].[GroupParticipant]  WITH CHECK ADD  CONSTRAINT [FK_GroupParticipant_Events] FOREIGN KEY([IDEvents])
REFERENCES [dbo].[Events] ([ID])
GO
ALTER TABLE [dbo].[GroupParticipant] CHECK CONSTRAINT [FK_GroupParticipant_Events]
GO
ALTER TABLE [dbo].[GroupParticipant]  WITH CHECK ADD  CONSTRAINT [FK_GroupParticipant_Group] FOREIGN KEY([IDGroup])
REFERENCES [dbo].[Group] ([ID])
GO
ALTER TABLE [dbo].[GroupParticipant] CHECK CONSTRAINT [FK_GroupParticipant_Group]
GO
ALTER TABLE [dbo].[GroupParticipant]  WITH CHECK ADD  CONSTRAINT [FK_GroupParticipant_Users] FOREIGN KEY([IDPedagog])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[GroupParticipant] CHECK CONSTRAINT [FK_GroupParticipant_Users]
GO
ALTER TABLE [dbo].[ListGroups]  WITH CHECK ADD  CONSTRAINT [FK_ListGroups_Child] FOREIGN KEY([IDChild])
REFERENCES [dbo].[Child] ([ID])
GO
ALTER TABLE [dbo].[ListGroups] CHECK CONSTRAINT [FK_ListGroups_Child]
GO
ALTER TABLE [dbo].[ListGroups]  WITH CHECK ADD  CONSTRAINT [FK_ListGroups_Group] FOREIGN KEY([IDGroup])
REFERENCES [dbo].[Group] ([ID])
GO
ALTER TABLE [dbo].[ListGroups] CHECK CONSTRAINT [FK_ListGroups_Group]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Post] FOREIGN KEY([Post])
REFERENCES [dbo].[Post] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Post]
GO
