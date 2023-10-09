using Dominio.Interface; 
using Application.UnitOfWork; 

namespace API.Extensions
{

    public static class AplicationServicesExtensions
    {


        public static void AddAplicacionServices(this IServiceCollection services)
        {
            // Agrega un servicio al contenedor de dependencias.
            //se crea una nueva instancia de nuestro servicio con la asociacion entre la interfaz de UnitOfWork y UnitOfWork. 
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
