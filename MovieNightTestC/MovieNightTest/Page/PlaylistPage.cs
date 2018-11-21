using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNightTestC.Driver;
using OpenQA.Selenium;

namespace MovieNightTestC.Page
{
    class PlaylistPage
    {
        private By campoNombre = By.Id("campoNombre");
        private By campoDescripcion = By.Id("campoDescripcion");
        private By botonGuardar = By.Id("btnGuardar");
        private By botonEliminar = By.Id("delete-0");
        private By botonEditar = By.Id("edit-0");
        private By botonFavorito = By.Id("isFavorite-0");
        private By mensajeRequest = By.Id("mensajeRequest");
        private By navPlaylistRoute = By.Id("playlistRoute");
        private IWebDriver webDriver = null;

        public PlaylistPage(ref IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void IrPlaylistRoute()
        {
            webDriver.FindElement(navPlaylistRoute).Click();
            System.Threading.Thread.Sleep(2000);
        }

        public void EscribirCampoNombre(string nombre)
        {
            webDriver.FindElement(campoNombre).Clear();
            webDriver.FindElement(campoNombre).SendKeys(nombre);
        }

        public void EscribirCampoDescripcion(string descripcion)
        {
            webDriver.FindElement(campoDescripcion).Clear();
            webDriver.FindElement(campoDescripcion).SendKeys(descripcion);
        }

        public string HacerClickBotonGuardar()
        {
            webDriver.FindElement(botonGuardar).Click();
            System.Threading.Thread.Sleep(2000);
            return webDriver.FindElement(mensajeRequest).Text;
        }

        public void HacerClickBotonEditar()
        {
            webDriver.FindElement(botonEditar).Click();
            System.Threading.Thread.Sleep(2000);
        }

        public string HacerClickBotonEliminar()
        {
            webDriver.FindElement(botonEliminar).Click();
            System.Threading.Thread.Sleep(2000);
            return webDriver.FindElement(mensajeRequest).Text;
        }

        public bool HacerClickBotonFavorito()
        {
            string srcInicial = webDriver.FindElement(botonFavorito).GetAttribute("src");
            webDriver.FindElement(botonFavorito).Click();
            System.Threading.Thread.Sleep(2000);
            return webDriver.FindElement(botonFavorito).GetAttribute("src") != srcInicial;
        }

        public void CerrarPagina()
        {
            MovieDriver.CerrarPagina(ref webDriver);
        }

        public ref IWebDriver GetWebDriver()
        {
            return ref webDriver;
        }
    }
}
