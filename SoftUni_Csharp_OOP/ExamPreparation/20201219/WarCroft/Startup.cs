using System;
using WarCroft.Core;
using WarCroft.Core.IO;
using WarCroft.Core.IO.Contracts;

namespace WarCroft
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            var engine = new Engine(reader, writer);
            engine.Run();

            /* Use the below configuration instead of the usual one if you wish to print all output messages together after the inputs for easier comparison with the example output. */

            //ireader reader = new consolereader();
            //var sbwriter = new stringbuilderwriter();

            //var engine = new engine(reader, sbwriter);
            //engine.run();

            //console.writeline(sbwriter.sb.tostring().trim());
        }
    }
}