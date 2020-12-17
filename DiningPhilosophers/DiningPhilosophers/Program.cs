using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiningPhilosophers
{
    class Program
    {
        static bool[] forks = new bool[5];
        static object eatObj = new object();
        static int count = 0;
        static void Main(string[] args)
        {
            //Instance for creating a list of forks to the philosophers to use
            Fork fork = new Fork();

            //Each of the 5 philosophers
            Philosopher phil1 = new Philosopher("Philosopher 1", 1, fork);
            Philosopher phil2 = new Philosopher("Philosopher 2", 2, fork);
            Philosopher phil3 = new Philosopher("Philosopher 3", 3, fork);
            Philosopher phil4 = new Philosopher("Philosopher 4", 4, fork);
            Philosopher phil5 = new Philosopher("Philosopher 5", 5, fork);

            Console.Read();
        }
    }
}
