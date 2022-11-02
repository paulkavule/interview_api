using System;
using Interview.Api.Entities;
using Interview.Api.Repositories;

namespace Interview.Api.Services
{
    public interface IPhoneService
    {
        Task UploadNumbers(string numbers);
    }
    public class PhoneService : IPhoneService
    {
        private readonly DataDbContext context;

        public PhoneService(DataDbContext context)
        {
            this.context = context;
        }

        public async Task UploadNumbers(string numbers)
        {
            try
            {
                var pline = numbers.Replace('\r',' ').Split("\n");
                var count = 0;
                foreach(var line in pline)
                {
                    var data = line.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries);
                    if (data.Length != 2)
                        continue;

                    if (data[0].Length < 9 || !(data[0].StartsWith("78") || data[0].StartsWith("77") || data[0].StartsWith("70") || data[0].StartsWith("75")))
                        continue;

                    var phone = new PhoneNumber { PhoneNo = data[0].PadLeft(10, '0'), CanTransact = data[1] == "1" };
                    await context.PhoneNumbers.AddAsync(phone);
                    count++;
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }
    }
}

