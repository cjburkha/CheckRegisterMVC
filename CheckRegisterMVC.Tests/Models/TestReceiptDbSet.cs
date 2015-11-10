using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckRegisterMVC.Models;
using CheckRegisterMVC.Tests.Models;

namespace CheckRegisterMVC.Tests.Models
{
    class TestReceiptDbSet : TestDbSet<Receipt>
    {
        public override Receipt Find(params object[] keyValues)
        {
            return this.SingleOrDefault(receipt => receipt.ID == (int)keyValues.Single());
        }
    }
}


