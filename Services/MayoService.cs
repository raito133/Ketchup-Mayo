using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KetchupMayoSite.Controllers;
using KetchupMayoSite.Models;

namespace KetchupMayoSite.Services
{
    public class MayoService : IMayoService
    {
        readonly DBContext _DBContext; // used to contact with the database

        public MayoService(DBContext DBContext)
        {
            _DBContext = DBContext;
        }

        public void Delete(int Id)
        {
            Mayo mayo = Get(Id);
            _DBContext.Mayos.Remove(mayo);
            _DBContext.SaveChanges();
        }

        public IEnumerable<Mayo> Get()
        {
            return _DBContext.Mayos.ToList();
        }

        public Mayo Get(int id)
        {
            return _DBContext.Mayos.FirstOrDefault(e => e.Id == id);
        }

        public void Post(Mayo mayo)
        {
            _DBContext.Add(mayo);
            _DBContext.SaveChanges();
        }

        public void Put(Mayo dbEntity, Mayo entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Brand = entity.Brand;
            dbEntity.Mildness = entity.Mildness;
            dbEntity.ProductionDate = entity.ProductionDate;
            _DBContext.Update(dbEntity);
            _DBContext.SaveChanges();

        }
    }
}
