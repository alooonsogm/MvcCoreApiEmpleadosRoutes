using NugetApiModels.Models;
using System.Net.Http.Headers;

namespace MvcCoreApiEmpleadosRoutes.Services
{
    public class ServiceEmpleados
    {
        private string ApiUrl;
        private MediaTypeWithQualityHeaderValue header;

        public ServiceEmpleados(IConfiguration configuration)
        {
            this.ApiUrl = configuration.GetValue<string>("ApiUrls:ApiEmpleados");
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        //Lo que necesitamos en el metodo generico es simplemente el request de la peticion.
        private async Task<T> CallApiAsync <T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode == true)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Empleado>> GetEmpleadoAsync()
        {
            string request = "api/empleado";
            return await this.CallApiAsync<List<Empleado>>(request);
        }

        public async Task<Empleado> FindEmpleadoAsync(int id)
        {
            string request = "api/empleado/" + id;
            return await this.CallApiAsync<Empleado>(request);
        }

        public async Task<List<string>> GetOficioAsync()
        {
            string request = "api/empleado/oficios";
            return await this.CallApiAsync<List<string>>(request);
        }

        public async Task<List<Empleado>> GetEmpleadoOficioAsync(string oficio)
        {
            string request = "api/Empleado/EmpleadosByOficio/" + oficio;
            return await this.CallApiAsync<List<Empleado>>(request);
        }
    }
}
