using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Programming_Language
{
    class ConsoleCommands
    {
        string[] commandlist = 
            { "help",
            "run"
            };
        string[] commandvalue = 
            { "Commands: Help, Run",
            "runprogram"
            };
        public string iscommand(string command)
        {
            for (int i = 0; i < commandlist.Length; i++)
            {
                if (command == commandlist[i])
                {
                    return commandlist[i];
                }
            }
            return "CommandError";
        }
        public string findcommandvalue(string command)
        {
            for (int i = 0; i < commandlist.Length; i++)
            {
                if (command == commandlist[i])
                {
                    return commandvalue[i];
                }
            }
            return null;
        }
    }
}
