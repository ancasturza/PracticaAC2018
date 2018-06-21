using System.Collections.Generic;

namespace ClassroomTrivia.LessonOne.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
