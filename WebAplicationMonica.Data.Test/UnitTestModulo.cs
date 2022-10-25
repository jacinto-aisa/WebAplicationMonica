using Microsoft.AspNetCore.Mvc;
using WebAplicationMonica.Controllers;
using WebAplicationMonica.Services;
using WebAplicationMonica.Models;
using WebAplicationMonica.CrossCuting.Logging;

namespace WebAplicationMonica.Data.Test
{
    [TestClass]
    public class UnitTestModulo
    {
        readonly ModulosController controlador = new(new FakeRepositorioModulo(),new LoggerManager());

        [TestMethod]
        public void PruebaModulosDetallesVistaEncontrado()
        {
            var result = controlador.Details(2) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var modulo = result.ViewData.Model as Modulo;
            Assert.IsNotNull(modulo);
            Assert.AreEqual("Modulo Letters", modulo.Name);
        }
        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void PruebaModulosDetallesVistaNoEncontrado()
        {
            var result = controlador.Details(9) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var modulo = result.ViewData.Model as Modulo;
            Assert.IsNotNull(modulo);
            Assert.AreEqual("Curso de Frances", modulo.Name);
        }
        [TestMethod]
        public void PruebaModulosIndexVistaOk()
        {
            var result = controlador.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var listaModulos = result.ViewData.Model as List<Modulo>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(6, listaModulos.Count);
        }

    }
}