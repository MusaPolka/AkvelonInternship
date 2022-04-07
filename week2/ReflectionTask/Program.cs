using System;

namespace Documentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Documentation of {typeof(VkApi).Name}");

            var specifier = new Specifier<VkApi>();
            var methodNames = specifier.GetApiMethodNames();
            /*Console.WriteLine(specifier.GetApiDescription());
            Console.WriteLine(specifier.GetApiMethodDescription("Authorize"));
            ApiParamDescription apiParamDescription = specifier.GetApiMethodParamFullDescription("SelectAudio", "batchSize");

            Console.WriteLine(apiParamDescription.MinValue);
            Console.WriteLine(apiParamDescription.MaxValue);
            Console.WriteLine(apiParamDescription.Required);
            Console.WriteLine(apiParamDescription.ParamDescription.Name);
            Console.WriteLine(apiParamDescription.ParamDescription.Description);
            Console.ReadLine();*/
            foreach (var methodName in methodNames)
            {
                WriteWithColor($"{methodName}", ConsoleColor.Yellow);

                var methodDescription = specifier.GetApiMethodFullDescription(methodName);

                WriteWithColor($"\t{methodDescription.MethodDescription.Description}", ConsoleColor.DarkGreen);
                Console.WriteLine();

                WriteWithColor($"\tReturn", ConsoleColor.Green);
                WriteParamDescription(methodDescription.ReturnDescription);
                Console.WriteLine();

                WriteWithColor($"\tParameters", ConsoleColor.Green);
                foreach (var paramDescription in methodDescription.ParamDescriptions)
                {
                    WriteWithColor($"\t{paramDescription.ParamDescription.Name}", ConsoleColor.DarkYellow);
                    WriteParamDescription(paramDescription);
                    Console.WriteLine();
                }

                Console.WriteLine();
                
            }
            Console.ReadLine();
        }

        private static void WriteParamDescription(ApiParamDescription description)
        {
            if (description == null)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(description.ParamDescription?.Description))
            {
                WriteWithColor($"\t\t{description.ParamDescription?.Description}", ConsoleColor.DarkGreen);
            }

            WriteWithColor($"\t\tRequired - {description.Required}", ConsoleColor.DarkGreen);

            if (description.MinValue != null)
            {
                WriteWithColor($"\t\tMin - {description.MinValue}", ConsoleColor.DarkGreen);
            }

            if (description.MaxValue != null)
            {
                WriteWithColor($"\t\tMax - {description.MaxValue}", ConsoleColor.DarkGreen);
            }
        }

        private static void WriteWithColor(string line, ConsoleColor color, bool saveOldColor = true)
        {
            var oldColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.WriteLine(line);

            if (saveOldColor)
            {
                Console.ForegroundColor = oldColor;
            }
        }
    }
}