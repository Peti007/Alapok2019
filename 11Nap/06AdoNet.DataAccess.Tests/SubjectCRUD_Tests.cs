using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06AdoNet.DataAccess.Tests
{
    [TestClass]
    public class SubjectCRUD_Tests
    {
        private readonly string connectionString = "Server=.\\SQLEXPRESS;Database=CodeFirstDB;Trusted_Connection=True;";

        [TestMethod]
        public void TeacherReadId1_ShouldNotNull()
        {
            ///AAA: Act, Arrange, Assert
            
            ///Act: Előkészítés
            var dal = new DataAccessLayer(connectionString);

            //Arrange: feladat elvégzése
            var teacher = dal.TeacherRead(1);

            //Assert: eredmény ellenőrzése
            Assert.IsNotNull(teacher);
            Assert.AreEqual("Matektanár", teacher.TeacherName);
            Assert.AreEqual(1, teacher.Id);

        }

        [TestMethod]
        public void TeacherReadId1_ShouldNull()
        {
           
            var dal = new DataAccessLayer(connectionString);

            //Arrange: feladat elvégzése
            var teacher = dal.TeacherRead(0);

            //Assert: eredmény ellenőrzése
            Assert.IsNull(teacher);
          

        }

        [TestMethod]
        public void TeacherCreate()
        {
            //Act
            var dal = new DataAccessLayer(connectionString);
            var teacherToCreate = new Teacher() { TeacherName = "Magyar Nyelv és Irodalom" };

            //Arrange
            int id = dal.TeacherCreate(teacherToCreate);

            //Assert
            //mivel az adatbázis indentity 1-ről indulm 0-val jelezhetem a hibát a Create függvényből
            //ha 0-val jön vissza akkor nem sikerült a felvitel
            Assert.AreNotEqual(0, id);


            // második körös ellenörzés
            var createdTeacher = dal.TeacherRead(id);
            //Assert: eredmény ellenőrzése
            Assert.IsNotNull(createdTeacher);
            Assert.AreEqual("Magyar Nyelv és Irodalom", createdTeacher.TeacherName);
            Assert.AreEqual(id, createdTeacher.Id);
        }


    }
}
