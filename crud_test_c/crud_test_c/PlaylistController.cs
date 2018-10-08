using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_c
{
    class PlaylistController
    {
        IPlaylist play;

        public PlaylistController(IPlaylist play)
        {
            this.play = play;
        }

    }
}
