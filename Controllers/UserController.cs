using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Api.Data.Collections;
using Api.Models;
using MongoDB.Bson;
namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
       Data.MongoDB _mongoDB;

       IMongoCollection<User> _usersCollections; 

       public UserController(Data.MongoDB mongoDB)
       {
           _mongoDB = mongoDB;
           _usersCollections = _mongoDB.DB.GetCollection<User>(typeof(User).Name.ToLower());
       }

       [HttpPost]
       public ActionResult SaveUser([FromBody] UserDTO dto)
       {

           var user = new User(dto.UserName,dto.Email,dto.Password,dto.Birthday,dto.ProblemsSolved,dto.Problems);

           _usersCollections.InsertOne(user);

           return StatusCode(201,"User saved with success");
       }

       [HttpGet("{email}")]
       public ActionResult GetUserProblems(string email)
       {
           var problems = _usersCollections.Aggregate().Match(c => c.Email.Equals(email)).Project(c=>new{
               Problems = c.Problems
           }).ToList();
           return Ok(problems);
       }

       [HttpPatch("{email}")]
       public ActionResult UpdateUser([FromBody] UserDTO dto)
       {

           _usersCollections.UpdateOne(Builders<User>.Filter.Where(_=>_.Email == dto.Email), Builders<User>.Update.Set("problemsSolved",dto.ProblemsSolved));

           return Ok("Update successful");
       }

       [HttpDelete("{email}")]
       public ActionResult DeleteUser([FromBody] UserDTO dto)
       {
           _usersCollections.DeleteOne(Builders<User>.Filter.Where(_=>_.Email == dto.Email));

            return Ok("Delete successful");
       }
    }
}