using System;

namespace Domain
{
    [Serializable]
    public class Command
    {
        public string CommandType { get; set; }
        public object Obj { get; set; }
        public string Type { get; set; }

        private Command() { }

        public static Command Create(CommandType type, object instance)
        {
            var command = new Command();
            command.CommandType = type.ToString();
            
            if (instance != null)
            {
                command.Obj = instance;
                command.Type = instance.GetType().Name;
            }

            return command;
        }
    }
}