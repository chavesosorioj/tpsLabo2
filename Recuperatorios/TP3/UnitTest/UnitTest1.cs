using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using Excepciones;
using EntidadesAbstractas;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
           //al menos un metodo que valide se haya instanciado un atributo de tipo colection en alguna de las clases dadas


        /// <summary>
        /// Testea se lance AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        
        public void AlumnoRepetidoTest()
        {
            Alumno a1 = new Alumno(3, "José", "Gutierrez", "12234456",
               EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
               Alumno.EEstadoCuenta.Becado);
            Alumno a2 = new Alumno(3, "José", "Gutierrez", "12234456",
               EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
               Alumno.EEstadoCuenta.Becado);
            Universidad auxUni = new Universidad();
            try
            {
                auxUni += a1;
                auxUni += a2;
            }
            catch (Exception e)
            {

                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
            
        }

        /// <summary>
        /// Testea se lance DniInvalidoException
        /// </summary>
        [TestMethod]

        public void DniInvalidoTest()
        {
            try
            {
                Alumno a1 = new Alumno(3, "José", "Gutierrez", "33333tt3",
                  EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                  Alumno.EEstadoCuenta.Becado);

            }
            catch (Exception e)
            {

                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        /// <summary>
        /// Testea se Inicialice una lista de profesores
        /// </summary>
        [TestMethod]

        public void InstanciaInstructoresTest()
        {
            Profesor auxProf = new Profesor(2,"Draco", "Draquin","32000000", Persona.ENacionalidad.Argentino);
            
            Universidad auxUni = new Universidad();

            auxUni += auxProf;

            Assert.IsNotNull(auxUni.Instructores);
        }
    }
}
