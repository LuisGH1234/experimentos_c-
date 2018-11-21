using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace MovieNightTestC.Driver
{
    static class MovieDriver
    {
        public static IWebDriver InicializarDriver(string navegador)
        {
            IWebDriver webDriver = null;
            try
            {
                switch (navegador)
                {
                    case "firefox":
                        webDriver = new FirefoxDriver("E:\\lagh3\\Documents\\2018-2\\Experimentos\\experimentos_c-");
                        break;
                    case "chrome":
                        webDriver = new ChromeDriver("E:\\lagh3\\Documents\\2018-2\\Experimentos\\experimentos_c-");
                        break;
                    case "edge":
                        webDriver = new EdgeDriver("E:\\lagh3\\Documents\\2018-2\\Experimentos\\experimentos_c-");
                        break;
                }
                webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(30);
            } catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return webDriver;
        }

        public static void CerrarPagina(ref IWebDriver webDriver)
        {
            if (webDriver != null)
            {
                webDriver.Close();
            }
        }
    }
}
