using BLL.DTOs;
using DAL.EF;
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
        public static List<CategoryDTO> Get() {
            var catRepo = new CategoryRepo();
            var data = catRepo.Get();

            return Convert(data);
        }

        public static List<CategoryDTO> Convert(List<Category> data) {
            return new List<CategoryDTO>();
        }
    }
}
