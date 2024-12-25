using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp56.Computer;

namespace ConsoleApp56
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите тип компьютера: 1 - Игровой, 2 - Офисный");
            string choice = Console.ReadLine();

            IComputerBuilder builder;

            if (choice == "1")
            {
                builder = new GamingComputerBuilder();
            }
            else
            {
                builder = new OfficeComputerBuilder();
            }

            ComputerDirector director = new ComputerDirector(builder);
            Computer computer = director.Construct();

            Console.WriteLine("Собран компьютер:");
            Console.WriteLine(computer);
        }
   }

        public class Computer
        {
            public string Processor { get; set; }
            public int RAM { get; set; }
            public string HDD { get; set; }
            public string GPU { get; set; }

            public override string ToString()
            {
                return $"Процессор: {Processor}\nОперативная память: {RAM} ГБ\nЖёсткий диск: {HDD}\nВидеокарта: {GPU}";
            }

            public interface IComputerBuilder
            {
                void BuildProcessor();
                void BuildRAM();
                void BuildGPU();
                void BuildHDD();
                Computer GetComputer();
            }

            public class GamingComputerBuilder : IComputerBuilder
            {
                private Computer _computer = new Computer();

                public void BuildProcessor()
                {
                    _computer.Processor = "IntelCore i9";
                }

                public void BuildRAM()
                {
                    _computer.RAM = 32;
                }

                public void BuildHDD()
                {
                    _computer.HDD = "2 ТБ SSD";
                }

                public void BuildGPU()
                {
                    _computer.GPU = "NVIDIA RTX 3080";
                }

                public Computer GetComputer() => _computer;
            }

            public class OfficeComputerBuilder : IComputerBuilder
            {
                private Computer _computer = new Computer();

                public void BuildProcessor()
                {
                    _computer.Processor = "AMD Ryzen 5";
                }

                public void BuildRAM()
                {
                    _computer.RAM = 16;
                }

                public void BuildHDD()
                {
                    _computer.HDD = "1 ТБ HDD";
                }

                public void BuildGPU()
                {
                    _computer.GPU = "Встроенная графика";
                }

                public Computer GetComputer() => _computer;
            }

            public class ComputerDirector
            {
                private readonly IComputerBuilder _builder;

                public ComputerDirector(IComputerBuilder builder)
                {
                    _builder = builder;
                }

                public Computer Construct()
                {
                    _builder.BuildProcessor();
                    _builder.BuildRAM();
                    _builder.BuildHDD();
                    _builder.BuildGPU();
                    return _builder.GetComputer();
                }
            }
        }
    }

