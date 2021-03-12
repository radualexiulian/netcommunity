using AutoMapper;
using Notifications.Application.Commands;
using Notifications.Domain;
using Notifications.Dto;
using System;

namespace Notifications.Mappers
{
    public class UserProfile : InternalProfile
    {
        public UserProfile()
        {
            this.CreateMap<UserDto, UserCommand>();
            this.CreateMap<UserCommand, User>();
        }
    }
}
