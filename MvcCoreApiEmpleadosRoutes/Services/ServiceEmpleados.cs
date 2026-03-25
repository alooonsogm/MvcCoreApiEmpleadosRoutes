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

        public async Task<List<Empleado>> GetEmpleadoAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/empleado";
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode == true)
                {
                    return await response.Content.ReadAsAsync<List<Empleado>>();
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Empleado> FindEmpleadoAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/empleado/" + id;
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode == true)
                {
                    return await response.Content.ReadAsAsync<Empleado>();
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<string>> GetOficioAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/empleado/oficios";
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode == true)
                {
                    return await response.Content.ReadAsAsync<List<string>>();
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<Empleado>> GetEmpleadoOficioAsync(string oficio)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/Empleado/EmpleadosByOficio/" + oficio;
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode == true)
                {
                    return await response.Content.ReadAsAsync<List<Empleado>>();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
