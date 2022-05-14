using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.Repositories;
using AutoMapper;
using Net14.Web.Models.store;

namespace Net14.Web.Services
{
    public class AdvertisingService
    {
        private ProductRepository _productRepository;
        private IMapper _mapper;

        [AutoRegister]
        public AdvertisingService(ProductRepository productRepository, IMapper mapper) 
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public List<ProductViewModel> GetAdvertising() 
        {
            var rand = new Random();
            var product = _productRepository.GetAll()
                .Where(product
                => product.CoolCategories == EfStuff.EnumStore.CoolCategories.Snekers ||product.CoolCategories == EfStuff.EnumStore.CoolCategories.Bags
                && product.StoreImages != null)
                .OrderBy(product => rand.Next())
                .Take(3)
                .ToList();

            var viewModelResult = _mapper.Map<List<ProductViewModel>>(product);

            return viewModelResult;
        }
    }
}
