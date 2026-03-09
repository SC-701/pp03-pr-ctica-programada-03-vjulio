using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos.Servicios;
using Microsoft.Extensions.Configuration;

namespace Reglas
{
    public class Configuracion : IConfiguracion
    {
        private IConfiguration _configuration;

        public Configuracion(IConfiguration configuracion)
        {
            _configuration = configuracion;
        }

        //public string ObtenerMetodo(string seccion, string nombre)
        //{
        //    string? UrlBase = ObtenerUrlBase(seccion);
        //    var Metodo = _configuration.GetSection(seccion).Get<APIEndPoint>
        //        ().Metodos.Where(m => m.Nombre == nombre).FirstOrDefault().Valor;
        //    return $"{UrlBase}/{Metodo}";
        //}
        public string ObtenerMetodo(string seccion, string nombre)
        {
            string? urlBase = ObtenerUrlBase(seccion);

            var endpoint = _configuration.GetSection(seccion).Get<APIEndPoint>();

            var metodo = endpoint?.Metodos?
                .FirstOrDefault(m => m.Nombre == nombre)?.Valor;

            return $"{urlBase}/{metodo}";
        }
        //private string? ObtenerUrlBase(string seccion)
        //{
        //    return _configuration.GetSection(seccion).Get<APIEndPoint>().UrlBase;
        //}

        //public string ObtenerValor(string llave)
        //{
        //    return _configuration.GetSection(llave).Value;
        //}
        private string ObtenerUrlBase(string seccion)
        {
            var endpoint = _configuration.GetSection(seccion).Get<APIEndPoint>()
                ?? throw new Exception($"No existe configuración para {seccion}");

            return endpoint.UrlBase
                ?? throw new Exception($"UrlBase no definida en {seccion}");
        }
        public string ObtenerValor(string llave)
        {
            return _configuration.GetSection(llave).Value
                ?? throw new Exception($"No existe valor para {llave}");
        }
    }
}
