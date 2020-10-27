using Behlog.Core;
using Behlog.Core.Contracts.Repository.Feature;
using Behlog.Core.Extensions;
using Behlog.Factories.Contracts.Feature;
using Behlog.Services.Contracts.Feature;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Behlog.Services.Feature
{
    public class WebsiteVisitService : IWebsiteVisitService
    {
        private readonly IWebsiteVisitRepository _repository;
        private readonly IWebsiteVisitFactory _factory;

        public WebsiteVisitService(
            IWebsiteVisitRepository repository,
            IWebsiteVisitFactory factory) {

            repository.CheckArgumentIsNull(nameof(repository));
            _repository = repository;

            factory.CheckArgumentIsNull(nameof(factory));
            _factory = factory;
        }

        public async Task CreateAsync() {
            var visit = await _factory.MakeAsync();
            await _repository.AddAndSaveAsync(visit);
        }
    }
}
