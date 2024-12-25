using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagamentShared.Models
{
    public class SystemCodeDetails
    {
        [Key]
        public int Id { get; set; }

        public int SystemCodeId { get; set; }

        public SystemeCode SystemCode { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public int? OrderNo { get; set; }
    }
}
