SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Site]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Site](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Site_Name] [nvarchar](50) NULL,
	[Site_Descibe] [nvarchar](50) NULL,
	[Site_CopyRight] [nvarchar](50) NULL,
	[Site_Address] [nvarchar](150) NULL,
	[Site_Phone] [nvarchar](20) NULL,
	[Site_Record] [nvarchar](50) NULL,
	[Site_Remark] [nvarchar](50) NULL,
	[Site_AddTime] [datetime] NULL,
 CONSTRAINT [PK_Site] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Log_Source] [nvarchar](150) NULL,
	[Log_User] [nvarchar](50) NULL,
	[Log_Content] [nvarchar](150) NULL,
	[Log_Time] [datetime] NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Admin]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Admin_Name] [nvarchar](50) NOT NULL,
	[Admin_PassWord] [nvarchar](150) NOT NULL,
	[Admin_Remark] [nvarchar](150) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NewsType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NewsType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NewsTypeName_zh] [nvarchar](20) NULL,
	[NewsTypeName_en] [nvarchar](20) NULL,
	[NewsType_Remark] [nvarchar](150) NULL,
 CONSTRAINT [PK_NewsType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProductType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductTypeName_zh] [nvarchar](50) NULL,
	[ProductTypeName_en] [nvarchar](50) NULL,
	[ProductType_Remark] [nchar](150) NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Product_Name] [nvarchar](50) NULL,
	[Product_IsHomePagePicture] [bit] NULL,
	[Product_PictureSrc] [varchar](50) NULL,
	[Product_TypeId] [int] NULL,
	[Product_Introduce] [text] NULL,
	[Product_AddTime] [datetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[News]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[News](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[News_Title] [nvarchar](60) NOT NULL,
	[News_IsSpecial] [bit] NULL,
	[News_IsHomePagePicture] [bit] NULL,
	[News_PictureSrc] [nvarchar](100) NULL,
	[News_TypeId] [int] NULL,
	[News_Author] [nvarchar](50) NULL,
	[News_Source] [nvarchar](50) NULL,
	[News_Views] [int] NULL,
	[News_Content] [text] NOT NULL,
	[News_AddTime] [datetime] NOT NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Product_ProductType]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product]'))
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([Product_TypeId])
REFERENCES [dbo].[ProductType] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_News_NewsType]') AND parent_object_id = OBJECT_ID(N'[dbo].[News]'))
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_NewsType] FOREIGN KEY([News_TypeId])
REFERENCES [dbo].[NewsType] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_NewsType]
