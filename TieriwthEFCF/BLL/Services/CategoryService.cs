using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using DAL.Repos;
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
            });
            return new Mapper(config);
        }
        public static List<CategoryDTO> Get() {
            var data = DataAccess.CategoryData().Get();
            return GetMapper().Map<List<CategoryDTO>>(data);
        }
        public static void Create(CategoryDTO c) {
            var data = GetMapper().Map<Category>(c);
            DataAccess.CategoryData().Create(data);
        }
    }
}
