using Client.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientGRPCController : ControllerBase
    {
private readonly IGreeterService _IGreeterService;
        public ClientGRPCController(IGreeterService _igreeterService)
        {
            _IGreeterService = _igreeterService;
        }

        [HttpGet("List")]
        public  Users getUserList()
        {
            var authDetails =  _IGreeterService.GetAll();
            return authDetails;
        }


        [HttpPost]
        public  User PostUser(User user)
        {
            var authDetail = _IGreeterService.Post(user);
            return authDetail;           
        }


        [HttpGet("{id}")]
        public  User getUserById(int id)
        {
            var User = _IGreeterService.GetByID(id);
            return User;
        }

[HttpPut("{i}")]
        public User updateSingleUser( int i,User us)
        {
            var re = _IGreeterService.update( i,us);
            return re;
        }

        [HttpDelete("{Id}")]
        public Empty DeleteUser(int Id)
        {
            var us = _IGreeterService.Delete(Id);
            return us;            
        }

        [HttpGet("Calculate/{Id}")]
        public CalculateGrade calculateGradeClient(int Id)
        {
            var us = _IGreeterService.calculategrade(Id);
            return us;
        }

    }
}
