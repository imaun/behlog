using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Shop;
using Behlog.Shop.Services.Contracts;

namespace Behlog.Shop.Services {

    public class ShippingService : IShippingService {

        private readonly IWebsiteInfo _websiteInfo;
        private readonly IWebsiteRepository _websiteRepository;


        public ShippingService(
            IWebsiteInfo websiteInfo,
            IWebsiteRepository websiteRepository) {
            websiteInfo.CheckArgumentIsNull(nameof(websiteInfo));
            _websiteInfo = websiteInfo;

            websiteRepository.CheckArgumentIsNull(nameof(websiteRepository));
            _websiteRepository = websiteRepository;
        }


        public async Task<Shipping> GetDefaultShippingForWebsiteAsync()
            => await _websiteRepository.GetDefaultShippingAsync(_websiteInfo.Id);
        
    }
}
