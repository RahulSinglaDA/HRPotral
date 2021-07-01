using KafkaNet;
using KafkaNet.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KafkaConsumerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string topic = "kafka_first_topic";
            string message = string.Empty;
            Uri uri = new Uri(@"http://localhost:9092");
            var options = new KafkaOptions(uri);
            BrokerRouter brokerRouter = new BrokerRouter(options);
            Consumer kafkaConsumer = new Consumer(new ConsumerOptions(topic, brokerRouter));
            var a=kafkaConsumer.GetOffsetPosition();
            var b=kafkaConsumer.GetTopicOffsetAsync("topic");
            foreach (var messages in kafkaConsumer.Consume())
            {
                message = Encoding.UTF8.GetString(messages.Value);
                System.Diagnostics.Debug.WriteLine(message);
                //return Ok(message);
            }
            return Ok(message);
        }
    }
}
