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
    public class CategoryService
    {
        public static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<CategoryDTO, Category>();
                cfg.CreateMap<Category, CategoryProductDTO>();
                cfg.CreateMap<Product, ProductDTO>();
            });
            return new Mapper(config);
        }

        public static List<CategoryDTO> Get() {
            var repo = DataAccessFactory.CategoryData();
            return GetMapper().Map<List<CategoryDTO>>(repo.Get());
        }
        public static CategoryDTO Get(int id)
        {
            var repo = DataAccessFactory.CategoryData();
            return GetMapper().Map<CategoryDTO>(repo.Get(id));
        }
        public static CategoryProductDTO GetwithProducts(int id) {
            var repo = DataAccessFactory.CategoryData();
            return GetMapper().Map<CategoryProductDTO>(repo.Get(id));
        }
    }
}
