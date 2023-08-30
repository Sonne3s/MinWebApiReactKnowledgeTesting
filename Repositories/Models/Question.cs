using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; }

        public User User { get; set; }

        public Section Section { get; set; }

        public Topic Topic { get; set; }
    }
}
