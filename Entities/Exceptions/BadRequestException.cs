using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public abstract class BadRequestException : Exception // bu sınıf newlenmez. Bu sınıftan türeyecek elemanlar newlenecek. Abstract class'lar newlenemez!!!
    {// BadRequest için genel bir sınıf!
        protected BadRequestException(string message): base(message)
        {

        }
    }
}
