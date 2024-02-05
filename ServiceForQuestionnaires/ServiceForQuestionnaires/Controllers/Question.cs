namespace Api.Controllers
{
    public class Question
    {
        public int ID { get; set; }
        public int InterviewId { get; set; }//id интервью
        public int Requiired { get; set; }//важность вопроса
        public int Texxt { get; set; }//текст вопроса
        public bool Deleted { get; set; }//удален
        public int DeletedByUserID { get; set; }//id юзера который удалил вопрос
        


    }
}