using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLinks.Common.Enums
{
    public enum BookOptiosEnum
    {
        [Display(Name = "Идентификатор")]
        id = 0,
        [Display(Name = "Название")]
        Name = 1,
        [Display(Name = "Описание")]
        Description = 2,
        [Display(Name = "Автор")]
        Author = 3
    }
}
