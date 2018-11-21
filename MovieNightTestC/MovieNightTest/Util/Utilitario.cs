using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNightTest.Util
{
    public static class Utilitario
    {
        public static void CaputarPantallarError(string rutaCarpeta, string mensajeError, ref IWebDriver webDriver)
        {
            try
            {
                Console.WriteLine("UTILITARIO");
                string nombreArchivo = DateTime.Now.ToString("dd-MMMM-yyyy_HH-mm-ss");
                Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();
                ss.SaveAsFile(rutaCarpeta + "\\" + nombreArchivo + ".png", ScreenshotImageFormat.Png);
                using (StreamWriter sw = File.CreateText(rutaCarpeta + "\\" + nombreArchivo + ".txt"))
                {
                    sw.WriteLine(mensajeError);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
