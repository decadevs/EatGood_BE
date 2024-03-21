using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eat_Good_Data
{
    public class EatGood_DBContext :DbContext
    {
        public EatGood_DBContext(DbContextOptions<EatGood_DBContext> options) : base(options)
        {
            
        }


    }
}
