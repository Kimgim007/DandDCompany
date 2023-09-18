using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.RegisterDI;

using DataBase.MyDbContext;
using DTO.Service;
using DataBase.Repository;
using DataBase.Repository.IRepository;
using DataBase.DbEntity;
using DTO.Entity;

namespace DTO.RegisterDI
{
    public static class RegisterDI
    {
        public static void Register(IServiceCollection service)
        {
            DataBase.RegisterDI.RegisterDI.Register(service);

            service.AddScoped<ClassRepository>();
            service.AddScoped<GameRoomRepository>();
            service.AddScoped<GameCharacterRepository>();
            service.AddScoped<AccountRepository>();
            service.AddScoped<GameAccountGameRoomRepository>();
          
        }
    }
}
