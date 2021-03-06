USE [RadiusData]
GO
/****** Object:  Table [dbo].[cfgTblIdentifiers]    Script Date: 5/15/2017 2:06:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cfgTblIdentifiers](
	[ID] [uniqueidentifier] NOT NULL,
	[ID_Type] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
	[Text] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_cfgTblIdentifiers_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cfgTblObjectProperties]    Script Date: 5/15/2017 2:06:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cfgTblObjectProperties](
	[ID] [uniqueidentifier] NOT NULL,
	[ObjectID] [uniqueidentifier] NOT NULL,
	[Property] [nvarchar](50) NOT NULL,
	[DefaultValue] [nvarchar](50) NULL,
	[DataType] [uniqueidentifier] NOT NULL,
	[DisplayValue] [nvarchar](50) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[WriteSecurityLevel] [int] NOT NULL,
	[ControlType] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_cfgTblObjectPropertiesObjectType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cfgTblSignalProperties]    Script Date: 5/15/2017 2:06:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cfgTblSignalProperties](
	[ID] [uniqueidentifier] NOT NULL,
	[SignalID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DisplayName] [nvarchar](50) NULL,
	[Value] [nvarchar](50) NULL,
 CONSTRAINT [PK_cfgTblACMSignalProperties] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dataTblLogs]    Script Date: 5/15/2017 2:06:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dataTblLogs](
	[ID] [uniqueidentifier] NOT NULL,
	[Source] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Message] [nvarchar](150) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_dataTblLogs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dataTblObjects]    Script Date: 5/15/2017 2:06:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dataTblObjects](
	[ID] [uniqueidentifier] NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
	[ObjectType] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dataTblObjects] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dataTblSignalHistory]    Script Date: 5/15/2017 2:06:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dataTblSignalHistory](
	[ID] [uniqueidentifier] NOT NULL,
	[SignalID] [uniqueidentifier] NOT NULL,
	[TagName] [nvarchar](50) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dataTblSignalHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dataTblSignals]    Script Date: 5/15/2017 2:06:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dataTblSignals](
	[ID] [uniqueidentifier] NOT NULL,
	[TagName] [nvarchar](50) NOT NULL,
	[DisplayName] [nvarchar](50) NULL,
	[TimeStamp] [datetime] NOT NULL,
	[RawValue] [nvarchar](50) NULL,
	[Source] [uniqueidentifier] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[ItemDataType] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dataTblSignals] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[plgTblAcmComChannel]    Script Date: 5/15/2017 2:06:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[plgTblAcmComChannel](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[RTUCount] [decimal](18, 0) NOT NULL,
	[OPCDelay] [decimal](16, 2) NOT NULL,
	[ComFailures] [decimal](18, 0) NOT NULL,
	[OPCItemCount] [decimal](18, 0) NOT NULL,
	[OPCItemUpdateLastHour] [decimal](18, 0) NOT NULL,
	[OPCItemUpdateLast5Min] [decimal](18, 0) NOT NULL,
	[OPCUpdateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[plgTblAcmToSignalChannels]    Script Date: 5/15/2017 2:06:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[plgTblAcmToSignalChannels](
	[IO_Server] [nvarchar](50) NOT NULL,
	[CommChannel] [nvarchar](50) NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[Message] [nvarchar](100) NOT NULL,
	[Enable] [bit] NOT NULL,
	[Debug] [bit] NOT NULL,
	[Reload] [bit] NOT NULL,
	[ErrorTimeoutMinutes] [decimal](7, 2) NOT NULL,
	[LoadTimeMinutes] [decimal](7, 2) NOT NULL,
	[LoadComplete] [bit] NOT NULL,
	[RestartOnProcessError] [bit] NOT NULL,
 CONSTRAINT [PK_ConfigOpcToDbChannels_1] PRIMARY KEY CLUSTERED 
(
	[CommChannel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'e52c38e0-c8d7-450c-8d35-0122f7a8718a', N'DataTypes', N'System.SByte', N'sbyte')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'ae3fd59f-47ec-4b99-9bdb-075a98fb21c3', N'DataTypes', N'System.Int16', N'short')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'e8e5d959-e39e-4640-b408-08cd15da1fc8', N'DataTypes', N'System.Boolean', N'bool')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'c76fcaea-5760-4b75-8049-1bd2ab26b9dc', N'ControlType', N'CheckBox', N'Check Box')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'4f66d21f-e35d-4a24-925a-28831b515178', N'DataTypes', N'System.Double', N'double')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'4da80fe0-5519-43b8-85b4-2dd6403502a3', N'DataTypes', N'System.UInt32', N'uint')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'7fa2295c-f399-4350-8401-31225832c007', N'DataTypes', N'System.Char', N'char')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'd339a046-b818-46c4-b32c-60874d847f5c', N'DataTypes', N'System.Single', N'float')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'15c11f68-3042-438f-98d1-65061793a8fa', N'ControlType', N'ComboBox', N'Combo Box')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'26791782-37aa-4e6b-a652-72446cc0de70', N'ObjectTypes', N'WellLocation', N'Well Location')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'f3000cda-79b1-4ad6-896a-7446095e1c06', N'ObjectTypes', N'Meter', N'Meter')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'b7d51d76-cc9c-49ee-86b9-7e974ce7be66', N'Source', N'ACM', N'ACM')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'148c188d-ce36-4a7f-a5fc-83965a8a85fb', N'DataTypes', N'System.Object', N'object')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'e7f57517-fc2a-4621-98d7-92f3bf72d4b0', N'DataTypes', N'System.Byte', N'byte')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'562283ca-a30d-40ec-bbb0-b078a3c16fef', N'Source', N'File', N'File')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'23a20804-6426-46bb-a38e-b224fa4c2328', N'DataTypes', N'System.UInt16', N'ushort')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'21979b00-4285-4da7-af5b-b4559074b62d', N'ObjectTypes', N'RTU', N'RTU')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'd3d12dd1-681d-4354-820a-bcbbfd30d0af', N'DataTypes', N'System.Decimal', N'decimal')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'85964ecc-77dc-4a1e-b347-c2e32a3eb20b', N'DataTypes', N'System.Int32', N'int')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'2379014e-7aad-40a8-9d2b-c493e365190f', N'Source', N'SQL', N'SQL')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'930f0a3d-1fc3-4aaf-aa1e-c904ff9f9dcc', N'ControlType', N'TextBox', N'Text Box')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'2ae858f8-cea2-484f-9c15-d77b9223906a', N'DataTypes', N'System.String', N'string')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'5662982b-8176-48c7-8a14-d7da98df4b73', N'ObjectTypes', N'Well', N'Well')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'bfb14add-8a80-4e83-8f17-dd9766557330', N'DataTypes', N'System.Int64', N'long')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'3b3fba02-4016-46e1-a012-f053e7ef6d3c', N'Source', N'Calculated', N'Calculated')
INSERT [dbo].[cfgTblIdentifiers] ([ID], [ID_Type], [Value], [Text]) VALUES (N'62b1fa34-0eff-493c-8faf-fbfbe34e3372', N'DataTypes', N'System.UInt64', N'ulong')
INSERT [dbo].[cfgTblObjectProperties] ([ID], [ObjectID], [Property], [DefaultValue], [DataType], [DisplayValue], [DisplayOrder], [WriteSecurityLevel], [ControlType]) VALUES (N'8d558ed2-4b13-4182-991a-12001fbc7411', N'd1db5322-dbbb-47ab-aea1-a597f621a64e', N'ID', N'Meter ID', N'2ae858f8-cea2-484f-9c15-d77b9223906a', N'Meter ID', 1, 5000, N'930f0a3d-1fc3-4aaf-aa1e-c904ff9f9dcc')
INSERT [dbo].[cfgTblObjectProperties] ([ID], [ObjectID], [Property], [DefaultValue], [DataType], [DisplayValue], [DisplayOrder], [WriteSecurityLevel], [ControlType]) VALUES (N'a961b08f-7665-4ae9-865e-1ce016ac60f8', N'd1db5322-dbbb-47ab-aea1-a597f621a64e', N'Name', N'MeterName', N'2ae858f8-cea2-484f-9c15-d77b9223906a', N'Meter Name', 0, 5000, N'930f0a3d-1fc3-4aaf-aa1e-c904ff9f9dcc')
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'8fb09ca9-1018-40ac-af20-0107f9298b5a', N'026d5c4e-a175-49cd-a56d-cfdb895c35b1', N'RawMax', N'Raw Max', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'f6a06dbd-b5bb-4859-8e37-01d65e6e10b3', N'da61da6b-3208-42af-bd5d-b3d3e4540c2f', N'EnableWrite', N'Enable Write', N'0')
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'c191f084-95f4-4cdd-8d59-0f58b741c4fa', N'da61da6b-3208-42af-bd5d-b3d3e4540c2f', N'RawMin', N'Raw Min', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'8359b2df-584e-475e-b603-1143c5d7542d', N'da61da6b-3208-42af-bd5d-b3d3e4540c2f', N'EUMax', N'EU Max', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'723cc1ff-440f-46a9-b407-15bd1563c780', N'da61da6b-3208-42af-bd5d-b3d3e4540c2f', N'WriteSecurityLevel', N'Write Security Level', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'98fcc330-6e8c-4945-99a8-17d18aea73b1', N'7ffccd82-35e2-49b9-82a0-1e68de122e90', N'RawMax', N'Raw Max', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'af5df679-eade-47e2-a781-18a582953774', N'026d5c4e-a175-49cd-a56d-cfdb895c35b1', N'WriteSecurityLevel', N'Write Security Level', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'ce15bed5-517c-4606-b15b-194c50c929bb', N'7ffccd82-35e2-49b9-82a0-1e68de122e90', N'EnableScaling', N'Enable Scaling', N'0')
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'd96b9da2-715b-4b10-8889-1fdb35771a54', N'7ffccd82-35e2-49b9-82a0-1e68de122e90', N'EnableWrite', N'Enable Write', N'0')
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'3e61363a-2239-42c0-bb90-219dd428ea3a', N'59b7a6de-d12d-48f1-80cf-75d7465ac628', N'Precision', N'Precision', N'2')
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'878c88e5-5698-494f-8c37-2dea6e907e09', N'da61da6b-3208-42af-bd5d-b3d3e4540c2f', N'MaxValue', N'Max Value', N'500')
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'e6efd66d-4933-4cce-a1ab-301818dd27ed', N'59b7a6de-d12d-48f1-80cf-75d7465ac628', N'MinValue', N'Min Value', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'74d9a779-1074-4e33-af0b-320b9c6b9fb8', N'7ffccd82-35e2-49b9-82a0-1e68de122e90', N'EUMin', N'EU Min', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'49f2ac29-79e6-4721-8522-34886827c70c', N'59b7a6de-d12d-48f1-80cf-75d7465ac628', N'MaxValue', N'Max Value', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'10ae3788-a50a-4dd0-895f-3f51f3b4132f', N'026d5c4e-a175-49cd-a56d-cfdb895c35b1', N'EnableWrite', N'Enable Write', N'0')
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'37fb0e17-556c-4f89-89eb-425de325fd71', N'da61da6b-3208-42af-bd5d-b3d3e4540c2f', N'EUMin', N'EU Min', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'0cc6e5f7-0395-40eb-a5c5-42f538f12b86', N'59b7a6de-d12d-48f1-80cf-75d7465ac628', N'RawMax', N'Raw Max', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'cbae38d3-9306-4f8d-a06e-4861fd896456', N'026d5c4e-a175-49cd-a56d-cfdb895c35b1', N'RawMin', N'Raw Min', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'68563ce7-d561-421e-b36d-4c3f8343e3f7', N'7ffccd82-35e2-49b9-82a0-1e68de122e90', N'RawMin', N'Raw Min', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'ceb8904b-cac1-4603-aa94-530360e77303', N'da61da6b-3208-42af-bd5d-b3d3e4540c2f', N'MinValue', N'Min Value', N'-50')
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'b4e7d05d-23d4-4f5d-9ce5-55e963c2da7f', N'026d5c4e-a175-49cd-a56d-cfdb895c35b1', N'EnableScaling', N'Enable Scaling', N'0')
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'e2084346-77b2-4e92-8d3d-57f953064e9a', N'da61da6b-3208-42af-bd5d-b3d3e4540c2f', N'EnableScaling', N'Enable Scaling', N'0')
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'434920c4-29ff-4db5-9da3-6a18ca94f02c', N'da61da6b-3208-42af-bd5d-b3d3e4540c2f', N'Precision', N'Precision', N'2')
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'b79b7902-d96f-426a-9854-6b3693c6596e', N'026d5c4e-a175-49cd-a56d-cfdb895c35b1', N'Precision', N'Precision', N'2')
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'3764d315-9878-4082-9530-6fd1cbd9eb1a', N'da61da6b-3208-42af-bd5d-b3d3e4540c2f', N'RawMax', N'Raw Max', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'4ede1342-c5b1-4f6e-8915-73024968c9f0', N'59b7a6de-d12d-48f1-80cf-75d7465ac628', N'EnableScaling', N'Enable Scaling', N'0')
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'ac8ada39-88a3-4165-b220-920978248bcc', N'026d5c4e-a175-49cd-a56d-cfdb895c35b1', N'MaxValue', N'Max Value', N'200')
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'4e12832d-74b4-4ec8-9524-a0396ac73d26', N'7ffccd82-35e2-49b9-82a0-1e68de122e90', N'MaxValue', N'Max Value', N'5000')
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'9b7a5703-95d8-4c70-93bf-a19293f3d3ee', N'026d5c4e-a175-49cd-a56d-cfdb895c35b1', N'EUMin', N'EU Min', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'229c544c-0d3d-468b-9839-a58d6ef2a4f3', N'7ffccd82-35e2-49b9-82a0-1e68de122e90', N'WriteSecurityLevel', N'Write Security Level', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'c3855577-0bfe-47a1-a295-b58ceeccb3d7', N'7ffccd82-35e2-49b9-82a0-1e68de122e90', N'MinValue', N'Min Value', N'-50')
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'bab37e59-abd2-446f-8636-ca17e4838423', N'59b7a6de-d12d-48f1-80cf-75d7465ac628', N'RawMin', N'Raw Min', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'7944025a-51fc-4c25-9fe5-d18c78eb88ed', N'59b7a6de-d12d-48f1-80cf-75d7465ac628', N'EUMax', N'EU Max', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'c41407fd-58c3-4500-82ed-d6b53f010b58', N'026d5c4e-a175-49cd-a56d-cfdb895c35b1', N'EUMax', N'EU Max', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'643b68c9-2d59-4dd6-ad3e-d80fc3b36ce7', N'026d5c4e-a175-49cd-a56d-cfdb895c35b1', N'MinValue', N'Min Value', N'-30')
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'76e48a33-6c32-4edd-8f7a-db6a32a5433b', N'7ffccd82-35e2-49b9-82a0-1e68de122e90', N'Precision', N'Precision', N'4')
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'a21f03a6-c3cc-4b28-9a23-e37a690158de', N'7ffccd82-35e2-49b9-82a0-1e68de122e90', N'EUMax', N'EU Max', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'c141a1e8-d887-43be-9d9c-e7fea7700d58', N'59b7a6de-d12d-48f1-80cf-75d7465ac628', N'EUMin', N'EU Min', NULL)
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'b5463a69-8d13-4f34-9b01-ea96cac0ab81', N'59b7a6de-d12d-48f1-80cf-75d7465ac628', N'EnableWrite', N'Enable Write', N'0')
INSERT [dbo].[cfgTblSignalProperties] ([ID], [SignalID], [Name], [DisplayName], [Value]) VALUES (N'268e5e1d-6366-4e42-a5a2-ebf1b9461a0e', N'59b7a6de-d12d-48f1-80cf-75d7465ac628', N'WriteSecurityLevel', N'Write Security Level', NULL)
INSERT [dbo].[dataTblLogs] ([ID], [Source], [Type], [Message], [TimeStamp]) VALUES (N'2394f34b-c7ad-4dd8-89da-1bb4aba096f1', N'WebTest4', N'api4', N'this is a fourth test asdf', CAST(N'2016-10-24T17:15:30.000' AS DateTime))
INSERT [dbo].[dataTblLogs] ([ID], [Source], [Type], [Message], [TimeStamp]) VALUES (N'113009de-12df-47ed-be9a-3a047c677394', N'WebTest', N'api3', N'this is a third test', CAST(N'2017-05-12T00:00:00.000' AS DateTime))
INSERT [dbo].[dataTblLogs] ([ID], [Source], [Type], [Message], [TimeStamp]) VALUES (N'1dcca566-217f-4775-bf07-640e24b8434f', N'test', N'testType', N'test Message', CAST(N'2017-05-11T00:00:00.000' AS DateTime))
INSERT [dbo].[dataTblLogs] ([ID], [Source], [Type], [Message], [TimeStamp]) VALUES (N'4a6f7d49-498d-4395-8432-b09c8c7b39f0', N'WebTest4', N'api', N'blah blah blah', CAST(N'2017-05-12T16:48:08.107' AS DateTime))
INSERT [dbo].[dataTblLogs] ([ID], [Source], [Type], [Message], [TimeStamp]) VALUES (N'3358ad48-ca63-4ab7-a271-c609ef7bae46', N'WebTest', N'api', N'this is a second test', CAST(N'2017-05-10T00:00:00.000' AS DateTime))
INSERT [dbo].[dataTblLogs] ([ID], [Source], [Type], [Message], [TimeStamp]) VALUES (N'6ca84879-c354-41d8-b1b4-cc7b048d7161', N'WebTest', N'api', N'this is s test', CAST(N'2017-05-09T00:00:00.000' AS DateTime))
INSERT [dbo].[dataTblLogs] ([ID], [Source], [Type], [Message], [TimeStamp]) VALUES (N'4e3bc769-e7c4-40fc-bfed-cca0a1ec5601', N'WebTest', N'api3', N'this is a third test', CAST(N'2017-05-08T00:00:00.000' AS DateTime))
INSERT [dbo].[dataTblLogs] ([ID], [Source], [Type], [Message], [TimeStamp]) VALUES (N'39c18396-f45c-494e-8323-dedac43dd3df', N'WebTest4', N'api4', N'this is a fourth test', CAST(N'2017-05-12T00:00:00.000' AS DateTime))
INSERT [dbo].[dataTblLogs] ([ID], [Source], [Type], [Message], [TimeStamp]) VALUES (N'ab2a6247-1dd2-4a3f-a693-ecca9c5e2fa8', N'WebTest4', N'api4', N'this is a fourth test asdf', CAST(N'2017-05-12T15:19:38.367' AS DateTime))
INSERT [dbo].[dataTblObjects] ([ID], [DisplayName], [ObjectType]) VALUES (N'bde8daa7-4c79-44ac-85b1-49e09c0677ec', N'Test RTU', N'21979b00-4285-4da7-af5b-b4559074b62d')
INSERT [dbo].[dataTblObjects] ([ID], [DisplayName], [ObjectType]) VALUES (N'd1db5322-dbbb-47ab-aea1-a597f621a64e', N'Test Meter', N'f3000cda-79b1-4ad6-896a-7446095e1c06')
INSERT [dbo].[dataTblSignalHistory] ([ID], [SignalID], [TagName], [TimeStamp], [Value]) VALUES (N'2397386d-1284-46a9-acbd-1e61e0f31dad', N'7ffccd82-35e2-49b9-82a0-1e68de122e90', N'1', CAST(N'2017-05-15T13:55:02.987' AS DateTime), N'1')
INSERT [dbo].[dataTblSignalHistory] ([ID], [SignalID], [TagName], [TimeStamp], [Value]) VALUES (N'f994f0dd-3605-49ec-ac23-632526f0ff5f', N'026d5c4e-a175-49cd-a56d-cfdb895c35b1', N'4', CAST(N'2017-05-15T13:55:06.203' AS DateTime), N'4')
INSERT [dbo].[dataTblSignalHistory] ([ID], [SignalID], [TagName], [TimeStamp], [Value]) VALUES (N'42a17051-a378-4ff4-9d70-6b5fc683deb0', N'7f03725e-42ab-4991-a7f0-d2b81f624b57', N'sfhdsfdh', CAST(N'2017-05-15T13:57:24.027' AS DateTime), N'sfhdsfdh')
INSERT [dbo].[dataTblSignalHistory] ([ID], [SignalID], [TagName], [TimeStamp], [Value]) VALUES (N'6f0faf5c-9e91-42bd-9d03-6e6f2f952716', N'59b7a6de-d12d-48f1-80cf-75d7465ac628', N'2', CAST(N'2017-05-15T13:55:03.897' AS DateTime), N'2')
INSERT [dbo].[dataTblSignalHistory] ([ID], [SignalID], [TagName], [TimeStamp], [Value]) VALUES (N'662bc54b-1dfb-48dd-8a26-dea45ff10f67', N'da61da6b-3208-42af-bd5d-b3d3e4540c2f', N'3', CAST(N'2017-05-15T13:55:04.670' AS DateTime), N'3')
INSERT [dbo].[dataTblSignals] ([ID], [TagName], [DisplayName], [TimeStamp], [RawValue], [Source], [Enabled], [ItemDataType]) VALUES (N'7ffccd82-35e2-49b9-82a0-1e68de122e90', N'StaticPressure', N'SP', CAST(N'2017-05-09T19:26:39.613' AS DateTime), N'1', N'3b3fba02-4016-46e1-a012-f053e7ef6d3c', 1, N'd3d12dd1-681d-4354-820a-bcbbfd30d0af')
INSERT [dbo].[dataTblSignals] ([ID], [TagName], [DisplayName], [TimeStamp], [RawValue], [Source], [Enabled], [ItemDataType]) VALUES (N'59b7a6de-d12d-48f1-80cf-75d7465ac628', N'FlowRate', N'Flow Rate', CAST(N'2017-05-09T19:26:39.567' AS DateTime), N'2', N'3b3fba02-4016-46e1-a012-f053e7ef6d3c', 1, N'd3d12dd1-681d-4354-820a-bcbbfd30d0af')
INSERT [dbo].[dataTblSignals] ([ID], [TagName], [DisplayName], [TimeStamp], [RawValue], [Source], [Enabled], [ItemDataType]) VALUES (N'da61da6b-3208-42af-bd5d-b3d3e4540c2f', N'DiffPressure', N'DP', CAST(N'2017-05-09T19:26:39.473' AS DateTime), N'3', N'3b3fba02-4016-46e1-a012-f053e7ef6d3c', 1, N'd3d12dd1-681d-4354-820a-bcbbfd30d0af')
INSERT [dbo].[dataTblSignals] ([ID], [TagName], [DisplayName], [TimeStamp], [RawValue], [Source], [Enabled], [ItemDataType]) VALUES (N'026d5c4e-a175-49cd-a56d-cfdb895c35b1', N'FlowingTemperature', N'Temp', CAST(N'2017-05-09T19:26:39.520' AS DateTime), N'4', N'3b3fba02-4016-46e1-a012-f053e7ef6d3c', 1, N'd3d12dd1-681d-4354-820a-bcbbfd30d0af')
INSERT [dbo].[dataTblSignals] ([ID], [TagName], [DisplayName], [TimeStamp], [RawValue], [Source], [Enabled], [ItemDataType]) VALUES (N'7f03725e-42ab-4991-a7f0-d2b81f624b57', N'TestTag', N'Test Tag', CAST(N'2017-05-15T13:56:57.407' AS DateTime), N'sfhdsfdh', N'3b3fba02-4016-46e1-a012-f053e7ef6d3c', 1, N'7fa2295c-f399-4350-8401-31225832c007')
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_cfgTblIdentifiersTypeDisplayValue]    Script Date: 5/15/2017 2:06:55 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_cfgTblIdentifiersTypeDisplayValue] ON [dbo].[cfgTblIdentifiers]
(
	[ID_Type] ASC,
	[Value] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_cfgTblObjectProperties]    Script Date: 5/15/2017 2:06:55 PM ******/
CREATE NONCLUSTERED INDEX [IX_cfgTblObjectProperties] ON [dbo].[cfgTblObjectProperties]
(
	[ObjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_cfgTblObjectProperties_1]    Script Date: 5/15/2017 2:06:55 PM ******/
CREATE NONCLUSTERED INDEX [IX_cfgTblObjectProperties_1] ON [dbo].[cfgTblObjectProperties]
(
	[Property] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_cfgTblSignalProperties]    Script Date: 5/15/2017 2:06:55 PM ******/
CREATE NONCLUSTERED INDEX [IX_cfgTblSignalProperties] ON [dbo].[cfgTblSignalProperties]
(
	[SignalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_cfgTblSignalProperties_1]    Script Date: 5/15/2017 2:06:55 PM ******/
CREATE NONCLUSTERED INDEX [IX_cfgTblSignalProperties_1] ON [dbo].[cfgTblSignalProperties]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_dataTblLogsSource]    Script Date: 5/15/2017 2:06:55 PM ******/
CREATE NONCLUSTERED INDEX [IX_dataTblLogsSource] ON [dbo].[dataTblLogs]
(
	[Source] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_dataTblLogsTimeStamp]    Script Date: 5/15/2017 2:06:55 PM ******/
CREATE NONCLUSTERED INDEX [IX_dataTblLogsTimeStamp] ON [dbo].[dataTblLogs]
(
	[TimeStamp] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_dataTblLogsType]    Script Date: 5/15/2017 2:06:55 PM ******/
CREATE NONCLUSTERED INDEX [IX_dataTblLogsType] ON [dbo].[dataTblLogs]
(
	[Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_dataTblObjects]    Script Date: 5/15/2017 2:06:55 PM ******/
CREATE NONCLUSTERED INDEX [IX_dataTblObjects] ON [dbo].[dataTblObjects]
(
	[ObjectType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_dataTblSignalHistory]    Script Date: 5/15/2017 2:06:55 PM ******/
CREATE NONCLUSTERED INDEX [IX_dataTblSignalHistory] ON [dbo].[dataTblSignalHistory]
(
	[SignalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_dataTblSignalHistory_1]    Script Date: 5/15/2017 2:06:55 PM ******/
CREATE NONCLUSTERED INDEX [IX_dataTblSignalHistory_1] ON [dbo].[dataTblSignalHistory]
(
	[TagName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_dataTblSignalHistory_2]    Script Date: 5/15/2017 2:06:55 PM ******/
CREATE NONCLUSTERED INDEX [IX_dataTblSignalHistory_2] ON [dbo].[dataTblSignalHistory]
(
	[TimeStamp] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_dataTblSignals]    Script Date: 5/15/2017 2:06:55 PM ******/
CREATE NONCLUSTERED INDEX [IX_dataTblSignals] ON [dbo].[dataTblSignals]
(
	[Enabled] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_dataTblSignals_1]    Script Date: 5/15/2017 2:06:55 PM ******/
CREATE NONCLUSTERED INDEX [IX_dataTblSignals_1] ON [dbo].[dataTblSignals]
(
	[Source] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_dataTblSignals_2]    Script Date: 5/15/2017 2:06:55 PM ******/
CREATE NONCLUSTERED INDEX [IX_dataTblSignals_2] ON [dbo].[dataTblSignals]
(
	[TagName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_dataTblSignals_3]    Script Date: 5/15/2017 2:06:55 PM ******/
CREATE NONCLUSTERED INDEX [IX_dataTblSignals_3] ON [dbo].[dataTblSignals]
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cfgTblIdentifiers] ADD  CONSTRAINT [DF_cfgTblIdentifiers_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[cfgTblObjectProperties] ADD  CONSTRAINT [DF_cfgTblObjectProperties_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[cfgTblObjectProperties] ADD  CONSTRAINT [DF_cfgTblObjectProperties_DisplayOrder]  DEFAULT ((100)) FOR [DisplayOrder]
GO
ALTER TABLE [dbo].[cfgTblObjectProperties] ADD  CONSTRAINT [DF_cfgTblObjectProperties_WriteSecurityLevel]  DEFAULT ((0)) FOR [WriteSecurityLevel]
GO
ALTER TABLE [dbo].[cfgTblSignalProperties] ADD  CONSTRAINT [DF_cfgTblSignalPropertiesACM_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[dataTblLogs] ADD  CONSTRAINT [DF_dataTblLogs_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[dataTblLogs] ADD  CONSTRAINT [DF_dataTblLogs_TimeStamp]  DEFAULT (getdate()) FOR [TimeStamp]
GO
ALTER TABLE [dbo].[dataTblObjects] ADD  CONSTRAINT [DF_dataTblObjects_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[dataTblSignalHistory] ADD  CONSTRAINT [DF_dataTblSignalHistory_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[dataTblSignalHistory] ADD  CONSTRAINT [DF_dataTblSignalHistory_TimeStamp]  DEFAULT (getdate()) FOR [TimeStamp]
GO
ALTER TABLE [dbo].[dataTblSignals] ADD  CONSTRAINT [DF_dataTblSignals_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[dataTblSignals] ADD  CONSTRAINT [DF_dataTblSignals_TimeStamp]  DEFAULT (getdate()) FOR [TimeStamp]
GO
ALTER TABLE [dbo].[dataTblSignals] ADD  CONSTRAINT [DF_dataTblSignals_Enabled]  DEFAULT ((1)) FOR [Enabled]
GO
ALTER TABLE [dbo].[plgTblAcmToSignalChannels] ADD  CONSTRAINT [DF_ConfigOpcToDbChannels_IO_Server]  DEFAULT ('IO1') FOR [IO_Server]
GO
ALTER TABLE [dbo].[plgTblAcmToSignalChannels] ADD  CONSTRAINT [DF_ConfigOpcToDbChannels_LastUpdate]  DEFAULT ('2000-01-01 00:00:00.000') FOR [LastUpdate]
GO
ALTER TABLE [dbo].[plgTblAcmToSignalChannels] ADD  CONSTRAINT [DF_ConfigOpcToDbChannels_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[plgTblAcmToSignalChannels] ADD  CONSTRAINT [DF_ConfigOpcToDbChannels_Message]  DEFAULT ('') FOR [Message]
GO
ALTER TABLE [dbo].[plgTblAcmToSignalChannels] ADD  CONSTRAINT [DF_ConfigOpcToDbChannels_Enable]  DEFAULT ((1)) FOR [Enable]
GO
ALTER TABLE [dbo].[plgTblAcmToSignalChannels] ADD  CONSTRAINT [DF_ConfigOpcToDbChannels_Debug]  DEFAULT ((0)) FOR [Debug]
GO
ALTER TABLE [dbo].[plgTblAcmToSignalChannels] ADD  CONSTRAINT [DF_cfgAcmToSignalChannels_Reload]  DEFAULT ((0)) FOR [Reload]
GO
ALTER TABLE [dbo].[plgTblAcmToSignalChannels] ADD  CONSTRAINT [DF_ConfigOpcToDbChannels_ErrorTimeoutMinutes]  DEFAULT ((15)) FOR [ErrorTimeoutMinutes]
GO
ALTER TABLE [dbo].[plgTblAcmToSignalChannels] ADD  CONSTRAINT [DF_ConfigOpcToDbChannels_LoadTimeMinutes]  DEFAULT ((1)) FOR [LoadTimeMinutes]
GO
ALTER TABLE [dbo].[plgTblAcmToSignalChannels] ADD  CONSTRAINT [DF_ConfigOpcToDbChannels_LoadComplete]  DEFAULT ((0)) FOR [LoadComplete]
GO
ALTER TABLE [dbo].[plgTblAcmToSignalChannels] ADD  CONSTRAINT [DF_ConfigOpcToDbChannels_RestartOnProcessError]  DEFAULT ((1)) FOR [RestartOnProcessError]
GO
ALTER TABLE [dbo].[cfgTblObjectProperties]  WITH CHECK ADD  CONSTRAINT [FK_cfgTblObjectProperties_cfgTblIdentifiers] FOREIGN KEY([ControlType])
REFERENCES [dbo].[cfgTblIdentifiers] ([ID])
GO
ALTER TABLE [dbo].[cfgTblObjectProperties] CHECK CONSTRAINT [FK_cfgTblObjectProperties_cfgTblIdentifiers]
GO
ALTER TABLE [dbo].[cfgTblObjectProperties]  WITH CHECK ADD  CONSTRAINT [FK_cfgTblObjectProperties_cfgTblObjectProperties1] FOREIGN KEY([DataType])
REFERENCES [dbo].[cfgTblIdentifiers] ([ID])
GO
ALTER TABLE [dbo].[cfgTblObjectProperties] CHECK CONSTRAINT [FK_cfgTblObjectProperties_cfgTblObjectProperties1]
GO
ALTER TABLE [dbo].[cfgTblObjectProperties]  WITH CHECK ADD  CONSTRAINT [FK_cfgTblObjectProperties_dataTblObjects] FOREIGN KEY([ObjectID])
REFERENCES [dbo].[dataTblObjects] ([ID])
GO
ALTER TABLE [dbo].[cfgTblObjectProperties] CHECK CONSTRAINT [FK_cfgTblObjectProperties_dataTblObjects]
GO
ALTER TABLE [dbo].[cfgTblSignalProperties]  WITH CHECK ADD  CONSTRAINT [FK_cfgTblSignalProperties_dataTblSignals] FOREIGN KEY([SignalID])
REFERENCES [dbo].[dataTblSignals] ([ID])
GO
ALTER TABLE [dbo].[cfgTblSignalProperties] CHECK CONSTRAINT [FK_cfgTblSignalProperties_dataTblSignals]
GO
ALTER TABLE [dbo].[dataTblObjects]  WITH CHECK ADD  CONSTRAINT [FK_dataTblObjectsType_cfgTblObjectProperties] FOREIGN KEY([ObjectType])
REFERENCES [dbo].[cfgTblIdentifiers] ([ID])
GO
ALTER TABLE [dbo].[dataTblObjects] CHECK CONSTRAINT [FK_dataTblObjectsType_cfgTblObjectProperties]
GO
ALTER TABLE [dbo].[dataTblSignals]  WITH CHECK ADD  CONSTRAINT [FK_dataTblSignals_cfgTblIdentifiers] FOREIGN KEY([ItemDataType])
REFERENCES [dbo].[cfgTblIdentifiers] ([ID])
GO
ALTER TABLE [dbo].[dataTblSignals] CHECK CONSTRAINT [FK_dataTblSignals_cfgTblIdentifiers]
GO
ALTER TABLE [dbo].[dataTblSignals]  WITH CHECK ADD  CONSTRAINT [FK_dataTblSignalsSource_cfgTblIdentifiers1] FOREIGN KEY([Source])
REFERENCES [dbo].[cfgTblIdentifiers] ([ID])
GO
ALTER TABLE [dbo].[dataTblSignals] CHECK CONSTRAINT [FK_dataTblSignalsSource_cfgTblIdentifiers1]
GO
/****** Object:  StoredProcedure [dbo].[rGetObjectProperties]    Script Date: 5/15/2017 2:06:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		David Cox
-- Create date: 5/13/2017
-- Description:	Gets the properties associated with an object
-- =============================================
CREATE PROCEDURE [dbo].[rGetObjectProperties]
	-- Add the parameters for the stored procedure here
	@ObjectID uniqueidentifier
	,@ObjectPropertyID uniqueidentifier = null
AS
BEGIN	
	IF @ObjectPropertyID IS NOT NULL
	BEGIN
		SELECT cfgTblObjectProperties.ID AS ObjectID
				,Property AS PropertyName
				,DisplayValue
				,DisplayOrder
				,DefaultValue
				,DataType AS DataTypeID
				,DataTypeText
				,DataTypeValue
				,WriteSecurityLevel
				,ControlType AS ControlTypeID
				,ControlTypeText
				,ControlTypeValue
		FROM cfgTblObjectProperties
		LEFT JOIN
			(SELECT tblDataType.ID
					,ControlTypeText
					,ControlTypeValue
					,DataTypeText
					,DataTypeValue
			FROM
				-- Control Type
				(SELECT cfgTblObjectProperties.ID
					,cfgTblIdentifiers.Value AS ControlTypeValue
					,cfgTblIdentifiers.Text AS ControlTypeText
				FROM cfgTblObjectProperties 
				LEFT JOIN
				cfgTblIdentifiers
				ON cfgTblIdentifiers.ID = ControlType) as tblControlType
			LEFT JOIN
				(-- Data Type
				SELECT cfgTblObjectProperties.ID
					,cfgTblIdentifiers.Value AS DataTypeValue
					,cfgTblIdentifiers.Text AS DataTypeText
				FROM cfgTblObjectProperties 
				LEFT JOIN
				cfgTblIdentifiers
				ON cfgTblIdentifiers.ID = DataType) AS tblDataType
			ON  tblControlType.ID = tblDataType.ID) AS tblTypes
		ON tblTypes.ID = cfgTblObjectProperties.ID
		WHERE ObjectID = @ObjectID AND cfgTblObjectProperties.ID = @ObjectPropertyID
	END
	ELSE
	BEGIN
		SELECT cfgTblObjectProperties.ID AS ObjectID
				,Property AS PropertyName
				,DisplayValue
				,DisplayOrder
				,DefaultValue
				,DataType AS DataTypeID
				,DataTypeText
				,DataTypeValue
				,WriteSecurityLevel
				,ControlType AS ControlTypeID
				,ControlTypeText
				,ControlTypeValue
		FROM cfgTblObjectProperties
		LEFT JOIN
			(SELECT tblDataType.ID
					,ControlTypeText
					,ControlTypeValue
					,DataTypeText
					,DataTypeValue
			FROM
				-- Control Type
				(SELECT cfgTblObjectProperties.ID
					,cfgTblIdentifiers.Value AS ControlTypeValue
					,cfgTblIdentifiers.Text AS ControlTypeText
				FROM cfgTblObjectProperties 
				LEFT JOIN
				cfgTblIdentifiers
				ON cfgTblIdentifiers.ID = ControlType) as tblControlType
			LEFT JOIN
				(-- Data Type
				SELECT cfgTblObjectProperties.ID
					,cfgTblIdentifiers.Value AS DataTypeValue
					,cfgTblIdentifiers.Text AS DataTypeText
				FROM cfgTblObjectProperties 
				LEFT JOIN
				cfgTblIdentifiers
				ON cfgTblIdentifiers.ID = DataType) AS tblDataType
			ON  tblControlType.ID = tblDataType.ID) AS tblTypes
		ON tblTypes.ID = cfgTblObjectProperties.ID
		WHERE ObjectID = @ObjectID
		ORDER BY DisplayOrder
	END
END
GO
/****** Object:  StoredProcedure [dbo].[rGetObjects]    Script Date: 5/15/2017 2:06:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		David Cox
-- Create date: 5/13/2017
-- Description:	Gets the available Objects
-- =============================================
CREATE PROCEDURE [dbo].[rGetObjects]
	-- Add the parameters for the stored procedure here
AS
BEGIN	
	SELECT dataTblObjects.ID AS ObjectID
		,DisplayName
		,ObjectType AS ObjectTypeID
		,cfgTblIdentifiers.Value AS ObjectTypeValue
		,cfgTblIdentifiers.Text AS ObjectTypeText
	FROM dataTblObjects
	LEFT JOIN cfgTblIdentifiers
	ON dataTblObjects.ObjectType = cfgTblIdentifiers.ID
END
GO
/****** Object:  StoredProcedure [dbo].[rGetSignalProperties]    Script Date: 5/15/2017 2:06:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		David Cox
-- Create date: 5/13/2017
-- Description:	Gets the properties associated with an object
-- =============================================
CREATE PROCEDURE [dbo].[rGetSignalProperties]
	-- Add the parameters for the stored procedure here
	@SignalID uniqueidentifier
AS
BEGIN
	SELECT ID AS SignalPropertyID
		,Name AS PropertyName
		,DisplayName
		,Value AS PropertyValue
	FROM cfgTblSignalProperties
	WHERE SignalID = @SignalID
END
GO
/****** Object:  StoredProcedure [dbo].[rGetSignalProperty]    Script Date: 5/15/2017 2:06:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		David Cox
-- Create date: 5/13/2017
-- Description:	Gets the properties associated with an object
-- =============================================
CREATE PROCEDURE [dbo].[rGetSignalProperty]
	-- Add the parameters for the stored procedure here
	@SignalPropertyID uniqueidentifier
AS
BEGIN
	SELECT ID AS SignalPropertyID
		,Name AS PropertyName
		,DisplayName AS DisplayName
		,Value AS PropertyValue
	FROM cfgTblSignalProperties
	WHERE ID = @SignalPropertyID
END
GO
/****** Object:  StoredProcedure [dbo].[rGetSignals]    Script Date: 5/15/2017 2:06:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		David Cox
-- Create date: 5/13/2017
-- Description:	Gets the available Objects
-- =============================================
CREATE PROCEDURE [dbo].[rGetSignals]
	-- Add the parameters for the stored procedure here
	@SignalID uniqueidentifier = NULL
AS
BEGIN
	IF @SignalID IS NULL
	BEGIN
		SELECT tblObjects.ID AS SignalID
				,DataTypeID 
				,DataTypeText 
				,DataTypeValue 
				,SourceID 
				,SourceText 
				,SourceValue
				,TagName
				,DisplayName
				,TimeStamp
				,RawValue
				,Enabled
		FROM
		(
			SELECT dataTblSignals.ID
				,TagName
				,dataTblSignals.DisplayName
				,TimeStamp
				,RawValue
				,Enabled
			FROM dataTblSignals
		) AS tblObjects
		LEFT JOIN 
		(
			SELECT tblSource.ID
				,tblDataType.DataTypeID 
				,tblDataType.DataTypeText 
				,tblDataType.DataTypeValue 
				,tblSource.SourceID 
				,tblSource.SourceText 
				,tblSource.SourceValue 
			FROM
			(
				SELECT dataTblSignals.ID
					,Source AS SourceID
					,cfgTblIdentifiers.Value AS SourceValue
					,cfgTblIdentifiers.Text AS SourceText
				FROM dataTblSignals
				LEFT JOIN cfgTblIdentifiers
				ON dataTblSignals.Source = cfgTblIdentifiers.ID
			) AS tblSource
			LEFT JOIN
			(
				SELECT dataTblSignals.ID
					,ItemDataType AS DataTypeID
					,cfgTblIdentifiers.Value AS DataTypeValue
					,cfgTblIdentifiers.Text AS DataTypeText
				FROM dataTblSignals
				LEFT JOIN cfgTblIdentifiers
				ON dataTblSignals.ItemDataType = cfgTblIdentifiers.ID
			) AS tblDataType
			ON tblDataType.ID = tblSource.ID
		) as tblProperties
		on tblProperties.ID = tblObjects.ID
	END
	ELSE
	BEGIN
		SELECT tblObjects.ID AS SignalID
				,DataTypeID 
				,DataTypeText 
				,DataTypeValue 
				,SourceID 
				,SourceText 
				,SourceValue
				,TagName
				,DisplayName
				,TimeStamp
				,RawValue
				,Enabled
		FROM
		(
			SELECT dataTblSignals.ID
				,TagName
				,dataTblSignals.DisplayName
				,TimeStamp
				,RawValue
				,Enabled
			FROM dataTblSignals
			WHERE dataTblSignals.ID = @SignalID
		) AS tblObjects
		LEFT JOIN 
		(
			SELECT tblSource.ID
				,tblDataType.DataTypeID 
				,tblDataType.DataTypeText 
				,tblDataType.DataTypeValue 
				,tblSource.SourceID 
				,tblSource.SourceText 
				,tblSource.SourceValue 
			FROM
			(
				SELECT dataTblSignals.ID
					,Source AS SourceID
					,cfgTblIdentifiers.Value AS SourceValue
					,cfgTblIdentifiers.Text AS SourceText
				FROM dataTblSignals
				LEFT JOIN cfgTblIdentifiers
				ON dataTblSignals.Source = cfgTblIdentifiers.ID
			) AS tblSource
			LEFT JOIN
			(
				SELECT dataTblSignals.ID
					,ItemDataType AS DataTypeID
					,cfgTblIdentifiers.Value AS DataTypeValue
					,cfgTblIdentifiers.Text AS DataTypeText
				FROM dataTblSignals
				LEFT JOIN cfgTblIdentifiers
				ON dataTblSignals.ItemDataType = cfgTblIdentifiers.ID
			) AS tblDataType
			ON tblDataType.ID = tblSource.ID
		) as tblProperties
		on tblProperties.ID = tblObjects.ID
	END
END
GO
/****** Object:  Trigger [dbo].[tr_SCHEDULE_Modified]    Script Date: 5/15/2017 2:06:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE TRIGGER trgAfterInsert ON [dbo].dataTblSignals
--FOR INSERT
--AS
--	declare @empid int;
--	declare @empname varchar(100);
--	declare @empsal decimal(10,2);
--	declare @audit_action varchar(100);

--	select @empid=i.Emp_ID from inserted i;	
--	select @empname=i.Emp_Name from inserted i;	
--	select @empsal=i.Emp_Sal from inserted i;	
--	set @audit_action='Inserted Record -- After Insert Trigger.';

--	insert into Employee_Test_Audit
--           (Emp_ID,Emp_Name,Emp_Sal,Audit_Action,Audit_Timestamp) 
--	values(@empid,@empname,@empsal,@audit_action,getdate());

--	PRINT 'AFTER INSERT trigger fired.'
--GO

CREATE TRIGGER [dbo].[tr_SCHEDULE_Modified]
   ON [dbo].[dataTblSignals]
   AFTER UPDATE
AS BEGIN
	declare @ID uniqueidentifier
	declare @Value nvarchar(50)
	declare @TagName nvarchar(50)
    SET NOCOUNT ON;
    IF UPDATE (RawValue) 
    BEGIN
        select @ID = i.ID from inserted i
        select @TagName = i.RawValue from inserted i
        select @Value = i.RawValue from inserted i
		INSERT INTO dataTblSignalHistory(
			SignalID
			,TagName
			,Value
		) VALUES (
			@ID
			,@TagName
			,@Value
		)
    END 
END
GO
ALTER TABLE [dbo].[dataTblSignals] ENABLE TRIGGER [tr_SCHEDULE_Modified]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Signal ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cfgTblSignalProperties', @level2type=N'CONSTRAINT',@level2name=N'FK_cfgTblSignalProperties_dataTblSignals'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Config Property ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dataTblObjects', @level2type=N'CONSTRAINT',@level2name=N'FK_dataTblObjectsType_cfgTblObjectProperties'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Uniques Identifier to reference the signal. This gets pushed to the history along with the value' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dataTblSignals', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tagname to reference' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dataTblSignals', @level2type=N'COLUMN',@level2name=N'TagName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Original Value' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dataTblSignals', @level2type=N'COLUMN',@level2name=N'RawValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Can be various things such as a Database, File, ACM, etc.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dataTblSignals', @level2type=N'COLUMN',@level2name=N'Source'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Item Data Type' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dataTblSignals', @level2type=N'CONSTRAINT',@level2name=N'FK_dataTblSignals_cfgTblIdentifiers'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Source' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dataTblSignals', @level2type=N'CONSTRAINT',@level2name=N'FK_dataTblSignalsSource_cfgTblIdentifiers1'
GO
