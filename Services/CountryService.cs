using System;
using Interview.Api.Entities;
using Interview.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Interview.Api.Services
{
    public interface ICountryService
    {
        Task<Country> AddCountry(Country country);
        Task<List<Country>> GetCountries(string name);
    }
    public class CountryService : ICountryService
    {
        private readonly DataDbContext context;

        public CountryService(DataDbContext context)
        {
            this.context = context;
        }

        public async Task<Country> AddCountry(Country country)
        {
            await context.Countries.AddAsync(country);
            context.SaveChanges();

            return country;
        }

        public async Task<List<Country>> GetCountries(string name)
        {
            await Task.Delay(new TimeSpan(0, 0, 5));
            return await context.Countries.Where(cc => cc.CtyName.ToLower().Contains(name.ToLower())).ToListAsync();
        }
    }
}

