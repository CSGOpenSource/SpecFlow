using System;
using System.Globalization;
using System.Threading;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.RuntimeTests.AssistTests.TestInfrastructure;

namespace TechTalk.SpecFlow.RuntimeTests.AssistTests
{
    [TestFixture]
    public class SetComparerTests
    {
        private Guid testGuid1 = Guid.NewGuid();
        private Guid testGuid2 = Guid.NewGuid();

        [SetUp]
        public void SetUp()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }

        [Test]
        public void Table_with_subset_of_rows_compared_to_superset_collection()
        {
            var set = new[]
            {
                new SetComparisonTestObject
                {
                    DateTimeProperty = DateTime.Today,
                    GuidProperty = testGuid1,
                    IntProperty = 1,
                    StringProperty = "a"
                },
                new SetComparisonTestObject
                {
                    DateTimeProperty = DateTime.Today,
                    GuidProperty = testGuid2,
                    IntProperty = 2,
                    StringProperty = "b"
                },
                new SetComparisonTestObject
                {
                    DateTimeProperty = DateTime.Today.AddDays(1),
                    GuidProperty = Guid.NewGuid(),
                    IntProperty = 4,
                    StringProperty = "c"
                },
            };

            var subsetTable = CreateTableWithAllColumns();
            subsetTable.AddRow(set[0].DateTimeProperty.ToString(), set[0].GuidProperty.ToString(), set[0].IntProperty.ToString(), set[0].StringProperty);
            subsetTable.AddRow(set[1].DateTimeProperty.ToString(), set[1].GuidProperty.ToString(), set[1].IntProperty.ToString(), set[1].StringProperty);
            
            var comparer = new SetComparer<SetComparisonTestObject>(subsetTable);
            comparer.CompareToSuperSet(set);
        }

        [Test]
        [ExpectedException(typeof(ComparisonException))]
        public void Table_with_extra_rows_should_fail_compared_to_superset_collection()
        {
            var set = new[]
            {
                new SetComparisonTestObject
                {
                    DateTimeProperty = DateTime.Today,
                    GuidProperty = testGuid1,
                    IntProperty = 1,
                    StringProperty = "a"
                },
                new SetComparisonTestObject
                {
                    DateTimeProperty = DateTime.Today,
                    GuidProperty = testGuid2,
                    IntProperty = 2,
                    StringProperty = "b"
                },
            };

            var subsetTable = CreateTableWithAllColumns();
            subsetTable.AddRow(set[0].DateTimeProperty.ToString(), set[0].GuidProperty.ToString(), set[0].IntProperty.ToString(), set[0].StringProperty);
            subsetTable.AddRow(set[1].DateTimeProperty.ToString(), set[1].GuidProperty.ToString(), set[1].IntProperty.ToString(), set[1].StringProperty);
            subsetTable.AddRow(DateTime.Now.ToString(), Guid.NewGuid().ToString(), 1.ToString(), "c");

            var comparer = new SetComparer<SetComparisonTestObject>(subsetTable);
            comparer.CompareToSuperSet(set);
        }

        private Table CreateTableWithAllColumns()
        {
            return new Table("DateTimeProperty", "GuidProperty", "IntProperty", "StringProperty");
        }
    }

}
