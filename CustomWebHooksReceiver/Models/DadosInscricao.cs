using System.Collections.Generic;

namespace CustomWebHooksReceiver.Models
{
    public class DadosInscricao
    {
        public string WebHookUri { get; set; }
        public string Secret { get; set; }
        public string Description { get; set; }
        public ISet<string> Filters { get; set; }
    }
}