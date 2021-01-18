using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Behlog.Core.Extensions;
using Behlog.Shop.Services.Data;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Shop.Services {

    public class CustomerService {

        private readonly ICustomerRepository _customerRepository;


        public CustomerService(ICustomerRepository customerRepository) {
            customerRepository.CheckArgumentIsNull(nameof(customerRepository));
            _customerRepository = customerRepository;
        }

        
        //public async Task<CustomerInvoiceDto> GetCustomerInvoiceAsync() {

        //}


    }
}
