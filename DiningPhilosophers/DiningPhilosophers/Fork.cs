using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiningPhilosophers
{
    public class Fork
    {
        public bool[] forks = new bool[5];

        /// <summary>
        /// Method that tries to pick up the left and right fork for each philosopher.
        /// It first checks if either of the left or right forks are true(if they are already in use)
        /// Then it sets the monitor to wait until they can be picked up.
        /// If thats not the case, the method sets the forks to "picked up" (true)
        /// </summary>
        /// <param name="philName">The philosophers name, if you would want to set that in the main method when instanciated</param>
        /// <param name="leftFork">The left fork from the philosopher</param>
        /// <param name="rightFork">The right fork from the philosopher</param>
        public void GrabForks(string philName, int leftFork, int rightFork)
        {
            lock (this)
            {
                while (forks[leftFork] == true || forks[rightFork] == true)
                {
                    Monitor.Wait(this);
                }
                    Console.WriteLine($"{philName} picks up fork {leftFork} and fork {rightFork}");
                    Monitor.PulseAll(this);
                    forks[leftFork] = true;
                    forks[rightFork] = true;
            }
        }
        /// <summary>
        /// Method that puts the forks back onto the table.
        /// It checks if the current philosopher has forks in his hands, and lays it down if he has two
        /// When layed down, the forks are set to false (not in use)
        /// </summary>
        /// <param name="philName">The philosophers name, if you would want to set that in the main method when instanciated</param>
        /// <param name="leftFork">The left fork from the philosopher</param>
        /// <param name="rightFork">The right fork from the philosopher</param>
        public void PlaceForks(string philName, int leftFork, int rightFork)
        {
            lock (this)
            {
                while (forks[leftFork] == true && forks[rightFork] == true)
                {
                    forks[leftFork] = false;
                    forks[rightFork] = false;
                    Console.WriteLine($"{philName} places fork {leftFork} and fork {rightFork}");
                    Monitor.PulseAll(this);
                }
            }
        }
    }
}
