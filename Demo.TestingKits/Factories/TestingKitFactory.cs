using Demo.TestingKits.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.TestingKits.Factories
{
    public enum InfectionType
    {
        Chlamydia,
        Gonorrhoea,
        HIV,
        Syphilis
    }

    public class TestingKitFactory
    {

        //Check the types of infection to be tested and add each relevant test to the kit but only once.
        public static TestingKit CreateTestingKit(InfectionType[] infectionsToTest)
        {
            TestingKit kit = new TestingKit();

            foreach (var infection in infectionsToTest)
            {
                switch (infection)
                {
                    case InfectionType.Chlamydia:
                        if (!kit.ContainsUrineTest)
                            kit.AddTestType(TestingKit.TestType.Urine, 1);
                        break;
                    case InfectionType.Gonorrhoea:
                        if (!kit.ContainsUrineTest)
                            kit.AddTestType(TestingKit.TestType.Urine, 1);
                        break;
                    case InfectionType.HIV:
                        if (!kit.ContainsBloodTest)
                            kit.AddTestType(TestingKit.TestType.Blood, 1);
                        break;
                    case InfectionType.Syphilis:
                        if (!kit.ContainsBloodTest)
                            kit.AddTestType(TestingKit.TestType.Blood, 1);
                        break;
                    default:
                        throw new ArgumentException();
                }
            }

            return kit;
        }

        public static bool IsValidPostcode(string postcode, InfectionType[] infectionsToTest)
        {
            HashSet<Tuple<InfectionType, string>> postcodeRestrictions = new HashSet<Tuple<InfectionType, string>>
            {
                new Tuple<InfectionType, string>(InfectionType.Gonorrhoea, "LS1 1AA"),
                new Tuple<InfectionType, string>(InfectionType.HIV, "LS1 1AA"),
                new Tuple<InfectionType, string>(InfectionType.Syphilis, "LS1 1AA")
            };

            foreach (var infection in infectionsToTest)
            {
                switch (infection)
                {
                    case InfectionType.Chlamydia:
                        if (postcodeRestrictions.Contains(new Tuple<InfectionType, string>(InfectionType.Chlamydia, postcode)))
                            return false;
                        break;
                    case InfectionType.Gonorrhoea:
                        if (postcodeRestrictions.Contains(new Tuple<InfectionType, string>(InfectionType.Gonorrhoea, postcode)))
                            return false;
                        break;
                    case InfectionType.HIV:
                        if (postcodeRestrictions.Contains(new Tuple<InfectionType, string>(InfectionType.HIV, postcode)))
                            return false;
                        break;
                    case InfectionType.Syphilis:
                        if (postcodeRestrictions.Contains(new Tuple<InfectionType, string>(InfectionType.Syphilis, postcode)))
                            return false;
                        break;
                    default:
                        throw new ArgumentException();
                }
            }

            return true;
        }
    }
}
