using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spacebattle;

namespace spacebattle
{
    internal class Pool<T> where T : class, new()
    {
       private readonly Stack<T> _pool;

        public Pool(int count)
        {
            _pool = new Stack<T>(count);
        }

        public T GetObject()
        {
            if (_pool.Count > 0)
            {
                return _pool.Pop();
            }
            return new T();
        }

        public void ReleaseObject(T obj)
        {
            _pool.Push(obj);
        }
    }
}
