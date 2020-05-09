using KetchupMayoSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KetchupMayoSite.Services
{
    public interface IMayoService
    {
        IEnumerable<Mayo> Get();
        Mayo Get(int Id);
        void Post(Mayo mayo);
        void Put(Mayo mayoToUpdate, Mayo mayo);
        void Delete(int Id);
    }
}
