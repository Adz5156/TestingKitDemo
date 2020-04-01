using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.TestingKits.Entites
{
    public class TestingKit
    {
        public TestingKit()
        {
            TestTypes = new Dictionary<TestType, int>();
        }

        public enum TestType 
        { 
            Blood,
            Urine
        }

        public Guid Uid => Guid.NewGuid();
        public Dictionary<TestType, int> TestTypes { get; set; }

        public bool ContainsBloodTest => TestTypes.ContainsKey(TestType.Blood);
        public bool ContainsUrineTest => TestTypes.ContainsKey(TestType.Urine);

        public void AddTestType(TestType testType, int quantity)
        {
            TestTypes[testType] = quantity;
        }

    }
}
