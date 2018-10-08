using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_c
{
    public interface IPlaylist
    {
        List<playlist> GetPlaylists();
        void Insert(playlist play);
        void Update(playlist play);
        void Delete(long id);
        playlist GetPlaylist(long id);
    }
}
