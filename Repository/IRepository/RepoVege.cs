using OmniselloTask.Data;
using OmniselloTask.Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public class RepoVege : IVegetables
    {
        private readonly ApplicationDbContext _context;
        public RepoVege(ApplicationDbContext context)
        {
            _context=context;
        }
        public Vegetables AddVegetable(Vegetables vegetables)
        {
            _context.Vegetable.Add(vegetables);
            _context.SaveChanges();
            return vegetables;
        }

        public void DeleteVegetable(int id)
        {
            Vegetables vege = _context.Vegetable.Find(id);
            _context.Vegetable.Remove(vege);
            _context.SaveChanges();
        }

        public Vegetables GetVegetable(int id)
        {
            return _context.Vegetable.Find(id); 
        }

        public IEnumerable<Vegetables> GetAllVege()
        {
            return _context.Vegetable;
        }

        public Vegetables UpdateVegetable(Vegetables vegetables)
        {
            var vege = _context.Vegetable.Attach(vegetables);
            vege.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return vegetables;
        }
    }
}
