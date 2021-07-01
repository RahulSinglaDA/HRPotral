using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepartmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KafkaProducerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string topic = "kafka_first_topic";
            string message = string.Empty;
            Uri uri = new Uri(@"http://localhost:9092");
            var options = new KafkaOptions(uri);
            BrokerRouter brokerRouter = new BrokerRouter(options);

            Producer kafkaProducer = new Producer(brokerRouter);
            kafkaProducer.GetTopic(topic);

            //kafkaProducer.SendMessageAsync(topic, new[] { new Message() { Value = Encoding.UTF8.GetBytes("Hi I am Producer")} });
            int count = 0;
            while (true)
            {
                Thread.Sleep(1000);
                kafkaProducer.SendMessageAsync(topic, new[] { new Message() { Value = Encoding.UTF8.GetBytes("Hi I am Producer"+count) } });
                count++;
            }

            return Ok(message);
        }
    }
}
