using System;

namespace DependencyInjectionExample
{
    class DependencyInjectionExample
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's practice some dependency injection. Type 'exit' to quit.\n");

            // Constructor Injection
            RedWriter rw = new RedWriter();
            MessageCenter rmc = new MessageCenter(rw);

            // Method Injection
            BlueWriter bw = new BlueWriter();
            MessageCenter bmc = new MessageCenter();

            // Property Injection
            GreenWriter gw = new GreenWriter();
            MessageCenter gmc = new MessageCenter();
            gmc.Pen = gw;

            string input = Console.ReadLine();
            while (input.ToLower() != "exit")
            {
                rmc.Post(input);
                bmc.Post(bw, input);
                gmc.Post(input);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                input = Console.ReadLine();
            }
        }
    }

    // The central class that will send its input into either of the color writers
    class MessageCenter
    {
        // The pen's ink is null
        Writer pen = null;

        // Blank constructor
        public MessageCenter()
        {

        }

        // Constructor used for constructor injection
        public MessageCenter(Writer _pen)
        {
            this.pen = _pen;
        }

        // Getter and setter for property injection
        public Writer Pen
        {
            get
            {
                return pen;
            }
            set
            {
                pen = value;
            }
        }

        // Main writing method used by constructor and property injection
        public void Post(string input)
        {
            pen.display(input);
        }

        // Overloaded method to be used by method injection
        public void Post(Writer _pen, string input)
        {
            this.pen = _pen;
            pen.display(input);
        }
    }

    // Interface for the color writers
    interface Writer
    {
        void display(string input);
    }

    // Red
    class RedWriter : Writer
    {
        public void display(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(input);
        }
    }

    // Blue
    class BlueWriter : Writer
    {
        public void display(string input)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(input);
        }
    }

    // Green
    class GreenWriter : Writer
    {
        public void display(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(input);
        }
    }
}
