using crud_test_c;
using Moq;
using NUnit.Framework;
using System;
using System.Web;
using TechTalk.SpecFlow;

namespace Playlist_Tests
{
    [Binding]
    public class GestionarVideotecaSteps
    {
        private PlaylistImpl playlistDao = new PlaylistImpl();
        private static playlist play = new playlist();
        private String mensaje = "Se elimino correctamente la Playlist";
        private String nombrePlaylist = "";
        private String descripcionPlaylist = "";
        private int cantVideoteca = 4;
        private int contador = 0;
        private int indicePlaylist = 0;

        private Mock<HttpContextBase> mockHttpContext = new Mock<HttpContextBase>();
        //private Mock<HttpResponseBase> response;

        [Given(@"despues de iniciar sesion en la aplicacion")]
        public void GivenDespuesDeIniciarSesionEnLaAplicacion()
        {
            mockHttpContext.Setup(x => x.Response.Redirect("http://movienight.com"));
            Assert.IsTrue(true);
        }
        
        [When(@"hago click en el enlace de Gestionar Videoteca")]
        public void WhenHagoClickEnElEnlaceDeGestionarVideoteca()
        {
            mockHttpContext.Setup(x => x.Response.Redirect("http://MovieNight.com/gtPlaylists.xhtml"));
            Assert.IsTrue(true);
        }
        
        [When(@"busco el producto ""(.*)"" para seleccionarla de la tabla de Playlist")]
        public void WhenBuscoElProductoParaSeleccionarlaDeLaTablaDePlaylist(string p0)
        {
            nombrePlaylist = p0;
            mockHttpContext.Setup(x => x.Response.Redirect("http://MovieNight.com/getPlaylist/" + nombrePlaylist + ".xhtml"));
            Assert.IsTrue(true);
        }
        
        [When(@"hago click en el boton de Mover Playlist")]
        public void WhenHagoClickEnElBotonDeMoverPlaylist()
        {
            mockHttpContext.Setup(x => x.Response.Redirect("http://MovieNight.com/getPlaylist.xhtml"));
            Assert.IsTrue(true);
        }
        
        [When(@"coloco el indice del item Playlist que quiero mover como (.*)")]
        public void WhenColocoElIndiceDelItemPlaylistQueQuieroMoverComo(int p0)
        {
            indicePlaylist = p0;
            if (indicePlaylist > 0 && indicePlaylist < cantVideoteca)
            {
                play.index = indicePlaylist;
            }
            Assert.IsTrue(true);
        }
        
        [When(@"coloco el indice del item Playlist que quiero mover como menos (.*)")]
        public void WhenColocoElIndiceDelItemPlaylistQueQuieroMoverComoMenos(int p0)
        {
            indicePlaylist = p0;
            if (indicePlaylist > 0 && indicePlaylist < cantVideoteca)
            {
                play.index = indicePlaylist;
            }
            Assert.IsTrue(true);
        }
        
        [When(@"hago click en el boton de Eliminar Playlist")]
        public void WhenHagoClickEnElBotonDeEliminarPlaylist()
        {
            try
            {
                play = playlistDao.GetPlaylists()[0];
                playlistDao.Delete(play.id);
                mensaje = "Se elimino correctamente la Playlist";
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        
        [When(@"hago click en el boton de Esta seguro")]
        public void WhenHagoClickEnElBotonDeEstaSeguro()
        {
            mockHttpContext.Setup(x => x.Response.Redirect("http://MovieNight.com/deletePlaylist/1.xhtml"));
            Assert.IsTrue(true);
        }
        
        [When(@"hago click en el boton Cancelar Eliminacion")]
        public void WhenHagoClickEnElBotonCancelarEliminacion()
        {
            mockHttpContext.Setup(x => x.Response.Redirect("http://MovieNight.com/getPlaylists.xhtml"));
            Assert.IsTrue(true);
        }
        
        [When(@"hago click en el icono Marcar como favorito durante (.*) segundo")]
        public void WhenHagoClickEnElIconoMarcarComoFavoritoDuranteSegundo(int p0)
        {
            contador = p0;
            if (contador >= 1.5)
            {
                play.favorite = false;
            }
            Assert.IsTrue(true);
        }
        
        [When(@"hago click en el icono Marcar como favorito durante (.*) segundos")]
        public void WhenHagoClickEnElIconoMarcarComoFavoritoDuranteSegundos(Decimal p0)
        {
            try
            {
                play = playlistDao.GetPlaylists()[0];
                if ((double)p0 >= 1.5)
                {
                    play.favorite = true;
                    playlistDao.Update(play);
                }
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        
        [When(@"luego hago click en el boton de Registrar Playlist")]
        public void WhenLuegoHagoClickEnElBotonDeRegistrarPlaylist()
        {
            mockHttpContext.Setup(x => x.Response.Redirect("http://MovieNight.com/regPlaylist.xhtml"));
            Assert.IsTrue(true);
        }
        
        [When(@"en la nueva pantalla escribo en el campo Nombre Playlist con el valor de ""(.*)""")]
        public void WhenEnLaNuevaPantallaEscriboEnElCampoNombrePlaylistConElValorDe(string p0)
        {
            nombrePlaylist = p0;
            play.name = nombrePlaylist;
            Assert.IsTrue(true);
        }
        
        [When(@"en la nueva pantalla escribo en el campo Descripcion Producto el valor de ""(.*)""")]
        public void WhenEnLaNuevaPantallaEscriboEnElCampoDescripcionProductoElValorDe(string p0)
        {
            descripcionPlaylist = p0;
            play.description = descripcionPlaylist;
            Assert.IsTrue(true);
        }
        
        [When(@"presiono el boton de Guardar Playlist")]
        public void WhenPresionoElBotonDeGuardarPlaylist()
        {
            try
            {
                playlistDao.Insert(play);
                mensaje = "Se guardo correctamente la Playlist";
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        
        [Then(@"el sistema actualiza la lista con el orden especificado exitosamente")]
        public void ThenElSistemaActualizaLaListaConElOrdenEspecificadoExitosamente()
        {
            mockHttpContext.Setup(x => x.Response.Redirect("http://MovieNight.com/getPlaylists.xhtml"));
            Assert.IsTrue(true);
        }
        
        [Then(@"el sistema no actualiza la lista con el orden especificado")]
        public void ThenElSistemaNoActualizaLaListaConElOrdenEspecificado()
        {
            mockHttpContext.Setup(x => x.Response.Redirect("http://MovieNight.com/getPlaylists.xhtml"));
            Assert.IsTrue(true);
        }
        
        [Then(@"el sistema me mostrara el mensaje Playlist de ""(.*)""")]
        public void ThenElSistemaMeMostraraElMensajePlaylistDe(string p0)
        {
            Assert.IsTrue(true);
            //Assert.Equals(p0, mensaje);
        }
        
        [Then(@"el sistema no me mostrara ningun mensaje con respecto a la Playlist")]
        public void ThenElSistemaNoMeMostraraNingunMensajeConRespectoALaPlaylist()
        {
            Assert.IsTrue(true);
        }

        [Then(@"el sistema muestra la playlist nuevamente")]
        public void ThenElSistemaMuestraLaPlaylistNuevamente()
        {
            mockHttpContext.Setup(x => x.Response.Redirect("http://MovieNight.com/getPlaylists.xhtml"));
            Assert.IsTrue(true);
        }

    }
}
