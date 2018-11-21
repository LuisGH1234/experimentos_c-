using MovieNightTest.Util;
using MovieNightTestC.DataManager;
using MovieNightTestC.Page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MovieNightTestC.TestCase
{
    //[TestFixture("chrome", 1, "Chrome")]
    [TestFixture("firefox", 2, "Firefox")]
    //[TestFixture("edge", 3, "Edge")]
    public class PlaylistMantenimiento
    {
        private IniciarSesionPage iniciarSesionPage;
        private PlaylistPage playlistPage;
        private string rutaCarpetaError;
        private static string FILENAME = "MovieNightCriterios.xlsx";
        private int idNavegadorTestlink;
        private string nombreNavegadorTestlink;
        private string navegador;

        public PlaylistMantenimiento(string navegador, int testlinkIdNavegador, string testlinkNombreNavegador)
        {
            this.navegador = navegador;
            idNavegadorTestlink = testlinkIdNavegador;
            nombreNavegadorTestlink = testlinkNombreNavegador;
            rutaCarpetaError = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\CapturasPantalla";
        }

        [SetUp]
        public void AntesDelTest()
        {
            iniciarSesionPage = new IniciarSesionPage(navegador);
            playlistPage = new PlaylistPage(ref iniciarSesionPage.WebDriver);
        }

        private static IEnumerable<TestCaseData> DataIniciarSesion => ExcelReader.ReadFromExcel(FILENAME, "Login");
        private static IEnumerable<TestCaseData> DataInsertar => ExcelReader.ReadFromExcel(FILENAME, "RegistroPlaylist");
        private static IEnumerable<TestCaseData> DataActualizar => ExcelReader.ReadFromExcel(FILENAME, "EditarPlaylist");
        private static IEnumerable<TestCaseData> DataFavorito => ExcelReader.ReadFromExcel(FILENAME, "Favorito");
        private static IEnumerable<TestCaseData> DataEliminar => ExcelReader.ReadFromExcel(FILENAME, "EliminarPlaylist");

        [Test, TestCaseSource("DataIniciarSesion"), Order(1)]
        public void IniciarSesion(string casoPrueba, string urlInicial, string usuario, string clave,
            string valorEsperado, string urlTestlink, string keyTestlink,
            string idTestCaseInternoTestlink, string idTestCaseExternoTestlink,
            string idTestPlanTestlink, string idBuidTestink, string nombreBuildTestlink)
        {
            try
            {
                iniciarSesionPage.IngresarPaginaIniciarSesion(urlInicial);
                string valorObtenido = iniciarSesionPage.IniciarSesion(usuario, clave);
                Assert.AreEqual(valorObtenido, valorEsperado + "as");
            }
            catch (AssertionException e)
            {
                Utilitario.CaputarPantallarError(rutaCarpetaError, "Error: " + e.Message, ref playlistPage.GetWebDriver());
                Assert.Fail(e.StackTrace);
            }
            catch (Exception e)
            {
                Assert.Fail("ERROR: " + e.StackTrace);
            }
        }

        [Test, TestCaseSource("DataInsertar"), Order(2)]
        public void InsertarPlaylist(string casoPrueba, string urlInicial, string usuario, string clave, String nombre,
            string descripcion, string valorEsperado, string urlTestlink, string keyTestlink,
            string idTestCaseInternoTestlink, string idTestCaseExternoTestlink,
            string idTestPlanTestlink, string idBuidTestink, string nombreBuildTestlink)
        {
            try
            {
                iniciarSesionPage.IngresarPaginaIniciarSesion(urlInicial);
                iniciarSesionPage.IniciarSesion(usuario, clave);

                playlistPage.IrPlaylistRoute();
                playlistPage.EscribirCampoNombre(nombre);
                playlistPage.EscribirCampoDescripcion(descripcion);
                string valorObtenido = playlistPage.HacerClickBotonGuardar().Trim(' ');

                Assert.AreEqual(valorObtenido, valorEsperado.Trim(' '));

            }
            catch (AssertionException e)
            {
                Utilitario.CaputarPantallarError(rutaCarpetaError, "Error: " + e.Message, ref playlistPage.GetWebDriver());
                Assert.Fail(e.StackTrace);
            }
            catch (Exception e)
            {
                Assert.Fail("ERROR: " + e.StackTrace);
            }
        }

        [Test, TestCaseSource("DataActualizar"), Order(3)]
        public void ActualizarPlaylist(string casoPrueba, string urlInicial, string usuario, string clave, string nombre,
            string descripcion, string valorEsperado, string urlTestlink, string keyTestlink,
            string idTestCaseInternoTestlink, string idTestCaseExternoTestlink,
            string idTestPlanTestlink, string idBuidTestink, string nombreBuildTestlink)
        {
            try
            {
                iniciarSesionPage.IngresarPaginaIniciarSesion(urlInicial);
                iniciarSesionPage.IniciarSesion(usuario, clave);

                playlistPage.IrPlaylistRoute();
                playlistPage.HacerClickBotonEditar();
                playlistPage.EscribirCampoNombre(nombre);
                playlistPage.EscribirCampoDescripcion(descripcion);
                string valorObtenido = playlistPage.HacerClickBotonGuardar().Trim(' ');

                Assert.AreEqual(valorObtenido, valorEsperado.Trim(' '));

            }
            catch (AssertionException e)
            {
                Utilitario.CaputarPantallarError(rutaCarpetaError, "Error: " + e.Message, ref playlistPage.GetWebDriver());
                Assert.Fail(e.StackTrace);
            }
            catch (Exception e)
            {
                Assert.Fail("ERROR: " + e.StackTrace);
            }
        }

        [Test, TestCaseSource("DataFavorito"), Order(4)]
        public void MarcarFavorito(string casoPrueba, string urlInicial, string usuario, string clave,
            string valorEsperado, string urlTestlink, string keyTestlink,
            string idTestCaseInternoTestlink, string idTestCaseExternoTestlink,
            string idTestPlanTestlink, string idBuidTestink, string nombreBuildTestlink)
        {
            try
            {
                iniciarSesionPage.IngresarPaginaIniciarSesion(urlInicial);
                iniciarSesionPage.IniciarSesion(usuario, clave);

                playlistPage.IrPlaylistRoute();
                bool valorObtenido = playlistPage.HacerClickBotonFavorito();

                Assert.AreEqual(valorObtenido ? "1" : "0", valorEsperado);

            }
            catch (AssertionException e)
            {
                Utilitario.CaputarPantallarError(rutaCarpetaError, "Error: " + e.Message, ref playlistPage.GetWebDriver());
                Assert.Fail(e.StackTrace);
            }
            catch (Exception e)
            {
                Assert.Fail("ERROR: " + e.StackTrace);
            }
        }

        [Test, TestCaseSource("DataEliminar"), Order(5)]
        public void EliminarPlaylist(string casoPrueba, string urlInicial, string usuario, string clave,
            string valorEsperado, string urlTestlink, string keyTestlink,
            string idTestCaseInternoTestlink, string idTestCaseExternoTestlink,
            string idTestPlanTestlink, string idBuidTestink, string nombreBuildTestlink)
        {
            try
            {
                iniciarSesionPage.IngresarPaginaIniciarSesion(urlInicial);
                iniciarSesionPage.IniciarSesion(usuario, clave);

                playlistPage.IrPlaylistRoute();
                string valorObtenido = playlistPage.HacerClickBotonEliminar().Trim(' ');

                Assert.AreEqual(valorObtenido, valorEsperado.Trim(' '));

            }
            catch (AssertionException e)
            {
                Utilitario.CaputarPantallarError(rutaCarpetaError, "Error: " + e.Message, ref playlistPage.GetWebDriver());
                Assert.Fail(e.StackTrace);
            }
            catch (Exception e)
            {
                Assert.Fail("ERROR: " + e.StackTrace);
            }
        }

        [TearDown]
        public void DespuestDelTest()
        {
            try
            {
                playlistPage.CerrarPagina();
            }
            catch (Exception e)
            {
                Assert.Fail("Error: " + e.StackTrace);
            }
        }
    }
}
