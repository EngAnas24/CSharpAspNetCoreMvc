using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProject.Data
{
    public interface IDataHelper<Tabel>
    {
        List<Tabel> GetData();
        List<Tabel> Search(string SearchItem);
        Tabel Find(int Id);
        void Add(Tabel tabel);
        void Edit(int Id,Tabel tabel);
        void Delete(int Id);

    }
}
