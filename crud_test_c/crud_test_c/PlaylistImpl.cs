using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_c
{
    public class PlaylistImpl : IPlaylist
    {
        playlistdbEntities context = new playlistdbEntities();

        public void Delete(long id)
        {
            var play = context.playlists.Find(id);
            context.playlists.Remove(play);
            context.SaveChanges();
        }

        public playlist GetPlaylist(long id) => context.playlists.Find(id);

        public List<playlist> GetPlaylists() => context.playlists.ToList();

        public void Insert(playlist play)
        {
            context.playlists.Add(play);
            context.SaveChanges();
        }

        public void Update(playlist play)
        {
            var obj = context.playlists.Find(play.id);
            obj.Sets(play);
            context.SaveChanges();
        }
    }
}
