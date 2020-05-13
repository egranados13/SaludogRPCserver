using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcGreeter
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        int calculo;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {

            calculo = Int32.Parse(request.Edad) + 10;
            
            return Task.FromResult(new HelloReply
            {
                
                Message = "Hola " + request.Name + " con apellido " + request.Apellido + " y edad:" + request.Edad,
                Suma = "Dentro de 10 tendra:"  + calculo
                
            });
        }
    }
}
