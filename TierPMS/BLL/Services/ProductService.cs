using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<Product, ProductCategoryDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
            });
            return new Mapper(config);
        }

        public static List<ProductDTO> Get()
        {
            var repo = DataAccessFactory.ProductData();
            return GetMapper().Map<List<ProductDTO>>(repo.Get());
        }
        public static ProductDTO Get(int id)
        {
            var repo = DataAccessFactory.ProductData();
            return GetMapper().Map<ProductDTO>(repo.Get(id));
        }
        public static ProductCategoryDTO GetwithCate(int id)
        {
            var repo = DataAccessFactory.ProductData();
            
            return GetMapper().Map<ProductCategoryDTO>(repo.Get(id));
        }
        public static List<ProductDTO> SearchByName(string name) {
            /*var repo = DataAccessFactory.ProductData();
            var data = repo.Get();
            var filter = data.Where(x => x.Name.Contains(name)).ToList();*/


            var repo = DataAccessFactory.ProductFeatures(); 
            var data = repo.SearchByName(name);
            return GetMapper().Map<List<ProductDTO>>(data);

        }
    }
}
