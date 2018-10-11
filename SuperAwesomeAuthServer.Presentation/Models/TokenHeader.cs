using System;

namespace SuperAwesomeAuthServer.Presentation.Models
{
    public sealed class TokenHeader
    {
        public string Alg { get; set; }
        public string Typ { get; set; }
    }
}
