using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.IndexedDB.WebAssembly;
using IndexedDb.Data;
using Microsoft.JSInterop;

namespace IndexedDb.Services
{
    public interface IUserIndexedDbService
    {
        Task<User> GetUser(int userId);
        Task<List<User>> GetUsers();
        Task AddUser(User user);
        Task RemoveUser(User user);
        Task UpdateUser(User user);
    }
    public class UserIndexedDbService : IUserIndexedDbService
    {
        private readonly IIndexedDbFactory _indexedDb;
        private IJSRuntime _jsRuntime;

        public UserIndexedDbService(IIndexedDbFactory indexedDb, IJSRuntime jsRuntime)
        {
            _indexedDb = indexedDb;
            _jsRuntime = jsRuntime;
        }


        public async Task<User> GetUser(int userId)
        {
            Console.WriteLine("Start GET User");
            try
            {
                using (var db = await _indexedDb.Create<AppIndexedDb>())
                {
                    var user = db.Users.FirstOrDefault(c => c.Id == userId);
                    return user;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new User
                {
                    Id = 99999,
                    Name = "NULL",
                    Email = "NULL",
                    Mobile = "NULL",
                    Created = DateTime.MaxValue
                };
            }
        }
        public async Task<List<User>> GetUsers()
        {
            Console.WriteLine("Start GET Users");
            try
            {
                using (var db = await _indexedDb.Create<AppIndexedDb>())
                {
                    var users = db.Users.ToList();
                    return users;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<User>();
            }
        }
        public async Task AddUser(User user)
        {
            Console.WriteLine("Start ADD User");
            try
            {
                using (var db = await _indexedDb.Create<AppIndexedDb>())
                {
                    user.Created = DateTime.Now;
                    db.Users.Add(user);
                    await db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public async Task RemoveUser(User user)
        {
            Console.WriteLine("Start REMOVE User");
            try
            {
                using (var db = await _indexedDb.Create<AppIndexedDb>())
                {
                    var myUser = db.Users.FirstOrDefault(c => c.Id == user.Id);
                    db.Users.Remove(myUser);
                    await db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public async Task UpdateUser(User user)
        {
            Console.WriteLine("Start UPDATE User");
            try
            {
                using (var db = await _indexedDb.Create<AppIndexedDb>())
                {
                    var myUser = db.Users.FirstOrDefault(c => c.Id == user.Id);
                    myUser.Name = user.Name;
                    myUser.Email = user.Email;
                    myUser.Mobile = user.Mobile;
                    // ...
                    myUser.Updated = DateTime.Now;
                    await db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
