using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string Username, string Password)
        {
            var res = DataAccessFactory.AuthData().Authenticate(Username, Password); //true if uname & pass matched,
                                                                                     //then generate token and return the token to the user

            if (res == true)
            {
                var allTkn = DataAccessFactory.TokenData().Get();
                var exTkn = (from t in allTkn
                             where t.CreatedBy.Equals(Username) &&
                             t.ExpiredAt == null
                             select t).SingleOrDefault();
                if (exTkn != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(exTkn);
                }
                else
                {
                    var token = new Token();
                    token.CreatedBy = Username;
                    token.CreatedAt = DateTime.Now;
                    token.TKey = Guid.NewGuid().ToString();
                    var ret = DataAccessFactory.TokenData().Create(token);
                    if (ret != null)
                    {
                        var cfg = new MapperConfiguration(c =>
                        {
                            c.CreateMap<Token, TokenDTO>();
                        });
                        var mapper = new Mapper(cfg);
                        return mapper.Map<TokenDTO>(ret);
                    }
                }
            }
            return null;
        }
        public static TokenDTO IsTokenValid(string tkey)//return token obj
        {
            var extk = DataAccessFactory.TokenData().Get(tkey);
            if (extk != null && extk.ExpiredAt == null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Token, TokenDTO>();
                });
                var mapper = new Mapper(cfg);
                return mapper.Map<TokenDTO>(extk);
            }
            return null;
        }
        public static string TokenUserType(string tkey)//return token User type
        {
            var token = IsTokenValid(tkey);
            if (token != null)
            {
                var user = DataAccessFactory.UserData().Get(token.CreatedBy);
                return user.Type.ToString();
            }
            return null;
        }
        public static bool Logout(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Get(tkey);
            extk.ExpiredAt = DateTime.Now;
            if (DataAccessFactory.TokenData().Update(extk) != null) return true;
            return false;

        }
        public static int TokenUserId(string tkey)//return token User id, for leave application
        {
            var token = IsTokenValid(tkey);

            var allStaff = DataAccessFactory.StaffData().Get();
            var user = (from s in allStaff
                        where s.Username.Equals(token.CreatedBy)
                        select s).SingleOrDefault();

            return user.Id;
        }
    }
}
