using KetchupMayoSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KetchupMayoSite.Services
{
    public interface IKetchupService
    {
        IEnumerable<Ketchup> Get();
        Ketchup Get(int Id);
        void Post(Ketchup ketchup);
        void Put(Ketchup ketchupToUpdate, Ketchup ketchup);
        void Delete(int Id);
    }
}
