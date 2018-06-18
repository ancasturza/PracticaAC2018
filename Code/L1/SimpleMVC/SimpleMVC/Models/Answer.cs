using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMVC.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
