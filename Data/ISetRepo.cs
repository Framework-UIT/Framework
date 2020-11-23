using System.Collections.Generic;
using Framework.Models;

namespace Framework.Data
{
    public interface ISetRepo
    {
        bool SaveChanges();
        IEnumerable<Set> GetSets();
        Set GetSetById(int id);
        void CreateSet(Set set);
    }
}