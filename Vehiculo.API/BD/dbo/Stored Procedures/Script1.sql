CREATE PROCEDURE ObtenerVehiculos
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Vehiculo.id, Modelos.Nombre AS Modelo, Vehiculo.idModelo, Vehiculo.Placa, Vehiculo.Anio, Vehiculo.Color, Vehiculo.Precio, Vehiculo.CorreoPropietario, Vehiculo.Telefono, Marcas.Nombre AS Marca
FROM   Vehiculo INNER JOIN
             Modelos ON Vehiculo.idModelo = Modelos.id INNER JOIN
             Marcas ON Modelos.idMarca = Marcas.id
END