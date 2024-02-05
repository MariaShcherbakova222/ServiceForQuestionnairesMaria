namespace Api.Controllers
{
    public class Answer
    {
        public int AnswerId { get; set; }//id ответа
        public int QuestionID { get; set; }//id вопроса
        public int Texxt { get; set; }//текст ответа
        public bool Deleted { get; set; }//удален
        public int DeletedByUserID { get; set; }//id юзера который удалил ответ

    }
}