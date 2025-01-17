﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.Models;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetById(int userId);
        void Update(User user);
        void Delete(int userId);
        IEnumerable<User> GetAll();
        public void Save();
        public void ChangeActiv();
        public int checkType(string password, string email);
        public bool LoginCheck(string password,string email);
        public string NameofAdmin();

        User GetActiveUser();
    }
}
