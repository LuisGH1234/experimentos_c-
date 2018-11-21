using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNightTestC.Driver;
using OpenQA.Selenium;

namespace MovieNightTestC.Page
{
    class IniciarSesionPage
    {
        private By cajaUsuario = By.Id("campoUsuario");
        private By cajaClave = By.Id("campoClave");
        private By botonIniciarSesion = By.Id("btnIniciarSesion");
        private By mensajeIniciarSesion = By.Id("message-alert");
        private IWebDriver webDriver = null;

        public IniciarSesionPage(string navegador)
        {
            webDriver = MovieDriver.InicializarDriver(navegador);
        }

        public void IngresarPaginaIniciarSesion(string url)
        {
            webDriver.Navigate().GoToUrl(url);
            System.Threading.Thread.Sleep(1000);
        }

        public string IniciarSesion(string usuario, string clave)
        {
            webDriver.FindElement(cajaUsuario).Clear();
            webDriver.FindElement(cajaUsuario).SendKeys(usuario);

            webDriver.FindElement(cajaClave).Clear();
            webDriver.FindElement(cajaClave).SendKeys(clave);

            webDriver.FindElement(botonIniciarSesion).Click();
            System.Threading.Thread.Sleep(2000);

            return webDriver.FindElement(mensajeIniciarSesion).Text;
        }

        public void CerrarPagina() => MovieDriver.CerrarPagina(ref webDriver);

        public ref IWebDriver WebDriver => ref webDriver;
    }
}
