using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Organizer;

namespace BornToMove.OrganizerTest
{
    internal class RotateSortTest
    {
        private RotateSort<int> _sut; // s.u.t. == System Under Test

        [SetUp]
        public void SetUpMyTest()
        {
            _sut = new RotateSort<int>();
        }

        private static object[][] HappyFlowValues()
        {
            return new object[][]
            {
                new List<int>[]    { new List<int>(),                    new List<int>    { } }, // Empty
                new List<int>[]    { new List<int>    { 36 },            new List<int>    { 36 } }, // One element
                new List<int>[]    { new List<int>    { 76, 43 },        new List<int>    { 43, 76 } }, // Two elements
                new List<int>[]    { new List<int>()  { 3, 3, 3 },       new List<int>    { 3, 3, 3 } }, // Three equal elements
                new List<double>[] { new List<double> { 4.3, 1.3, 4.1},  new List<double> { 1.3, 4.1, 4.3} } // Doubles
            };
        }

        [TestCaseSource(nameof(HappyFlowValues))]
        public void TestSort_HappyFlow<T>(List<T> input, List<T> expectedResult) where T : INumber<T>
        {
            //prepare
            var sorter = new RotateSort<T>();
            var numItems = input.Count;

            //run
            var result = sorter.Sort(input, Comparer<T>.Default);

            //validate
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Exactly(numItems).Items);
            Assert.That(result, Is.EquivalentTo(expectedResult));
        }

        /*[Test]
        public void TestSort_Empty()
        {
            //prepare
            var input = new List<int>();

            //run
            var result = _sut.Sort(input, Comparer<int>.Default);

            //validate
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Exactly(0).Items);
            Assert.That(result, Is.EquivalentTo(Array.Empty<int>()));

        }

        [Test]
        public void TestSort_OneElement()
        {
            //prepare
            var input = new List<int>() { 36 };

            //run
            var result = _sut.Sort(input, Comparer<int>.Default);

            //validate
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Exactly(1).Items);
            Assert.That(result, Is.EquivalentTo(new List<int> { 36 }));
        }

        [Test]
        public void TestSort_TwoElements()
        {
            //prepare
            var input = new List<int>() { 32, 3 };

            //run
            var result = _sut.Sort(input, Comparer<int>.Default);

            //validate
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Exactly(2).Items);
            Assert.That(result, Is.EquivalentTo(new int[] { 32, 3 }));

            // also check that our input is not modified
            Assert.That(input, Is.EquivalentTo(new int[] { 3, 32 }));
        }

        [Test]
        public void TestSort_ThreeEqual()
        {
            //prepare
            var input = new List<int>() { 3, 3, 3 };

            //run
            var result = _sut.Sort(input, Comparer<int>.Default);

            //validate
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Exactly(3).Items);
            Assert.That(result, Is.EquivalentTo(new int[] { 3, 3, 3 }));

        }*/

        [Test]
        public void TestSort_ThreeUnsorted()
        {
            //prepare
            var input = new List<int>() { 7, 3, 5 };

            //run
            var result = _sut.Sort(input, Comparer<int>.Default);

            //validate
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Exactly(3).Items);
            Assert.That(result, Is.EquivalentTo(new int[] { 3, 5, 7 }));
            Assert.That(input, Is.EquivalentTo(new int[] { 7, 3, 5 }));
        }

        [Test]
        public void TestSort_SevenUnsortedThreeEqual()
        {
            //prepare
            var input = new List<int>() { 3, 5, 1, 3, 8, 2, 3 };

            //run
            var result = _sut.Sort(input, Comparer<int>.Default);

            //validate
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Exactly(7).Items);
            Assert.That(result, Is.EquivalentTo(new int[] { 1, 2, 3, 3, 3, 5, 8 }));
            Assert.That(input, Is.EquivalentTo(new int[] { 3, 5, 1, 3, 8, 2, 3 }));
        }

    }
}
