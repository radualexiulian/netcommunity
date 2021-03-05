using AutoMapper;
using Notifications.Application.Commands;
using Notifications.Dto;
using System;

namespace Notifications.Mappers
{
    public class UserProfile : InternalProfile
    {
        public UserProfile()
        {
            this.CreateMap<UserDto, UserCommand>();
        }
    }
}
