using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            //Hello Stoyan

            string[] inputInfo = args.Split();
            string commandName = inputInfo[0] + "Command";
            string[] parameters = inputInfo.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly().GetTypes().Where(t => t.Name == commandName).FirstOrDefault();

            if (type == null)
            {
                throw new InvalidOperationException("Invalid command");
            }
                       
            ICommand command = (ICommand)Activator.CreateInstance(type);
            string result = command.Execute(parameters);

            return result;
        }
    }
}
