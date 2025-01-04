using AutoMapper;
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
    public class CourseService
    {
        public static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Course, CourseDTO>();
                cfg.CreateMap<CourseDTO, Course>();
            });
            var mapper = new Mapper(config);
            return mapper;
        }
        public static void Create(CourseDTO c) {
            /*var repo = new CourseRepo();
            var mapper = GetMapper();
            var data = mapper.Map<Course>(c);
            repo.Create(data);*/

            new CourseRepo().Create(GetMapper().Map<Course>(c));
        }
        public static List<CourseDTO> Get() {
            /*var data = new CourseRepo().Get();
            var ret = GetMapper().Map<List<CourseDTO>>(data);
            return ret;*/
            return GetMapper().Map<List<CourseDTO>>(new CourseRepo().Get());
        }
    }
}
