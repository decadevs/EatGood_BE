using Eat_Good_Data.Repositories.Generic.Interface;
using EatGood_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eat_Good_Data.Repositories.Generic.Implementation
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        private readonly EatGood_DBContext _dBContext;

        public UserRepository(EatGood_DBContext dBContext) : base(dBContext)
        {
           _dBContext = dBContext;
        }
    }
}
