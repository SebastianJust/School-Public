using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using MSMQ.Api.Models;

namespace MSMQ.Api.Controllers
{
    public class SenderController : ApiController
    {

        private readonly MessageQueue _messageQueue;
        private readonly string _privateQueue;
        public SenderController()
        {
            string privateQueue = @$"{ConfigurationManager.AppSettings["MSMQ_Private_Queue"]}";
            _messageQueue = new MessageQueue(privateQueue);
            _privateQueue = privateQueue;
        }

        [Route("api/send")]
        [HttpPost]
        public async Task<IHttpActionResult> SendMessage(MessageRequestModel request)
        {
            try
            {
                _messageQueue.Send(request.Message, MessageQueueTransactionType.Automatic);

                //Get the message that has been send to the queue.
                return await Task.FromResult(Created(_privateQueue, request));
            }
            catch (Exception e)
            {
                return BadRequest($"{e}");
            }

        }

    }
}
