using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Services
{
 public   interface IGreeterService
    {
        User Post(User us);
        Users GetAll();
        User GetByID(int id);
        User update(int id, User us);
        Empty Delete(int i);
        CalculateGrade calculategrade(int i);
    }
}
