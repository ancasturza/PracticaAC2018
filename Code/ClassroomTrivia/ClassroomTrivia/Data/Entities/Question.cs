using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomTrivia.Data.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
