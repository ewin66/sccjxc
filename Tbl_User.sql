USE [UFTSystem]
GO

/****** Object:  Table [dbo].[Tbl_User]    Script Date: 2015-08-24 14:38:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tbl_User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cUserName] [nvarchar](50) NULL,
	[cPassWord] [nvarchar](50) NULL,
	[cLoginTime] [nvarchar](50) NULL,
	[is_Admin] [bit] NULL,
	[cPicture] [nvarchar](50) NULL,
	[cSalePrice] [nvarchar](50) NULL,
	[cCost] [nvarchar](50) NULL,
	[Import] [nvarchar](50) NULL,
	[iWareHouse] [nvarchar](200) NULL,
 CONSTRAINT [PK_Tbl_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Tbl_User] ADD  CONSTRAINT [DF_Tbl_User_cPicture]  DEFAULT (N'·ñ') FOR [cPicture]
GO

ALTER TABLE [dbo].[Tbl_User] ADD  CONSTRAINT [DF_Tbl_User_cSalePrice]  DEFAULT (N'·ñ') FOR [cSalePrice]
GO

ALTER TABLE [dbo].[Tbl_User] ADD  CONSTRAINT [DF_Tbl_User_cCost]  DEFAULT (N'·ñ') FOR [cCost]
GO

ALTER TABLE [dbo].[Tbl_User] ADD  CONSTRAINT [DF_Tbl_User_Import]  DEFAULT (N'·ñ') FOR [Import]
GO


