using MyPlayground.Data;
using MyPlayground.DataTransferObjects;
using MyPlayground.NHibernate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;

namespace MyPlayground.Integrationstests.Repository
{
    [TestFixture]
    public class DocumentRepositoryTests
    {
        [Test]
        public void Constructor_Test()
        {
            DocumentRepository repo =
                new DocumentRepository(new SQLiteInMemorySessionFactory(), Mock.Of<ILogger<IDocumentRepository>>());

            Assert.IsNotNull(repo);
        }

        [Test]
        public void GetAll_When_No_Data_In_Db_Test()
        {
            DocumentRepository repo =
                new DocumentRepository(new SQLiteInMemorySessionFactory(),Mock.Of<ILogger<IDocumentRepository>>());

            var documents = repo.GetAll();
            Assert.IsNotNull(documents);
            Assert.AreEqual(0, documents.Count);
        }

        [Test]
        public void Save_Test()
        {
            DocumentRepository repo =
                new DocumentRepository(new SQLiteInMemorySessionFactory(),Mock.Of<ILogger<IDocumentRepository>>());

            var document = new DocumentDto
            {
                Id = 0, 
                Name = "Testdokument",
                Status = 99,
                Paragraphs = new List<DocumentParagraphDto>()
                {
                    new DocumentParagraphDto() { Id = 0, RelationId = 1, Level = 1, Status = 3 },
                    new DocumentParagraphDto() { Id = 0, RelationId = 2, Level = 2, Status = 3 },
                    new DocumentParagraphDto() { Id = 0, RelationId = 3, Level = 3, Status = 3 },
                }
            };

            repo.Save(document);

            var documents = repo.GetAll();
            Assert.AreEqual(1, documents.Count);

            Assert.AreEqual(1, documents[0].Id);
            Assert.AreEqual(document.Name, documents[0].Name);
            Assert.AreEqual(document.Status, documents[0].Status);
        }
    }
}
