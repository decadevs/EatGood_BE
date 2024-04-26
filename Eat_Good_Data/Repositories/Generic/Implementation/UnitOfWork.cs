using Eat_Good_Data.Repositories.Generic.Interface;
using EatGood_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eat_Good_Data.Repositories.Generic.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EatGood_DBContext _dBContext;

        public UnitOfWork(EatGood_DBContext dBContext)
        {
            _dBContext = dBContext;
            UserRepository = new UserRepository(_dBContext);
             
        }
        public IUserRepository UserRepository { get; set; }
        
        public async Task<int> SaveChangesAsync()
        {
            return await _dBContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dBContext.Dispose();
        }
    }
}
