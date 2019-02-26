using System;


namespace PWGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Arguments _args = new Arguments(args);

            PWGenerator pgen = new PWGenerator();
            for (var i = 0; i < 5; i++)
                Console.WriteLine(pgen.GeneratePassword(_args.words, 
                    _args.spaces, 
                    _args.capitalize, 
                    _args.l33t, 
                    _args.appendChar, 
                    _args.appendNumber,
                    _args.appendString
                    ));
        }
    }
}
