using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace FT.POS.POSTests
{
    [Table("Pos_Test")]
    public class POSTest : Entity<int>, IMayHaveTenant
    {

        public string Name { get; set; }

        public string Age { get; set; }
        public string Sex { get; set; }

        public string Hight { get; set; }
        public int? TenantId { get; set; }
    }
}
