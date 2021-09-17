using System;
using System.Collections.Generic;

namespace CalculatorConsole
{
    class Program
    {
        public static Stack<UInt10> stack = new Stack<UInt10>();


        static void Main(string[] args)
        {
            ReceiveComamnd();
        }

        public static void ReceiveComamnd()
        {

            Console.WriteLine("Insert command");
            var command = Console.ReadLine();

            if (command.Contains("Push") || command.Contains("push"))
            {
                UInt10 val;
                try
                {
                    val = (UInt10)Convert.ToUInt16(command.ToUpper().TrimStart('P', 'U', 'S', 'H', ' '));
                }
                catch(Exception)
                {
                    Console.WriteLine("Insert value");
                    val = (UInt10)Convert.ToUInt16(Console.ReadLine());
                }
                Push(val);
            }

            else if (command == "Pop" || command == "pop")
            {
                Pop();
            }

            else if (command == "Add" || command == "add")
            {
                Add();
            }

            else if (command == "Sub" || command == "sub")
            {
                Sub();
            }
            else
            {
                Console.WriteLine("Command not recognised");
                ReceiveComamnd();
            }
        }

        public static void Push(UInt10 val)
        {
            if (stack.Count >= 5)
            {
                throw (new Exception("Stack size exceded"));
            }
            stack.Push(val);

            Console.WriteLine("Command completed");

            ReceiveComamnd();
        }

        public static void Pop()
        {
            if (stack.Count > 0)
            {
                stack.Pop();
            }

            Console.WriteLine("Command completed");

            ReceiveComamnd();
        }

        public static void Add()
        {
            if (stack.Count < 2)
            {
                throw (new Exception("Stack does not cointain 2 or more values"));
            }
            var val1 = stack.Pop();
            var val2 = stack.Pop();

            var result = (UInt10)(val1 + val2);

            stack.Push(result);

            Console.WriteLine("Result: " + (ushort)result);

            Console.WriteLine("Command completed");

            ReceiveComamnd();
        }

        public static void Sub()
        {
            if (stack.Count < 2)
            {
                throw (new Exception("Stack does not cointain 2 or more values"));
            }

            var val1 = stack.Pop();
            var val2 = stack.Pop();

            var result = (UInt10)(val1 - val2);

            stack.Push(result);

            Console.WriteLine("Result: " + (ushort)result);

            Console.WriteLine("Command completed");

            ReceiveComamnd();
        }
    }

    struct UInt10
    {
        private UInt10(ushort val)
        {
            if (val >= (1 << 10))
                val = (ushort)(val % 1024);

            this._value = val;
        }
        private ushort _value;
        public static explicit operator UInt10(ushort value)
        {
            return new UInt10(value);
        }

        public static implicit operator ushort(UInt10 me)
        {
            return me._value;
        }
    }
}
