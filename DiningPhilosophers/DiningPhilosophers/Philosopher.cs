using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiningPhilosophers
{
    class Philosopher
    {
        public string Name { get; set; }
        public int Number { get; set; }
        //Fork class to call GrabForks and PlaceForks methods
        public Fork Fork { get; set; }
        //Left fork
        public int LeftFork { get; set; }
        //Right fork
        public int RightFork { get; set; }

        public Philosopher(string name, int number, Fork fork)
        {
            this.Name = name;
            this.Number = number;
            this.Fork = fork;
            Thread thread = new Thread(new ThreadStart(CallPhilosopherActions));
            thread.Start();
            this.LeftFork = Number - 1;
            this.RightFork = Number % 5;
        }
        
        /// <summary>
        /// Calls the methods for each philosopher's actions
        /// </summary>
        public void CallPhilosopherActions()
        {
            while (true)
            {

                Think();
                Fork.GrabForks(Name, LeftFork, RightFork);
                Eat();
                Fork.PlaceForks(Name, LeftFork, RightFork);
            }
        }

        /// <summary>
        /// Simulates the philosopher thinking
        /// </summary>
        public void Think()
        {
            Console.WriteLine($"{Name} is waiting");
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Simulates the philosopher eating
        /// </summary>
        public void Eat()
        {
            Console.WriteLine($"Philosopher {Name} is now eating");
            Thread.Sleep(1000);
        }
    }
}
