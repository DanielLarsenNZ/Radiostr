using System.Collections.Generic;
using System.Linq;

namespace Radiostr.Results
{
    public class Result
    {
        public Result()
        {
            Messages = new List<string> {null};
        }

        public bool Ok { get; set; }

        public string Message
        {
            get { return Messages[0]; }
            set { Messages[0] = value; }
        }

        public List<string> Messages { get; set; } 
    }
}