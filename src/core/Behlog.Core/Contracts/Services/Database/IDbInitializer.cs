using System.Threading.Tasks;
using Behlog.Core.Models.Security;
using Behlog.Core.Models.System;
using Microsoft.AspNetCore.Identity;

namespace Behlog.Core.Contracts.Services.Database
{
    public interface IDbInitializer
    {
        /// <summary>
        /// Applies any pending migrations for the context to the database.
        /// Will create the database if it does not already exist.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Adds some default values to the IdentityDb
        /// </summary>
        void SeedData();

        Task<(User,IdentityResult)> CreateAdminUserAsync();

        //Task CreateDefaultWebsiteAsync(IBehlogContext User adminUser, Language defLanguage);
    }
}
