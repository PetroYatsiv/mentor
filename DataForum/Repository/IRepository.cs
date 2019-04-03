using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(); //get all object
        T Get(int id); //get object by Id
        void Create(T item); //create object
        void Update(int id, T item); //update object
        void Delete(int id);//delete object
    }
}
