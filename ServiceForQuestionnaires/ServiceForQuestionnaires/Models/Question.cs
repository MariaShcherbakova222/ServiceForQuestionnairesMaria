using System;
using System.Collections.Generic;

namespace ServiceForQuestionnaires.Models
{
    public partial class Question
    {
        public int Id { get; set; }
        public int InterviewId { get; set; }
        public string Requiired { get; set; } = null!;
        public string Texxt { get; set; } = null!;
        public string Deleted { get; set; } = null!;
        public int DeletedByUserId { get; set; }

        public virtual Interview Interview { get; set; } = null!;
        public virtual Answer Answer { get; set; } = null!;
    }
}
