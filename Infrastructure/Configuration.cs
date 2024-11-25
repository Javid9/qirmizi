﻿using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public static class Configuration
    {
        public static string? ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory())).AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("SqlConnection");
            }
        }
    }
}
