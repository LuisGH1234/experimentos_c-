using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistCore.DAO
{
    public class PlaylistDAO : IDao<playlist>
    {
        playlistdbEntities context = new playlistdbEntities();

        public void Delete(long id)
        {
            var play = context.playlists.FirstOrDefault(x => x.id == id);
            context.playlists.Remove(play);
        }

        public playlist GetPlaylist(long id)
        {
            var play = context.playlists.Find(id);
            return play;
        }

        public virtual playlist Insert(playlist obj)
        {
            context.playlists.Add(obj);
            context.SaveChanges();
            return obj;
        }

        public List<playlist> ListAll()
        {
            return context.playlists.ToList();
        }

        public void Update(playlist obj)
        {
            var play = context.playlists.Find(obj.id);
            play.name = obj.name;
            play.favorite = obj.favorite;
            play.description = obj.description;
            context.SaveChanges();
        }
    }
}
