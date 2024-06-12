using MyFirstProject.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProject.Data
{
    public class UserEntity : IDataHelper<User>
    {
        DBContext db;
        private User user;
        public UserEntity()
        {
            db = new DBContext();

        }

    
        public User Find(int Id)
        {
            return db.Users.Where(x => x.Id == Id).First();
           
        }
        public List<User> GetData()
        {
            return  db.Users.ToList();
        }
        public void Add(User tabel)
        {
            db.Users.Add(tabel);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            db = new DBContext();
            user = Find(Id);
            db.Users.Remove(user);
            db.SaveChanges();

        }

        public void Edit(int Id, User tabel)
        {
            db = new DBContext();
            db.Users.Update(tabel);
            db.SaveChanges();

        }

        public List<User> Search(string SearchItem)
        {
            return db.Users.Where(x => x.Id.ToString() == SearchItem || x.Name.Contains(SearchItem) || x.Age.ToString().Contains(SearchItem)
                     || x.PassWord.ToString().Contains(SearchItem)


            ).ToList();
        }
    }

       
    }

