using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceForQuestionnairesController : ControllerBase
    {

        private static List<User_> Users = new List<User_>();
        private static List<Question> Questions = new List<Question>();
        private static List<Answer> Answers = new List<Answer>();
        private static List<Interview> Interviews = new List<Interview>();


        private readonly ILogger<ServiceForQuestionnairesController> _logger;


        public ServiceForQuestionnairesController(ILogger<ServiceForQuestionnairesController> logger)
        {
            _logger = logger;
        }
        // –егистраци€ пользовател€
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] User_ newUser)
        {
            if (newUser.Id < 0)
            {
                return BadRequest("Invalid user ID");
            }

            Users.Add(newUser);
            return Ok(newUser);
        }

        // јвторизаци€ пользовател€ 
        [HttpPost("login")]
        public ActionResult LoginUser([FromBody] User_ loginUser)
        {
            var user = Users.FirstOrDefault(u => u.Email == loginUser.Email && u.Pasword == loginUser.Pasword);
            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }

        //поиск пользовател€ по id
        [HttpGet("user/getID")]
        public IActionResult GetUser(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }

        //обновление информации пользовател€
        [HttpPut("user/updateuser/{userId}")]
        public IActionResult UpdateUser(int userId, [FromBody] User_ user)
        {
            if (userId < 0 || user.Id < 0)
            {
                return BadRequest("Invalid user ID");
            }

            var existingUser = Users.FirstOrDefault(u => u.Id == userId);
            if (existingUser == null)
            {
                return NotFound("User not found");
            }

            existingUser.Namee = user.Namee;
            existingUser.Email = user.Email;
            existingUser.Pasword = user.Pasword;

            return Ok(existingUser);
        }

        //поиск по интерьвю
        [HttpGet("searchInterview")]
        public IActionResult SearchByInterview([FromQuery] string interviewName)
        {
            var Interview = Interviews.Where(i => i.InterviewName == interviewName).ToList();
            return Ok(interviewName);
        }


        // —оздание вопроса
        [HttpPost("Question")]
        public IActionResult CreateQuestion([FromBody] Question newQuestion)
        {
            newQuestion.InterviewId = 1;//пример пользователь€ с 1 Id
            Questions.Add(newQuestion);
            return Ok(newQuestion);
        }
        //создание ответа
        [HttpPost("Answer")]
        public IActionResult CreateAnswer([FromBody] Answer newAnswer)
        {
            newAnswer.QuestionID = 1; //пример пользователь€ с 1 Id
            Answers.Add(newAnswer);
            return Ok(newAnswer);
        }

        // ћетод поиска интервью по указываемому имени

        [HttpGet("Interview/checkInterviewName")]
        public IActionResult CheckInterviewName([FromQuery] string interviewName)
        {
            var hasInterview = Interviews.Any(i => i.InterviewName == interviewName);

            if (hasInterview)
            {
                return Ok("«апись с указанным именем интервью имеетс€ в нашем списке");
            }
            else
            {
                return Ok("«апись с указанным именем интервью не обнаружена");
            }
        }

        // ћ€гкое удаление интервью

        [HttpDelete("Interview/delete")]
        public IActionResult SoftDeleteInterview(int InterviewId)
        {
            var interview = Interviews.FirstOrDefault(i => i.Id == InterviewId);
            if (interview == null)
            {
                return NotFound("Interview not found");
            }

            interview.Deleted = true;
            interview.DeletedByUserID = 1;//пример пользователь€ с 1 Id

            return Ok("Interview soft deleted");
        }

        // ћ€гкое удаление впороса

        [HttpDelete("Question/delete")]
        public IActionResult SoftDeleteQuestion(int QuestionId)
        {
            var question = Questions.FirstOrDefault(q => q.ID == QuestionId);
            if (question == null)
            {
                return NotFound("Question not found");
            }

            question.Deleted = true;
            question.DeletedByUserID = 1;//пример пользователь€ с 1 Id

            return Ok("Question soft deleted");
        }


        // ћ€гкое удаление ответа
        [HttpDelete("Answer/delete")]
        public IActionResult SoftDeleteAnswer(int AnswerId)
        {
            var answer = Answers.FirstOrDefault(a => a.AnswerId == AnswerId);
            if (answer == null)
            {
                return NotFound("Answer not found");
            }

            answer.Deleted = true;
            answer.DeletedByUserID = 1;//пример пользователь€ с 1 Id


            return Ok("Answer soft deleted");
        }




    }


}
