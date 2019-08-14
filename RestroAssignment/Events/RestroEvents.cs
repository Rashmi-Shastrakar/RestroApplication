using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestroAssignment.Events
{
    public delegate string Message(string message);
    class RestroEvents
    {

        event Message MessageService;
        public RestroEvents()
        {
            this.MessageService += new Message(this.SendMessage);
        }
        public string SendMessage(string customerName)
        {
            return $"Message is sent to Customer -{customerName} \n Visit Again";
        }
    }
}
