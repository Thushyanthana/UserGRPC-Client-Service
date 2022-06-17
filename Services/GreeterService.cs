using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using userGRPC;
using userGRPC.ResponseModel.cs;

namespace Client.Services
{
    public class GreeterService: IGreeterService
    {
        private readonly userService.userServiceClient _userService;

         public GreeterService(userService.userServiceClient _userServ)
        {
           _userService = _userServ;              
        }
        

        public  User Post(User us)
        {
            try
            {
                User response1 = _userService.Post(new User()
                {
                    NameWithInitail = us.NameWithInitail,
                    Mark1 = us.Mark1,
                    Mark2 = us.Mark2,
                    Mark3 = us.Mark3,
                    Position = us.Position
                });
                return response1;
            }
            catch (Exception e)
            {
                throw;
            }
           
        }


        //GetAll
        public Users GetAll()
        {
            var users = _userService.Get(new Client.Empty());
            return users;
        }


        //GetByID
        public  User GetByID(int id)
        {       
            User use = _userService.GetByID(new UserRowIdFilter() { Id = id });
            return use;
        }

        //update 
        public  User update(int id,User us)
        {
            User use = _userService.GetByID(new UserRowIdFilter() { Id = id });
            use.NameWithInitail = us.NameWithInitail;
            use.Mark1 = us.Mark1;
            use.Mark2 = us.Mark2;
            use.Mark3 = us.Mark3;
            use.Position = us.Position;
            User response2 = _userService.Put(use);
            return use;
        }

        //Delete
        public  Empty Delete(int i)
        {
            var x = new UserRowIdFilter()
            {
                Id =i
            };
            Client.Empty response3 = _userService.Delete(x);
            return response3;
        }

        //CalculateGrade
        public CalculateGrade calculategrade(int i)
        {
            var x = new UserRowIdFilter()
            {
                Id = i
            };
            CalculateGrade response3 = _userService.Calculate(x);
            return response3;
        }



    }
}
