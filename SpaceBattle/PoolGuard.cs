using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacebattle
{
    internal class PoolGuard<T> : IDisposable where T : class, new()
    {
        private readonly Pool<T> _pool;
        private readonly T _obj;

        public PoolGuard(Pool<T> pool)
        {
            _pool = pool;
            _obj = _pool.GetObject();
        }

        public T Object => _obj;

        public void Dispose()
        {
            _pool.ReleaseObject(_obj);
        }
    }
}
