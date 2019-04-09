using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreHelloWorld
{
    [Controller]
    public class Teste
    // public class TesteController
    // public class Teste: Controller
    {

        public string Ping() => "Pong";

    }
}
