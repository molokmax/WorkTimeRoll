using NUnit.Framework;
using Persist.Database;
using Persist.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersistUnitTest
{
    public class ConnectionTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetByIdTest()
        {
            Assert.Pass();
        }

        [Test]
        public async Task ReadTest()
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder("Test");
            using (IConnection db = new DbConnection(configBuilder.Configuration))
            {
                Type[] tables = new Type[]
                {
                    typeof(ProjectPersistModel)
                };
                await db.CreateDatabase(tables);

                ProjectPersistModel rec1 = new ProjectPersistModel()
                {
                    Name = "Test Project Name 1"
                };
                await db.Insert(rec1);
                ProjectPersistModel rec2 = new ProjectPersistModel()
                {
                    Name = "Test Project Name 2"
                };
                await db.Insert(rec2);

                List<ProjectPersistModel> results = await db.GetAll<ProjectPersistModel>();

                Assert.IsNotNull(results);
                Assert.AreEqual(2, results.Count);
            }
        }
    }
}
