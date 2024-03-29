﻿using DatinApp.API.Helpers;
using DatinApp.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatinApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _context;

        public DatingRepository(DataContext context)
        {
            this._context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Photo> GetMainPhotoForUser(int userId)
        {
            return await  _context.Photos.Where(u => u.UserId == userId)
                .FirstOrDefaultAsync(s => s.IsMain);
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(x => x.Id == id);

            return photo;
        }

        public async Task<User> GetUser(int id)
        {
            var user =await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }
        
        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users =   _context.Users.Include(p => p.Photos).AsQueryable();

            users = users.Where(u => u.Id != userParams.UserId);
            users = users.Where(u => u.Gender == userParams.Gender);


            return await PagedList<User>.CreateAsync(users, userParams.PageNumber,userParams.PageSize);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
