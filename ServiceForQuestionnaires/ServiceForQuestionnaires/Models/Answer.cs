using System;
using System.Collections.Generic;

namespace ServiceForQuestionnaires.Models
{
    public partial class Answer
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string Texxt { get; set; } = null!;
        public string Deleted { get; set; } = null!;
        public int DeletedByUserId { get; set; }

        public virtual Question AnswerNavigation { get; set; } = null!;
    }
}
