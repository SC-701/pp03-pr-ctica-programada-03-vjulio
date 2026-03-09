CREATE PROCEDURE ObtenerVehiculos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT  
        Vehiculo.Id,
        Vehiculo.IdModelo,
        Vehiculo.Placa,
        Vehiculo.Color,
        Vehiculo.Anio,
        Vehiculo.Precio,
        Vehiculo.CorreoPropietario,
        Vehiculo.Telefono,
        Modelos.Nombre AS Modelo,
        Marcas.Nombre AS Marca
    FROM Marcas 
        INNER JOIN Modelos ON Marcas.Id = Modelos.IdMarca
        INNER JOIN Vehiculo ON Modelos.Id = Vehiculo.IdModelo;
END
GO
