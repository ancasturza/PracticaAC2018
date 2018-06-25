﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomTrivia.LessonThree.Data.Entities
{
    public class Answer
    {
        public int AnswerId { get; set; }
        [Required]
        [MaxLength(500)]
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
    }
}
