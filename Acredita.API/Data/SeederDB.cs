

using Acredita.Share.Entities;

namespace Acredita.API.Data
{
    public class SeederDB
    {
        private readonly DataContext dataContext;

        public SeederDB(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckCitiesAsync();
            await CheckUniversitiesAsync();
        }

        private async Task CheckUniversitiesAsync()
        {
            if (!dataContext.Universities.Any())
            {
                dataContext.Universities.Add(new University { Name = "Ibero", Url = "https://www.iberopuebla.mx", PhoneNumber = "2223723000",Adress = "Colonia Reserva Territorial Atlixcáyotl", Active = true });
                dataContext.Universities.Add(new University { Name = "ITESM", Url = "https://tec.mx/es",PhoneNumber= "8183582000",Adress = "Av. Eugenio Garza Sada 2501 Sur" , Active = true });
                dataContext.Universities.Add(new University { Name = "UDLAP",Url = "https://www.udlap.mx/web/", PhoneNumber = "2222292000", Adress = "Ex hacienda Sta. Catarina Mártir S/N. San Andrés Cholula", Active = true });
                dataContext.Universities.Add(new University { Name = "UNAM", Url= "https://www.unam.mx", PhoneNumber= "5556220000", Adress = "Av. Universidad 3000, Col. Universidad Nacional Autónoma de México", Active = true });
                dataContext.Universities.Add(new University { Name = "Anáhuac", Url = "https://www.anahuac.mx", PhoneNumber = "2221691069", Adress = "Calle Orión Norte s/n Col. La vista Country Club", Active = true });
                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckCitiesAsync()
        {
            if(!dataContext.Cities.Any())
            {
                var country =  dataContext.Countries.FirstOrDefault(x => x.Name == "México");
                if (country != null)
                {
                    dataContext.Cities.Add(new City { Name = "Puebla", Country = country });
                    dataContext.Cities.Add(new City { Name = "Cholula", Country = country });
                    await dataContext.SaveChangesAsync();
                }
            }   
        }

        private async Task CheckCountriesAsync()
        {
            if (!dataContext.Countries.Any())
            {
                dataContext.Countries.Add(new Country { Name = "México"});
                dataContext.Countries.Add(new Country { Name = "Canadá" });
                dataContext.Countries.Add(new Country { Name = "Jamaica" });
                dataContext.Countries.Add(new Country { Name = "Brasil" });
                dataContext.Countries.Add(new Country { Name = "Argentina" });
                await dataContext.SaveChangesAsync();
            }
        }
    }
}
