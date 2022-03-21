using IMS.Application.Common.Wrappers;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Common.Behaviours
{
    public class ErrorHandlingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> 
        where TResponse : BaseResponse
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var baseResponse =  (TResponse) Activator.CreateInstance(typeof(TResponse));

                baseResponse.Succeeded = false;
                baseResponse.Message = ex.Message;

                return baseResponse;
            }
        }
    }
}
