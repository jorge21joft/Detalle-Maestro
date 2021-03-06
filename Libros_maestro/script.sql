USE [Libros]
GO
/****** Object:  Table [dbo].[DetallePrestamo]    Script Date: 29/11/2018 15:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallePrestamo](
	[id_detalle] [int] IDENTITY(1,1) NOT NULL,
	[cantidad] [int] NULL,
	[prestamo_id] [int] NULL,
	[libro_id] [int] NULL,
 CONSTRAINT [PK_DetallePrestamo] PRIMARY KEY CLUSTERED 
(
	[id_detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libros]    Script Date: 29/11/2018 15:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libros](
	[id_libro] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](100) NULL,
	[genero] [nchar](10) NULL,
 CONSTRAINT [PK_Libros] PRIMARY KEY CLUSTERED 
(
	[id_libro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prestamo]    Script Date: 29/11/2018 15:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prestamo](
	[id_prestamo] [int] IDENTITY(1,1) NOT NULL,
	[fecha_prestamo] [date] NULL,
	[fecha_devolucion] [date] NULL,
 CONSTRAINT [PK_Prestamo] PRIMARY KEY CLUSTERED 
(
	[id_prestamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DetallePrestamo] ON 

INSERT [dbo].[DetallePrestamo] ([id_detalle], [cantidad], [prestamo_id], [libro_id]) VALUES (1, 4, 2, 1)
INSERT [dbo].[DetallePrestamo] ([id_detalle], [cantidad], [prestamo_id], [libro_id]) VALUES (2, 4, 3, 1)
INSERT [dbo].[DetallePrestamo] ([id_detalle], [cantidad], [prestamo_id], [libro_id]) VALUES (3, 2, 3, 2)
INSERT [dbo].[DetallePrestamo] ([id_detalle], [cantidad], [prestamo_id], [libro_id]) VALUES (4, 3, 4, 1)
INSERT [dbo].[DetallePrestamo] ([id_detalle], [cantidad], [prestamo_id], [libro_id]) VALUES (5, 3, 5, 3)
INSERT [dbo].[DetallePrestamo] ([id_detalle], [cantidad], [prestamo_id], [libro_id]) VALUES (6, 2, 5, 1)
SET IDENTITY_INSERT [dbo].[DetallePrestamo] OFF
SET IDENTITY_INSERT [dbo].[Libros] ON 

INSERT [dbo].[Libros] ([id_libro], [titulo], [genero]) VALUES (1, N'don quijote', N'historia  ')
INSERT [dbo].[Libros] ([id_libro], [titulo], [genero]) VALUES (2, N'aaaaaaaa', N'ccccccccc ')
INSERT [dbo].[Libros] ([id_libro], [titulo], [genero]) VALUES (3, N'caperusita roja', N'cuento    ')
SET IDENTITY_INSERT [dbo].[Libros] OFF
SET IDENTITY_INSERT [dbo].[Prestamo] ON 

INSERT [dbo].[Prestamo] ([id_prestamo], [fecha_prestamo], [fecha_devolucion]) VALUES (2, NULL, NULL)
INSERT [dbo].[Prestamo] ([id_prestamo], [fecha_prestamo], [fecha_devolucion]) VALUES (3, CAST(N'2018-02-02' AS Date), CAST(N'2018-02-03' AS Date))
INSERT [dbo].[Prestamo] ([id_prestamo], [fecha_prestamo], [fecha_devolucion]) VALUES (4, CAST(N'2018-11-06' AS Date), CAST(N'2018-11-13' AS Date))
INSERT [dbo].[Prestamo] ([id_prestamo], [fecha_prestamo], [fecha_devolucion]) VALUES (5, CAST(N'2018-11-05' AS Date), CAST(N'2018-11-08' AS Date))
SET IDENTITY_INSERT [dbo].[Prestamo] OFF
ALTER TABLE [dbo].[DetallePrestamo]  WITH CHECK ADD  CONSTRAINT [FK_DetallePrestamo_Libros] FOREIGN KEY([libro_id])
REFERENCES [dbo].[Libros] ([id_libro])
GO
ALTER TABLE [dbo].[DetallePrestamo] CHECK CONSTRAINT [FK_DetallePrestamo_Libros]
GO
ALTER TABLE [dbo].[DetallePrestamo]  WITH CHECK ADD  CONSTRAINT [FK_DetallePrestamo_Prestamo] FOREIGN KEY([prestamo_id])
REFERENCES [dbo].[Prestamo] ([id_prestamo])
GO
ALTER TABLE [dbo].[DetallePrestamo] CHECK CONSTRAINT [FK_DetallePrestamo_Prestamo]
GO
