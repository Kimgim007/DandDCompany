﻿using Microsoft.Extensions.DependencyInjection;
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

            service.AddScoped<GameClassRepository>();
            service.AddScoped<RoomRepository>();
            service.AddScoped<CharacterRepository>();
            service.AddScoped<AccountRepository>();
            service.AddScoped<CharacterRoomRepository>();
            service.AddScoped<GamingSystemRepository>();
          
        }
    }
}
