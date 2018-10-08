using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_c
{
    public class PlaylistImpl : IPlaylist
    {
        readonly Entities _context;

        public PlaylistImpl() => _context = new Entities();

        public void Delete(long id)
        {
            var play = _context.playlists.Find(id);
            _context.playlists.Remove(play);
            _context.SaveChanges();
        }

        public playlist GetPlaylist(long id) => _context.playlists.Find(id);

        public List<playlist> GetPlaylists() => _context.playlists.ToList();

        public void Insert(playlist play)
        {
            _context.playlists.Add(play);
            _context.SaveChanges();
        }

        public void Update(playlist play)
        {

            var obj = _context.playlists.Find(play.id);
            obj.Sets(play);
            _context.SaveChanges();
        }
    }
}
