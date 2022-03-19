using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MayorAssistantApp.Models.ChatBotModels
{
    public class QA
    {
        public int QAId { get; set; }
        public string QAText { get; set; }
        public int QAResponseId { get; set; }
        public string Context { get; set; }

        public string FlowId { get; set; }

        
        public int ComponentType { get; set; }

        public string ComponentGroupId { get; set; }

        public List<string> Keywords { get; set; }
    }
}

