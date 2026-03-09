
CREATE PROCEDURE AgregarVehiculo
	-- Add the parameters for the stored procedure here
@Id as uniqueidentifier
,@IdModelo as uniqueidentifier
,@Placa as varchar(max)
,@Color as varchar(max)
,@Anio as int
,@Precio as decimal(18,0)
,@CorreoPropietario as varchar(max)
,@Telefono as varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    BEGIN TRANSACTION
INSERT INTO [dbo].[Vehiculo]
           ([Id]
           ,[IdModelo]
           ,[Placa]
           ,[Color]
           ,[Anio]
           ,[Precio]
           ,[CorreoPropietario]
           ,[Telefono])
     VALUES
           (@Id, 
           @IdModelo, 
           @Placa, 
           @Color, 
           @Anio, 
           @Precio,
           @CorreoPropietario, 
           @Telefono)
    
    Select @Id
    COMMIT TRANSACTION
END