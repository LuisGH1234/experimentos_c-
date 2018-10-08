using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlaylistCore.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;

namespace PlaylistCore.DAO.Tests
{
    [TestClass()]
    public class PlaylistDAOTests
    {

        PlaylistDAO playlistDao = new PlaylistDAO();
        playlist _playlist;

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPlaylistTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertTest()
        {
            try
            {
                _playlist = new playlist();
                _playlist.name = "playlist 1";
                _playlist.favorite = true;
                _playlist.description = "descripcion 1";

                //Mock.Arrange(() => playlistDao.Insert(_playlist)).Returns(_playlist);

                playlistDao.Insert(_playlist);

                Assert.IsTrue(_playlist.id > 0);
            }
            catch (Exception e)
            {
                Assert.Fail("Fallo la prueba: " + e.Message);
            }
        }
    }
}