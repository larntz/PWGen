using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWGen
{
    class Arguments
    {
        public int words = 2;
        public bool spaces = false;
        public bool capitalize = true;
        public bool l33t = false;
        public bool appendChar = true;
        public bool appendNumber = false;
        public string appendString = null;

        public Arguments(string[] args)
        {
            if (args.Length > 0)
                for (int i = 0; i < args.Length; i++)
                {
                    string arg = args[i];
                    if (arg[0] != Char.Parse("-"))
                        continue;

                    string option = arg.Substring(1);
                    switch (option.ToLower())
                    {
                        case "words":
                            Int32.TryParse(args[i + 1], out words);
                            break;
                        case "spaces":
                            spaces = true;
                            break;
                        case "capitalize":
                            capitalize = true;
                            break;
                        case "nocaps":
                            capitalize = false;
                            break;
                        case "l33t":
                            l33t = true;
                            break;
                        case "appendchar":
                            appendChar = true;
                            break;
                        case "nochar":
                            appendChar = false;
                            break;
                        case "appendnumber":
                            appendNumber = true;
                            break;
                        case "appendstring":
                            appendString = args[i + 1];
                            break;
                        case "help":
                            Usage();
                            break;

                    }
                }
        }

        private void Usage()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("\t-words NUM (create password with 2, 3, or 4 words)\n" +
                "\t-spaces (insert a space between words)\n" +
                "\t-nocaps (don't capitalize the first letter of each word)\n" +
                "\t-l33t (replace some characters with l33t sp3@k)\n" +
                "\t-nochar (don't append a special char after words)\n" +
                "\t-appendnumber (append a random number after words/char)\n" +
                "\t-appendstring STRING (append giving string to password)\n" +
                "\t-help (show this program usage message)\n");
            Environment.Exit(0);
        }

    }

}
