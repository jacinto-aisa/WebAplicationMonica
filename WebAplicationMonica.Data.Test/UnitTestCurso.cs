using Microsoft.AspNetCore.Mvc;
using WebAplicationMonica.Controllers;
using WebAplicationMonica.Services;
using WebAplicationMonica.Models;
using WebAplicationMonica.CrossCuting.Logging;

namespace WebAplicationMonica.Data.Test
{
    [TestClass]
    public class UnitTestCurso
    {
        readonly CursosController controlador = new(new FakeRepositorioCurso(),new LoggerManager());

        [TestMethod]
        public void PruebaCursosDetallesVistaEncontrado()
        {
            var result = controlador.Details(2) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var curso = result.ViewData.Model as Curso;
            Assert.IsNotNull(curso);
            Assert.AreEqual("Curso de Frances", curso.Name);
        }
        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void PruebaCursosDetallesVistaNoEncontrado()
        {
            var result = controlador.Details(4) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var curso = result.ViewData.Model as Curso;
            Assert.IsNotNull(curso);
            Assert.AreEqual("Curso de Frances", curso.Name);
        }
        [TestMethod]
        public void PruebaCursosIndexVistaOk()
        {
            var result = controlador.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var listaCursos = result.ViewData.Model as List<Curso>;
            Assert.IsNotNull(listaCursos);
            Assert.AreEqual(3, listaCursos.Count);
        }

    }
}