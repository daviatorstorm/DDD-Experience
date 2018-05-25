using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Domain
{
    public class StoreDomain
    {
        private readonly IModel _model;
        public StoreDomain(IModel model)
        {
            _model = model;
        }
        public void DoCommand(CommandType type, object obj)
        {
            var command = Command.Create(type, obj);

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(command));
            
            _model.BasicPublish(exchange: "",
                                                routingKey: "retailers",
                                                basicProperties: null,
                                                body: body);
        }
    }
}