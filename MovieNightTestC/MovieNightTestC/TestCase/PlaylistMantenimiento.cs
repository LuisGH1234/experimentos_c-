using MovieNightTestC.DataManager;
using MovieNightTestC.Page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNightTestC.TestCase
{
    [TestFixture]
    class PlaylistMantenimiento
    {
        private IniciarSesionPage iniciarSesionPage;
        private PlaylistPage playlistPage;
        private string rutaCarpetaError = "C:/CapturasPantalla/Playlist";
        private static string FILENAME = "MovieNightCriterios.xlsx";
        private int idNavegadorTestlink;
        private string nombreNavegadorTestlink;

        [SetUp]
        public void AntesDelTest(string navegador, int testlinkIdNavegador, string testlinkNombreNavegador)
        {
            iniciarSesionPage = new IniciarSesionPage(navegador);
            playlistPage = new PlaylistPage(ref iniciarSesionPage.WebDriver);
            idNavegadorTestlink = testlinkIdNavegador;
            nombreNavegadorTestlink = testlinkNombreNavegador;
        }

        private static IEnumerable<TestCaseData> DataIniciarSesion => ExcelReader.ReadFromExcel(FILENAME, "Login");
        private static IEnumerable<TestCaseData> DataInsertar => ExcelReader.ReadFromExcel(FILENAME, "RegistroPlaylist");
        private static IEnumerable<TestCaseData> DataActualizar => ExcelReader.ReadFromExcel(FILENAME, "EditarPlaylist");
        private static IEnumerable<TestCaseData> DataFavorito => ExcelReader.ReadFromExcel(FILENAME, "Favorito");
        private static IEnumerable<TestCaseData> DataEliminar => ExcelReader.ReadFromExcel(FILENAME, "EliminarPlaylist");

        [TestCaseSource("DataIniciarSesion")]
        public void IniciarSesion(string casoPrueba, string urlInicial, string usuario, string clave,
            string valorEsperado, string urlTestlink, string keyTestlink,
            string idTestCaseInternoTestlink, string idTestCaseExternoTestlink,
            string idTestPlanTestlink, string idBuidTestink, string nombreBuildTestlink)
        {
            try
            {
                iniciarSesionPage.IngresarPaginaIniciarSesion(urlInicial);
                string valorObtenido = iniciarSesionPage.IniciarSesion(usuario, clave);
                Assert.Equals(valorObtenido, valorEsperado);

            }
            catch (AssertionException e)
            {
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
            } catch(Exception e) {
                Assert.Fail("Error: " + e.StackTrace);
            }
        }
        /*public void InsertarPlaylist(string casoPrueba, string urlInicial, string usuario, string clave, String nombre,
            string descripcion, string valorEsperado, string urlTestlink, string keyTestlink,
            string idTestCaseInternoTestlink, string idTestCaseExternoTestlink,
            string idTestPlanTestlink, string idBuidTestink, string nombreBuildTestlink)
        {

        }*/
    }
}
