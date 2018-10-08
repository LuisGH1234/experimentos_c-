using NUnit.Framework;
using PlaylistCore.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;

namespace PlaylistCore.TestUnitTest
{
    [TestFixture]
    public class PlaylistTest
    {
        

        PlaylistDAO playlistDao;
        playlist _playlist;

        [Test]
        public void A_Insert()
        {
            
            try
            {
                _playlist = new playlist();
                _playlist.name = "playlist 1";
                _playlist.favorite = true;
                _playlist.description = "descripcion 1";

                Mock.Arrange(() => playlistDao.Insert(_playlist)).Returns(_playlist);

                playlistDao.Insert(_playlist);

                Assert.True(_playlist.id > 0);
            }
            catch(Exception e)
            {
                Assert.Fail("Fallo la prueba: " + e.Message);
            }
        }
    }
}
