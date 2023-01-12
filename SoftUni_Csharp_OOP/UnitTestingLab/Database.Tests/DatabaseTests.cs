using Database;
using NUnit.Framework;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace Database.Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(4)]
        [TestCase(10)]
        [TestCase(16)]
        public void AddElementsShouldAddNewElementLessThan16(int count)
        {
            Database data = new Database();

            for (int i = 0; i < count; i++)
            {
                data.Add(i);
            }

            Assert.AreEqual(data.Count, count);
        }
        [Test]
        [TestCase(1,4)]
        [TestCase(1,16)]
        [TestCase(1,6)]

        public void CtorShouldAddItemsTillTheyrNumberAreBelow16(int start, int count)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();

            Database data = new Database(elements);

           
            Assert.AreEqual(data.Count, count);
        }

        [Test]
        [TestCase(1, 17)]
        [TestCase(1, 25)]
        public void AddElementsShouldTrowInvalidOperationExceptionMoreThan16(int start, int count)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();

            Assert.Throws<InvalidOperationException>(() => new Database(elements));
        }

        [Test]
        [TestCase(1, 10, 1, 9)]
        [TestCase(1, 5, 3, 2)]
        public void RemoveElementsShouldRemoveWhenTheyAreAboveZero(int start, int count, int toRemove, int result)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();

            Database data = new Database(elements);

            for (int i = 0; i < toRemove; i++)
            {
                data.Remove();
            }

            Assert.AreEqual(data.Count, result);

        }

         [Test]
        public void RemoveElementsShouldTrowExeptionLessThanZero()
        { 
            Database data = new Database();

            Assert.Throws<InvalidOperationException>(() => data.Remove());
        }

        [Test]
        public void FetchElementsShouldReturnAllItems()
        {
            Database data = new Database(1, 2, 3);

            data.Add(4);
            data.Add(5);

            data.Remove();
            data.Remove();
            data.Remove();

            int[] fatchetData = data.Fetch();
            int[] expectedData = new int[] {1, 2};

            Assert.AreEqual(fatchetData, expectedData);
        }




    }
}