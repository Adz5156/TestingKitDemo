using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.TestingKits.Entites
{
    public class Order
    {
        public Guid OrderId => Guid.NewGuid();

        public string Name { get; set; }

        public string HouseNameOrNo { get; set; }

        public string Street { get; set; }

        public string PostCode { get; set; }

        public string Email { get; set; }

        public string TelephoneNo { get; set; }

        public Guid TestingKitUid { get; set; }
        public TestingKit TestingKit { get; set; }

    }
}
