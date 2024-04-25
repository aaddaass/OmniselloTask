using OmniselloTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IVegetables
    {
        Vegetables GetVegetable(int id);
        IEnumerable<Vegetables> GetAllVege();
        Vegetables AddVegetable(Vegetables vegetables);
        Vegetables UpdateVegetable(Vegetables vegetables);
        void DeleteVegetable(int id);

    }
}
