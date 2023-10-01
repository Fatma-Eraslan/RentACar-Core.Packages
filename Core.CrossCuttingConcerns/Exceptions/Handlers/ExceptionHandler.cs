using Core.CrossCuttingConcerns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions.Handlers;

public abstract class ExceptionHandler//gelecek olan hataları handle edecek class
{
    public Task HandleExceptionAsync(Exception exception) => exception switch//exception için switch et
    {
        BusinessException businessException => HandleException(businessException),
        ValidationException validationException => HandleException(validationException),
        _ => HandleException(exception)// _ yani bir şey verilmezse, yukarıdaki hatalardan farklı bir şeyse exception u bas
    };

    protected abstract Task HandleException(BusinessException businessException);//inherit eden class kullanabilsin(inherit edebilen de zorunlu etsin)

    protected abstract Task HandleException(ValidationException validationException);

    protected abstract Task HandleException(Exception exception);



}
