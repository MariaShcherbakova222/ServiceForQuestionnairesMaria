using System;
using System.Collections.Generic;

namespace ServiceForQuestionnaires.Models
{
    public partial class Interview
    {
        public Interview()
        {
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string InterviewName { get; set; } = null!;
        public int MaxAnswers { get; set; }
        public int UserId { get; set; }
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string Deleted { get; set; } = null!;
        public int DeletedByUserId { get; set; }

        public virtual User IdNavigation { get; set; } = null!;
        public virtual ICollection<Question> Questions { get; set; }
    }
}
