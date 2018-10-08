using Microsoft.VisualStudio.TestTools.UnitTesting;
using crud_test_c;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using FizzWare.NBuilder;

namespace crud_test_c.Tests
{
    [TestClass()]
    public class PlaylistImplTests
    {
        private Mock<IPlaylist> mock;

        public void SetUp()
        {
            mock = new Mock<IPlaylist>();
        }

        [TestMethod()]
        public void InsertTest()
        {
            try
            {
                mock = new Mock<IPlaylist>();
                var play = new playlist
                {
                    name = "name 1",
                    favorite = true,
                    description = "description 1"
                };
                //mock.Object.Insert(play);
                mock.Setup(x => x.Insert(play));
                //mock.Verify(x => x.Insert(play), Times.Once());
                mock.Object.Insert(play);
                Assert.IsTrue(mock.Object != null);
            }
            catch (Exception ex)
            {
                Assert.Fail("Fallo: " + ex.Message);
            }
        }

        [TestMethod()]
        public void GetPlaylistsTest()
        {
            try
            {
                mock = new Mock<IPlaylist>();
                var playlists = Builder<playlist>.CreateListOfSize(10).Build();
                mock.Setup(x => x.GetPlaylists()).Returns(playlists.ToList());
                var list = mock.Object.GetPlaylists();

                Assert.IsTrue(list.Count > 0 && list.Count < 11);

            }
            catch (Exception ex)
            {
                Assert.Fail("Fallo: " + ex.Message);
            }
        }

        [TestMethod()]
        public void GetPlaylistTest()
        {
            try
            {
                mock = new Mock<IPlaylist>();
                var play_ = new playlist();
                mock.Setup(x => x.GetPlaylist(play_.id)).Returns(play_);
                var onePlay = mock.Object.GetPlaylist(play_.id);

                Assert.IsTrue(onePlay != null);
            }
            catch(Exception ex)
            {
                Assert.Fail("Fallo: " + ex.Message);
            }
        }

        [TestMethod()]
        public void DeleteTest()
        {
            try
            {
                mock = new Mock<IPlaylist>();
                var play_ = new playlist();
                mock.Setup(x => x.Delete(play_.id));
                mock.Object.Delete(play_.id);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail("Fallo: " + ex.Message);
            }
        }

        [TestMethod()]
        public void UpdateTest()
        {
            try
            {
                mock = new Mock<IPlaylist>();
                var play_ = new playlist
                {
                    id = 1,
                    name = "name updated",
                    favorite = false,
                    description = "description updated"
                };
                mock.Setup(x => x.Update(play_));
                mock.Object.Update(play_);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail("Fallo: " + ex.Message);
            }
        }
    }
}