
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITServices.Framework.Data;

namespace ITServices.Framework.Tests.Data
{

    [TestClass]
    public class PaginatedCollectionTest
    {

        [TestMethod]
        public void PopulatePaginatedFields_HasMorePages_Should_PopulateNext()
        {
            PaginatedCollection<int> collection = new PaginatedCollection<int>();
            collection.Page = 1;
            collection.PerPage = 10;
            collection.TotalRecords = 100;

            Uri base_uri = new Uri("http://www.test.com/v2/employees/ahoheisawesome/?page=1&perpage=10");

            collection.PopulatePaginationFields(base_uri);

            Assert.AreEqual("/v2/employees/ahoheisawesome/?page=2&perpage=10",collection.Next);
        }

        [TestMethod]
        public void PopulatePaginatedFields_HasExactlyOneMorePage_Should_PopulateNext()
        {
            PaginatedCollection<int> collection = new PaginatedCollection<int>();
            collection.Page = 9;
            collection.PerPage = 10;
            collection.TotalRecords = 100;

            Uri base_uri = new Uri("http://www.test.com/v2/employees/ahoheisawesome/?page=9&perpage=10");

            collection.PopulatePaginationFields(base_uri);

            Assert.AreEqual("/v2/employees/ahoheisawesome/?page=10&perpage=10", collection.Next);
        }

        [TestMethod]
        public void PopulatePaginatedFields_HasNoMorePages_ShouldNot_PopulateNext()
        {
            PaginatedCollection<int> collection = new PaginatedCollection<int>();
            collection.Page = 10;
            collection.PerPage = 10;
            collection.TotalRecords = 100;

            Uri base_uri = new Uri("http://www.test.com/v2/employees/ahoheisawesome/?page=10&perpage=10");

            collection.PopulatePaginationFields(base_uri);

            Assert.IsNull(collection.Next);
        }

        [TestMethod]
        public void PopulatePaginatedFields_FirstPage_ShouldNot_PopulatePrevious()
        {
            PaginatedCollection<int> collection = new PaginatedCollection<int>();
            collection.Page = 1;
            collection.PerPage = 10;
            collection.TotalRecords = 100;

            Uri base_uri = new Uri("http://www.test.com/v2/employees/ahoheisawesome/?page=1&perpage=10");

            collection.PopulatePaginationFields(base_uri);

            Assert.IsNull(collection.Previous);
        }

        [TestMethod]
        public void PopulatePaginatedFields_MiddlePages_Should_PopulatePrevious()
        {
            PaginatedCollection<int> collection = new PaginatedCollection<int>();
            collection.Page = 3;
            collection.PerPage = 10;
            collection.TotalRecords = 100;

            Uri base_uri = new Uri("http://www.test.com/v2/employees/ahoheisawesome/?page=3&perpage=10");

            collection.PopulatePaginationFields(base_uri);

            Assert.AreEqual("/v2/employees/ahoheisawesome/?page=2&perpage=10", collection.Previous);
        }

        [TestMethod]
        public void PopulatePaginatedFields_ForAnyPage_Should_PopulateLimit()
        {
            PaginatedCollection<int> collection = new PaginatedCollection<int>();
            collection.Page = 3;
            collection.PerPage = 10;
            collection.TotalRecords = 100;

            Uri base_uri = new Uri("http://www.test.com/v2/employees/ahoheisawesome/?page=3&perpage=10");

            collection.PopulatePaginationFields(base_uri);

            Assert.AreEqual(10, collection.PaginationLimit);
        }

        [TestMethod]
        public void PopulatePaginatedFields_ForAnyPage_Should_PopulateOffset()
        {
            PaginatedCollection<int> collection = new PaginatedCollection<int>();
            collection.Page = 3;
            collection.PerPage = 10;
            collection.TotalRecords = 100;

            Uri base_uri = new Uri("http://www.test.com/v2/employees/ahoheisawesome/?page=3&perpage=10");

            collection.PopulatePaginationFields(base_uri);

            Assert.AreEqual(20, collection.PaginationOffset);
        }

    }
}
