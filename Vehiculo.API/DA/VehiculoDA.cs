using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Numerics;

namespace DA
{

    public class VehiculoDA : IVehiculoDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Constructor
        public VehiculoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion

        #region Operaciones
        public async Task<Guid> Agregar(VehiculoRequest vehiculo)
        {
            string query = @"AgregarVehiculo";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                @Id = Guid.NewGuid(),
                @IdModelo = vehiculo.IdModelo,
                @Placa = vehiculo.Placa,
                @Color = vehiculo.Color,
                @Anio = vehiculo.Anio,
                @Precio = vehiculo.Precio,
                @CorreoPropietario = vehiculo.CorreoPropietario,
                @Telefono = vehiculo.Telefono
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid Id, VehiculoRequest vehiculo)
        {
            await verificarVehiculoExiste(Id);
            string query = @"EditarVehiculo";

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                @Id = Id,
                @IdModelo = vehiculo.IdModelo,
                @Placa = vehiculo.Placa,
                @Color = vehiculo.Color,
                @Anio = vehiculo.Anio,
                @Precio = vehiculo.Precio,
                @CorreoPropietario = vehiculo.CorreoPropietario,
                @Telefono = vehiculo.Telefono
            });
            return resultadoConsulta;
        }



        public async Task<Guid> Eliminar(Guid Id)
        {
            await verificarVehiculoExiste(Id);
            string query = @"EliminarVehiculo";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                @Id = Id

            });
            return resultadoConsulta; throw new NotImplementedException();
        }
        public async Task<IEnumerable<VehiculoResponse>> Obtener()
        {
            string query = @"ObtenerVehiculos";
            var resultadoConsulta = await _sqlConnection.QueryAsync<VehiculoResponse>(query);
            return resultadoConsulta;
        }
        public async Task<VehiculoDetalle?> Obtener(Guid Id)
        {
            string query = @"ObtenerVehiculo";
            var resultadoConsulta = await _sqlConnection.QueryAsync<VehiculoDetalle>(query,
                new { Id = Id });
            return resultadoConsulta.FirstOrDefault();
        }
        //public async Task<VehiculoDetalle?> Obtener(Guid Id)
        //{
        //    string query = "ObtenerVehiculo";

        //    var resultadoConsulta = await _sqlConnection.QueryAsync<VehiculoDetalle>(
        //        query,
        //        new { Id });

        //    VehiculoDetalle? vehiculo = resultadoConsulta.FirstOrDefault();

        //    return vehiculo;
        //}

        //public async Task<IEnumerable<VehiculoMarcas>> ObtenerMarcas()
        //{
        //    string query = @"ObtenerMarcas";

        //    var resultadoConsulta = await _sqlConnection.QueryAsync<VehiculoMarcas>(query);

        //    return resultadoConsulta;
        //}

        //public async Task<IEnumerable<VehiculoModelosPorMarcas>> ObtenerModelosPorMarca(Guid Id)
        //{
        //    string query = @"ObtenerModelosPorMarca";

        //    var resultadoConsulta = await _sqlConnection.QueryAsync<VehiculoModelosPorMarcas>(
        //        query,
        //        new { Id = Id }
        //    );

        //    return resultadoConsulta;
        //}
        #endregion
        #region Helpers
        private async Task verificarVehiculoExiste(Guid Id)
        {
            VehiculoResponse? resultadoConsultaVehiculo = await Obtener(Id);
            if (resultadoConsultaVehiculo == null)
                throw new Exception("No se encontró el vehiculo");
        }
        #endregion

    }
}
