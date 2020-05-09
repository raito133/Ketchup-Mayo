using KetchupMayoSite.Controllers;
using KetchupMayoSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KetchupMayoSite.Services
{

    public class KetchupService : IKetchupService
    {

        readonly DBContext _ketchupContext; // used to contact with the database

        public KetchupService(DBContext ketchupContext)
        {
            _ketchupContext = ketchupContext;
        }

        public void Delete(int Id)
        {
            Ketchup ketchup = Get(Id);
            _ketchupContext.Ketchups.Remove(ketchup);
            _ketchupContext.SaveChanges();
        }

        public IEnumerable<Ketchup> Get()
        {
            return _ketchupContext.Ketchups.ToList();
        }

        public Ketchup Get(int id)
        {
            return _ketchupContext.Ketchups.FirstOrDefault(e => e.Id == id);
        }

        public void Post(Ketchup ketchup)
        {
            _ketchupContext.Add(ketchup);
            _ketchupContext.SaveChanges();
        }

        public void Put(Ketchup dbEntity, Ketchup entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Brand = entity.Brand;
            dbEntity.Spiciness = entity.Spiciness;
            dbEntity.ProductionDate = entity.ProductionDate;
            _ketchupContext.Update(dbEntity);
            _ketchupContext.SaveChanges();

        }
    }
}
