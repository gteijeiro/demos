using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoAgenda.Data;
using System.Linq;

namespace DemoAgenda.Test
{
    [TestClass]
    public class Test_Data_AgendaRepository
    {
        [TestMethod]
        public void Test_Data_AgendaRepository_Add()
        {
            try
            {
                IAgendaRepository agenda = new AgendaRepository();

                agenda.Add(new Entities.AgendaBE()
                {
                    Firtname = "Guillermo",
                    Lastname = "Teijeiro",
                    Number = "3517337133",
                    User = "gteijeiro@outlok.com" 
                });
            }
            catch(Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Test_Data_AgendaRepository_GetAll_By_User()
        {
            try
            {
                IAgendaRepository agenda = new AgendaRepository();

                var result = agenda.GetAllByUser("gteijeiro@outlook.com");

                Assert.IsNotNull(result);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Test_Data_AgendaRepository_Get_By_Id()
        {
            try
            {
                IAgendaRepository agenda = new AgendaRepository();

                var result = agenda.GetById(1);

                Assert.IsNotNull(result);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Test_Data_AgendaRepository_Update()
        {
            try
            {
                IAgendaRepository agenda = new AgendaRepository();

                var result = agenda.GetById(1);
                Assert.IsNotNull(result);

                result.Lastname = "Teijero";
                agenda.Update(result);

                var resultChanges = agenda.GetById(1);
                Assert.IsTrue(resultChanges.Lastname.Equals("Teijero"));
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Test_Data_AgendaRepository_Delete()
        {
            try
            {
                IAgendaRepository agenda = new AgendaRepository();

                agenda.Add(new Entities.AgendaBE()
                {
                    Firtname = "PRUEBA01",
                    Lastname = "PRUEBA01",
                    Number = "3517337133",
                    User = "PRUEBA01@outlok.com"
                });

                var agendaByUser = agenda.GetAllByUser("PRUEBA01@outlok.com").FirstOrDefault();

                agenda.Delete(agendaByUser);

                var agendaByUserDelete = agenda.GetAllByUser("PRUEBA01@outlok.com").FirstOrDefault();

                Assert.IsNull(agendaByUserDelete);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
