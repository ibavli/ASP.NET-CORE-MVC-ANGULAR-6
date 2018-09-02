using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityGuide.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CityGuide.API.Data
{
    public class AppRepository : IAppRepository
    {
        private DatabaseContext _db;
        public AppRepository(DatabaseContext db)
        {
            _db = db;
        }

        public void Add<T>(T entity) where T : class
        {
            _db.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _db.Remove(entity);
        }

        public List<City> GetCities()
        {
            return _db.Cities.Include(c=>c.Photos).ToList();
        }

        public City GetCityById(int cityId)
        {
            return _db.Cities.Include(c=>c.Photos).FirstOrDefault(c=>c.Id == cityId);
        }

        public Photo GetPhoto(int id)
        {
            return _db.Photos.FirstOrDefault(p=>p.Id == id);
        }

        public List<Photo> GetPhotosByCity(int cityId)
        {
            return _db.Photos.Where(p=>p.CityId == cityId).ToList();
        }

        public bool SaveAll()
        {
            return _db.SaveChanges() > 0;
        }
    }
}
