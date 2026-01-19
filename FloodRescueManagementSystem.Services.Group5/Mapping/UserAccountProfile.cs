using AutoMapper;
using FloodRescueManagementSystem.Entities.Group5.Models;
using FloodRescueManagementSystem.Services.Group5.DTOs.UserAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodRescueManagementSystem.Services.Group5.Mapping
{
    public class UserAccountProfile : Profile
    {
        public UserAccountProfile()
        {
            CreateMap<UserAccount, UserAccountDto>().ReverseMap();
        }
    }
}
