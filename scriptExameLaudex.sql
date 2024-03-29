USE [Tareas]
GO
/****** Object:  StoredProcedure [dbo].[AddTareas]    Script Date: 25/01/2024 04:30:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddTareas]
@Titulo Varchar(30), 
@Descripcion VARCHAR(500),
@FechaVencimiento DATE,
@Estado INT
AS
INSERT INTO Tareas VALUES (@Titulo, @Descripcion, @FechaVencimiento,@Estado)
GO
/****** Object:  StoredProcedure [dbo].[DeleteTarea]    Script Date: 25/01/2024 04:30:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteTarea]
@IdTarea INT
AS
DELETE FROM Tareas WHERE IdTarea = @IdTarea
GO
/****** Object:  StoredProcedure [dbo].[GetAllEstatus]    Script Date: 25/01/2024 04:30:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllEstatus] 
AS
SELECT IdEstatus, Nombre FROM Estatus
GO
/****** Object:  StoredProcedure [dbo].[GetAllTareas]    Script Date: 25/01/2024 04:30:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllTareas]
AS
SELECT IdTarea,Titulo,Descripcion,FechaVencimiento,Estado, Nombre FROM Tareas
INNER JOIN Estatus ON Estado = IdEstatus
GO
/****** Object:  StoredProcedure [dbo].[GetByIdTareas]    Script Date: 25/01/2024 04:30:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetByIdTareas]
@IdTarea INT
AS
SELECT IdTarea,Titulo,Descripcion,FechaVencimiento,Estado, Nombre FROM Tareas
INNER JOIN Estatus ON Estado = IdEstatus
WHERE IdTarea = @IdTarea
GO
/****** Object:  StoredProcedure [dbo].[UpdateTarea]    Script Date: 25/01/2024 04:30:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateTarea]
@IdTarea INT,
@Titulo Varchar(30), 
@Descripcion VARCHAR(500),
@FechaVencimiento DATE,
@Estado INT
AS
UPDATE Tareas SET Titulo = @Titulo, Descripcion = @Descripcion, FechaVencimiento = @FechaVencimiento, Estado = @Estado
WHERE IdTarea = @IdTarea
GO
/****** Object:  Table [dbo].[Estatus]    Script Date: 25/01/2024 04:30:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estatus](
	[IdEstatus] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEstatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tareas]    Script Date: 25/01/2024 04:30:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tareas](
	[IdTarea] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](100) NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[FechaVencimiento] [date] NULL,
	[Estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTarea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Tareas]  WITH CHECK ADD FOREIGN KEY([Estado])
REFERENCES [dbo].[Estatus] ([IdEstatus])
GO
