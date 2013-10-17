using System;
using System.Collections.Generic;
using System.Reflection;

namespace TechTalk.SpecFlow.Assist
{
    public class CSGSetComparer<T> : SetComparer<T>
    {
        private readonly Type _baseType = typeof(SetComparer<T>);

        public CSGSetComparer(Table table)
            : base(table)
        {
        }

        public void CompareToSubSet(IEnumerable<T> subset)
        {
            AssertThatAllColumnsInTheTableMatchToPropertiesOnTheType();
            if (ThereAreNoResultsAndNoExpectedResults(subset))
                return;

            AssertThatTheItemsMatchTheExpectedResults(subset);
        }

        private void AssertThatTheItemsMatchTheExpectedResults(IEnumerable<T> subset)
        {
            CallPrivateBaseMethod("AssertThatTheItemsMatchTheExpectedResults", subset);
        }

        private bool ThereAreNoResultsAndNoExpectedResults(IEnumerable<T> subset)
        {
            return (bool)CallPrivateBaseMethod("ThereAreNoResultsAndNoExpectedResults", subset);
        }

        private void AssertThatAllColumnsInTheTableMatchToPropertiesOnTheType()
        {
            CallPrivateBaseMethod("AssertThatAllColumnsInTheTableMatchToPropertiesOnTheType");
        }

        private object CallPrivateBaseMethod(string methodName, params object[] args)
        {
            try
            {
                var method = _baseType.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
                return method.Invoke(this, args);
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
