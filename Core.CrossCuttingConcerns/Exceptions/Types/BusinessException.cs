using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions.Types;

public class BusinessException:Exception
{
    public BusinessException()
    {
        
    }

    public BusinessException(string? message):base(message) //yukarıdai Exception'un ctor'unda mevcut, yani mesajı base de gönderiyoruz
    {      
    }

    public BusinessException(string? message,Exception? innerexception) : base(message,innerexception) { }
}
