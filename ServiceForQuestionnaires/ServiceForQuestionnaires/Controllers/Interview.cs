namespace Api.Controllers
{
    public class Interview
    {
        public int Id { get; set; }
        public string InterviewName { get; set; }//название интервью
        public int QuestionID { get; set; }//id вопроса
        public int AnswerID { get; set; }//id ответа
        public int MaxAnswers { get; set; }//максимальное кол-во ответов
        public int UserID { get; set; }//id пользователя который создал интервью
        public bool Deleted { get; set; }//удален
        public int DeletedByUserID { get; set; }//id юзера который удалил интервью

    }
}