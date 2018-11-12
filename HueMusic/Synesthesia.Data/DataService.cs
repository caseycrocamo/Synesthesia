using Microsoft.EntityFrameworkCore;
using Synesthesia.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Synesthesia.Data
{
    public class DataService
    {
        private readonly SynesthiaContext synesthesiaContext;

        public DataService()
        {
            synesthesiaContext = new SynesthiaContext();
        }

        public DataService(SynesthiaContext context)
        {
            synesthesiaContext = context;
        }

        public async Task<Settings> InitializeSettings()
        {
            try
            {
                var settings = new Settings();
                await synesthesiaContext.Settings.AddAsync(settings);
                await synesthesiaContext.SaveChangesAsync();
                return settings;
            }
            catch (Exception)
            {
                throw;
            }  
        }

        public async Task<Settings> InitializeSettings(Settings settings)
        {
            try
            {
                await synesthesiaContext.Settings.AddAsync(settings);
                await synesthesiaContext.SaveChangesAsync();
                return settings;
            }
            catch (Exception)
            {

                throw;
            } 
        }

        public async Task<Settings> GetSettings()
        {
            try
            {
                return await synesthesiaContext.Settings.FirstOrDefaultAsync();

            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task SetAppKey(string appKey)
        {
            try
            {
                var settings = await GetSettings();
                settings.AppKey = appKey;
                await synesthesiaContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
