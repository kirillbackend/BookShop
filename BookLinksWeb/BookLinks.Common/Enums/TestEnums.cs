using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLinks.Common.Enums
{
    public enum TestEnums
    {
        [Display(Name = "Ivan")]
        Ivan = 0,
        [Display(Name = "Olga")]
        Olga = 1,
        [Display(Name = "Petr")]
        Petr = 2,
    }
}
