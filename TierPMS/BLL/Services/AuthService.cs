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
    public class AuthService
    {
        public static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User,UserDTO>();
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<Token, TokenDTO>();
            });
            return new Mapper(config);
        }
        public static TokenDTO Autheiticate(string uname, string pass) {
            var auth = DataAccessFactory.AuthData().Authenticate(uname, pass);
            if (auth != null) {
                var token = new Token();
                token.CreatedAt = DateTime.Now;
                token.UserId = auth.Id;
                token.Key = Guid.NewGuid().ToString();
                var tk = DataAccessFactory.TokenData().Create(token);
                return GetMapper().Map<TokenDTO>(tk);
            }
            return null;    
        }
        public static bool IsTokenValid(string key) {
            var token = DataAccessFactory.TokenData().Get(key);
            if (token != null && token.ExpiredAt  == null) {
                return true;
            }
            return false;
        }
        public static bool Logout(string key)
        {
            var toke = DataAccessFactory.TokenData().Get(key);
            if (toke != null) { 
                toke.ExpiredAt = DateTime.Now;
                DataAccessFactory.TokenData().Update(toke);
                return true;
            }
            return false;

        }
    }
}
