﻿using Angular_CRUD_Test.Models;

namespace Angular_CRUD_Test.Services
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
    }
}
