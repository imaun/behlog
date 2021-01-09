using System.Threading.Tasks;
using System.Collections.Generic;
using Behlog.Core.Extensions;
using System.Text;
using Behlog.Shop.Services.Data;
using Behlog.Shop.Factories.Contracts;
using Behlog.Shop.Services.Validation;
using Behlog.Shop.Services.Contracts;
using Behlog.Core.Exceptions;
using Behlog.Core.Models.Shop;
using Behlog.Core.Contracts.Repository.Shop;

namespace Behlog.Shop.Services {
    public class OrderProductService {

        private readonly IProductFactory _productFactory;
        private readonly ICustomerFactory _customerFactory;
        private readonly ICustomerValidator _customerValidator;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IShippingAddressFactory _shippingAddressFactory;

        public OrderProductService(
            IProductFactory productFactory,
            IProductRepository productRepository,
            ICustomerRepository customerRepository,
            IShippingAddressFactory shippingAddressFactory,
            ICustomerFactory customerFactory,
            ICustomerValidator customerValidator) {

            productFactory.CheckArgumentIsNull(nameof(productFactory));
            _productFactory = productFactory;

            productRepository.CheckArgumentIsNull(nameof(productRepository));
            _productRepository = productRepository;

            customerRepository.CheckArgumentIsNull(nameof(customerRepository));
            _customerRepository = customerRepository;

            shippingAddressFactory.CheckArgumentIsNull(nameof(shippingAddressFactory));
            _shippingAddressFactory = shippingAddressFactory;

            customerFactory.CheckArgumentIsNull(nameof(customerFactory));
            _customerFactory = customerFactory;

            customerValidator.CheckArgumentIsNull(nameof(customerValidator));
            _customerValidator = customerValidator;
        }


        public async Task OrderProductAsync(OrderSingleProductDto model) {
            model.CheckArgumentIsNull();
            var product = await _productRepository.FindAsync(model.ProductId);
            if (model.NationalCode.IsNullOrEmpty())
                throw new EntityInsufficientDataException(nameof(model.NationalCode));

            var customer = await _customerRepository.GetByNationalCodeAsync(model.NationalCode);
            var shippingAddress = _shippingAddressFactory.BuildShippingAddress(model.ShippingAddress);
            if (customer == null) {
                customer = _customerFactory.BuildRealCustomerFromOrder(model);
            }
            customer.ShippingAddresses.Add(shippingAddress);
            _customerRepository.MarkForAdd(customer);
            await _customerRepository.SaveChangesAsync();

            var order = await _productFactory.AddSingleOrderAsync(product, model);
            order.ShippingAddress = shippingAddress;

            var orderList = new List<Order> {
                { order }
            };

            //_customerFactory.AddInvoiceAsync(customer, orderList, shippingAddress, )
        }

    }
}
