using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistCore.DAO
{
    public interface IDao <T>
    {
        List<T> ListAll();
        T Insert(T obj);
        void Update(T obj);
        void Delete(long id);
        T GetPlaylist(long id);
    }
}
