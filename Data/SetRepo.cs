using System.Collections.Generic;
using System.Linq;
using Framework.Models;

namespace Framework.Data
{
    public class SetRepo : ISetRepo
    {
        private readonly prod_frameworkContext _context;
        public SetRepo(prod_frameworkContext context)
        {
            _context = context;
        }
        public void CreateSet(Set set)
        {
            throw new System.NotImplementedException();
        }

        public Set GetSetById(int id)
        {
            return _context.Set.FirstOrDefault(s => s.SetId == id);
        }

        public IEnumerable<Set> GetSets()
        {
            return _context.Set.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}