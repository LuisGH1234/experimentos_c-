using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLinkApi;

namespace MovieNightTest.Util
{
    public static class MovieTestlink
    {
        public static bool ReportarCasoDePrueba(string urlTestlink, string keyTestlink, int idTestCaseInterno,
            int idTestCaseExterno, int idTestPlan, bool paso, int idBuild, string nombreBuild,
            string mensaje, int idPlataforma, string nombrePlataforma)
        {
            bool seEjecuto = false;
            try
            {
                var testlinkApi = new TestLink(keyTestlink, urlTestlink);
                testlinkApi.ReportTCResult(
                    idTestCaseInterno, 
                    idTestPlan, 
                    paso ? TestCaseStatus.Passed : TestCaseStatus.Failed, 
                    idPlataforma, 
                    nombrePlataforma, 
                    false, 
                    true, 
                    mensaje,
                    idBuild,
                    0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return seEjecuto;
        }
    }
}
