using System;

namespace RobotExercise
{
    public static class Program
    {
        static void Main()
        {
            Simulator simulator = new Simulator();
            string command;

            Console.Write("> ");

            while (true)
            {
                command = Console.ReadLine();

                if (command.ToUpper() == "EXIT")
                {
                    break;
                }

                string output = simulator.ProcessCommand(command);

                if (output != string.Empty)
                {
                    Console.WriteLine(output);
                }

                Console.Write("> ");
            }
        }
    }
}
