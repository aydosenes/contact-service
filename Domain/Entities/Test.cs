using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Test : BaseEntity
    {
        public int TestNo { get; set; }
        public string TestName { get; set; }
    }
}
