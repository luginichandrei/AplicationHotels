﻿using Models;

namespace BusinessLayer.Interfaces
{
    public interface IUserService : IService<User>
    {
        User FindByName(string name);
    }
}