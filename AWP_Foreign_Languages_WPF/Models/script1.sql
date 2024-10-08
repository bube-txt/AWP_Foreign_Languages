USE [AWP_Foreign_Language]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 30.05.2022 6:06:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[IdAttendance] [int] NOT NULL,
	[IdClient] [int] NOT NULL,
	[IdLesson] [int] NOT NULL,
	[BoolAttendance] [tinyint] NULL,
 CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED 
(
	[IdAttendance] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 30.05.2022 6:06:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[IdClient] [int] IDENTITY(1,1) NOT NULL,
	[IdUserClient] [int] NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[IdClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientGroup]    Script Date: 30.05.2022 6:06:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientGroup](
	[IdClientGroup] [int] IDENTITY(1,1) NOT NULL,
	[IdClient] [int] NOT NULL,
	[IdGroup] [int] NOT NULL,
 CONSTRAINT [PK_ClientGroup] PRIMARY KEY CLUSTERED 
(
	[IdClientGroup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 30.05.2022 6:06:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[IdGroup] [int] IDENTITY(1,1) NOT NULL,
	[NameGroup] [nvarchar](50) NOT NULL,
	[IdLanguageGroup] [int] NOT NULL,
	[IdServiceGroup] [int] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[IdGroup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 30.05.2022 6:06:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[IdLanguage] [int] IDENTITY(1,1) NOT NULL,
	[NameLanguage] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[IdLanguage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 30.05.2022 6:06:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lesson](
	[IdLesson] [int] IDENTITY(1,1) NOT NULL,
	[LanguageIdLesson] [int] NULL,
	[ServiceIdLesson] [int] NOT NULL,
	[DateLesson] [date] NOT NULL,
	[TimeLesson] [time](7) NOT NULL,
	[IdTeacherLesson] [int] NOT NULL,
	[HomeworkLesson] [text] NULL,
 CONSTRAINT [PK_Lesson] PRIMARY KEY CLUSTERED 
(
	[IdLesson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LessonTeacher]    Script Date: 30.05.2022 6:06:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LessonTeacher](
	[IdLessonTeacher] [int] IDENTITY(1,1) NOT NULL,
	[IdLesson] [int] NOT NULL,
	[IdUser] [int] NOT NULL,
 CONSTRAINT [PK_LessonTeacher] PRIMARY KEY CLUSTERED 
(
	[IdLessonTeacher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 30.05.2022 6:06:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[IdRole] [int] IDENTITY(1,1) NOT NULL,
	[NameRole] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 30.05.2022 6:06:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[IdService] [int] IDENTITY(1,1) NOT NULL,
	[NameService] [nvarchar](50) NOT NULL,
	[PriceService] [int] NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[IdService] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceTeacher]    Script Date: 30.05.2022 6:06:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceTeacher](
	[IdServiceTeacher] [int] IDENTITY(1,1) NOT NULL,
	[IdService] [int] NOT NULL,
	[IdTeacher] [int] NOT NULL,
 CONSTRAINT [PK_ServiceTeacher] PRIMARY KEY CLUSTERED 
(
	[IdServiceTeacher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 30.05.2022 6:06:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[IdTeacher] [int] IDENTITY(1,1) NOT NULL,
	[IdLanguageTeacher] [int] NOT NULL,
	[IdUserTeacher] [int] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[IdTeacher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherGroup]    Script Date: 30.05.2022 6:06:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherGroup](
	[IdTeacherGroup] [int] IDENTITY(1,1) NOT NULL,
	[IdTeacher] [int] NOT NULL,
	[IdGroup] [int] NOT NULL,
 CONSTRAINT [PK_TeacherGroup_1] PRIMARY KEY CLUSTERED 
(
	[IdTeacherGroup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 30.05.2022 6:06:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[PasswordUser] [nvarchar](50) NOT NULL,
	[IdRoleUser] [int] NOT NULL,
	[LastNameUser] [nvarchar](50) NOT NULL,
	[FirstNameUser] [nvarchar](50) NOT NULL,
	[PatronicNameUser] [nvarchar](50) NULL,
	[EmailUser] [nvarchar](50) NULL,
	[PhoneUser] [nvarchar](11) NULL,
	[BirthdayUser] [date] NULL,
	[SexUser] [char](1) NOT NULL,
	[AvatarUser] [image] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([IdClient], [IdUserClient]) VALUES (1, 5)
SET IDENTITY_INSERT [dbo].[Client] OFF
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([IdGroup], [NameGroup], [IdLanguageGroup], [IdServiceGroup]) VALUES (3, N'А01', 1, 1)
SET IDENTITY_INSERT [dbo].[Group] OFF
SET IDENTITY_INSERT [dbo].[Language] ON 

INSERT [dbo].[Language] ([IdLanguage], [NameLanguage]) VALUES (1, N'Английский')
SET IDENTITY_INSERT [dbo].[Language] OFF
SET IDENTITY_INSERT [dbo].[Lesson] ON 

INSERT [dbo].[Lesson] ([IdLesson], [LanguageIdLesson], [ServiceIdLesson], [DateLesson], [TimeLesson], [IdTeacherLesson], [HomeworkLesson]) VALUES (3, 1, 1, CAST(N'2022-06-05' AS Date), CAST(N'12:00:00' AS Time), 1, NULL)
INSERT [dbo].[Lesson] ([IdLesson], [LanguageIdLesson], [ServiceIdLesson], [DateLesson], [TimeLesson], [IdTeacherLesson], [HomeworkLesson]) VALUES (4, 1, 3, CAST(N'2022-06-03' AS Date), CAST(N'14:00:00' AS Time), 1, N'<FlowDocument PagePadding="5,0,5,0" AllowDrop="True" NumberSubstitution.CultureSource="User" xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"><Paragraph>123</Paragraph></FlowDocument>')
INSERT [dbo].[Lesson] ([IdLesson], [LanguageIdLesson], [ServiceIdLesson], [DateLesson], [TimeLesson], [IdTeacherLesson], [HomeworkLesson]) VALUES (6, 1, 6, CAST(N'2022-06-01' AS Date), CAST(N'08:00:00' AS Time), 1, N'<FlowDocument PagePadding="5,0,5,0" AllowDrop="True" NumberSubstitution.CultureSource="User" xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"><Paragraph>321</Paragraph><Paragraph xml:space="preserve" /><Paragraph><Run xml:lang="ru-ru">?????????</Run></Paragraph><Paragraph><Run xml:lang="ru-ru">??</Run></Paragraph><Paragraph><Run xml:lang="ru-ru">?</Run></Paragraph><Paragraph><Run xml:lang="ru-ru">???</Run></Paragraph><Paragraph><Run xml:lang="ru-ru">??</Run></Paragraph><Paragraph><Run xml:lang="ru-ru">?</Run></Paragraph><Paragraph><Run xml:lang="ru-ru">??</Run></Paragraph><Paragraph><Run xml:lang="ru-ru" xml:space="preserve" /></Paragraph><Paragraph><Run xml:lang="ru-ru" xml:space="preserve" /></Paragraph><Paragraph><Run xml:lang="ru-ru" xml:space="preserve" /></Paragraph><Paragraph><Run xml:lang="ru-ru" xml:space="preserve" /></Paragraph></FlowDocument>')
SET IDENTITY_INSERT [dbo].[Lesson] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([IdRole], [NameRole]) VALUES (1, N'Клиент')
INSERT [dbo].[Role] ([IdRole], [NameRole]) VALUES (2, N'Преподаватель')
INSERT [dbo].[Role] ([IdRole], [NameRole]) VALUES (3, N'Администратор')
INSERT [dbo].[Role] ([IdRole], [NameRole]) VALUES (4, N'Тестовый режим')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([IdService], [NameService], [PriceService]) VALUES (1, N'Лайт', 1299)
INSERT [dbo].[Service] ([IdService], [NameService], [PriceService]) VALUES (3, N'Стандарт', 2099)
INSERT [dbo].[Service] ([IdService], [NameService], [PriceService]) VALUES (4, N'Эксперт', 2599)
INSERT [dbo].[Service] ([IdService], [NameService], [PriceService]) VALUES (6, N'Ультра', 4999)
SET IDENTITY_INSERT [dbo].[Service] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([IdTeacher], [IdLanguageTeacher], [IdUserTeacher]) VALUES (1, 1, 6)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
SET IDENTITY_INSERT [dbo].[TeacherGroup] ON 

INSERT [dbo].[TeacherGroup] ([IdTeacherGroup], [IdTeacher], [IdGroup]) VALUES (2, 1, 3)
SET IDENTITY_INSERT [dbo].[TeacherGroup] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([IdUser], [PasswordUser], [IdRoleUser], [LastNameUser], [FirstNameUser], [PatronicNameUser], [EmailUser], [PhoneUser], [BirthdayUser], [SexUser], [AvatarUser]) VALUES (4, N'qwe', 3, N'LastName', N'FirstName', N'PatronicName', N'123@mail.ru', N'79089005533', CAST(N'1970-01-01' AS Date), N'S', NULL)
INSERT [dbo].[User] ([IdUser], [PasswordUser], [IdRoleUser], [LastNameUser], [FirstNameUser], [PatronicNameUser], [EmailUser], [PhoneUser], [BirthdayUser], [SexUser], [AvatarUser]) VALUES (5, N'123', 1, N'a', N'a', N'a', N'A@mail.ru', N'79112223344', CAST(N'2022-05-18' AS Date), N'M', NULL)
INSERT [dbo].[User] ([IdUser], [PasswordUser], [IdRoleUser], [LastNameUser], [FirstNameUser], [PatronicNameUser], [EmailUser], [PhoneUser], [BirthdayUser], [SexUser], [AvatarUser]) VALUES (6, N'qwe', 2, N'a', N'b', N'c', N'2@abc.com', N'79864532121', CAST(N'1999-01-01' AS Date), N'W', NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Client] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([IdClient])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Client]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Lesson] FOREIGN KEY([IdLesson])
REFERENCES [dbo].[Lesson] ([IdLesson])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Lesson]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_User] FOREIGN KEY([IdUserClient])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_User]
GO
ALTER TABLE [dbo].[ClientGroup]  WITH CHECK ADD  CONSTRAINT [FK_ClientGroup_Client] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([IdClient])
GO
ALTER TABLE [dbo].[ClientGroup] CHECK CONSTRAINT [FK_ClientGroup_Client]
GO
ALTER TABLE [dbo].[ClientGroup]  WITH CHECK ADD  CONSTRAINT [FK_ClientGroup_Group] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Group] ([IdGroup])
GO
ALTER TABLE [dbo].[ClientGroup] CHECK CONSTRAINT [FK_ClientGroup_Group]
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_Language] FOREIGN KEY([IdLanguageGroup])
REFERENCES [dbo].[Language] ([IdLanguage])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_Language]
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_Service] FOREIGN KEY([IdServiceGroup])
REFERENCES [dbo].[Service] ([IdService])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_Service]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Teacher] FOREIGN KEY([IdTeacherLesson])
REFERENCES [dbo].[Teacher] ([IdTeacher])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_Teacher]
GO
ALTER TABLE [dbo].[LessonTeacher]  WITH CHECK ADD  CONSTRAINT [FK_LessonTeacher_Lesson] FOREIGN KEY([IdLesson])
REFERENCES [dbo].[Lesson] ([IdLesson])
GO
ALTER TABLE [dbo].[LessonTeacher] CHECK CONSTRAINT [FK_LessonTeacher_Lesson]
GO
ALTER TABLE [dbo].[LessonTeacher]  WITH CHECK ADD  CONSTRAINT [FK_LessonTeacher_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[LessonTeacher] CHECK CONSTRAINT [FK_LessonTeacher_User]
GO
ALTER TABLE [dbo].[ServiceTeacher]  WITH CHECK ADD  CONSTRAINT [FK_ServiceTeacher_Service] FOREIGN KEY([IdService])
REFERENCES [dbo].[Service] ([IdService])
GO
ALTER TABLE [dbo].[ServiceTeacher] CHECK CONSTRAINT [FK_ServiceTeacher_Service]
GO
ALTER TABLE [dbo].[ServiceTeacher]  WITH CHECK ADD  CONSTRAINT [FK_ServiceTeacher_Teacher] FOREIGN KEY([IdTeacher])
REFERENCES [dbo].[Teacher] ([IdTeacher])
GO
ALTER TABLE [dbo].[ServiceTeacher] CHECK CONSTRAINT [FK_ServiceTeacher_Teacher]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Language] FOREIGN KEY([IdLanguageTeacher])
REFERENCES [dbo].[Language] ([IdLanguage])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Language]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_User] FOREIGN KEY([IdUserTeacher])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_User]
GO
ALTER TABLE [dbo].[TeacherGroup]  WITH CHECK ADD  CONSTRAINT [FK_TeacherGroup_Group] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Group] ([IdGroup])
GO
ALTER TABLE [dbo].[TeacherGroup] CHECK CONSTRAINT [FK_TeacherGroup_Group]
GO
ALTER TABLE [dbo].[TeacherGroup]  WITH CHECK ADD  CONSTRAINT [FK_TeacherGroup_Teacher] FOREIGN KEY([IdTeacher])
REFERENCES [dbo].[Teacher] ([IdTeacher])
GO
ALTER TABLE [dbo].[TeacherGroup] CHECK CONSTRAINT [FK_TeacherGroup_Teacher]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([IdRoleUser])
REFERENCES [dbo].[Role] ([IdRole])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
