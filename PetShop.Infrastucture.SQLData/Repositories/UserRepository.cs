using PetShop.Core.DomainService.AuthRepo;
using PetShop.Core.Entity.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastucture.SQLData.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly PetShopContext db;
        public UserRepository(PetShopContext context)
        {
            db = context;
        }
        public void Add(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
        }

        public void Edit(User entity)
        {
            db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public User Get(long id)
        {
            return db.Users.FirstOrDefault(b =>b.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.ToList();
        }

        public void Remove(long id)
        {
            var item = db.Users.FirstOrDefault(b => b.Id == id);
            db.Users.Remove(item);
            db.SaveChanges();
        }
    }
}
