CREATE PROCEDURE ObtenerModelosPorMarca
	-- Add the parameters for the stored procedure here
@Id uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT  Modelos.Id, Modelos.idMarca, Modelos.Nombre 
FROM     Modelos  
WHERE  (Modelos.idMarca =  @Id)
END