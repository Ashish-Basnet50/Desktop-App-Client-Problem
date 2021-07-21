using Broadway.App.Inheritance;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadway.App
{
    class Program
    {
        public static void Main(String[] args)
        {
            // Create a queue of capacity 4 
            //Queue q = new Queue(3);

            //// print Queue elements 
            //q.queueDisplay();

            //// inserting elements in the queue 
            //q.queueEnqueue(20);
            //q.queueEnqueue(30);
            //q.queueEnqueue(40);
            //q.queueEnqueue(50);
            //q.queueEnqueue(580);

            //// print Queue elements 
            //q.queueDisplay();

            //// insert element in the queue 
            //q.queueEnqueue(60);

            //// print Queue elements 
            //q.queueDisplay();

            //q.queueDequeue();
            ////q.queueDequeue();
            //Console.Write("\n\nafter two node deletion\n\n");
            //Console.ReadLine();

            //// print Queue elements 
            //q.queueDisplay();
            

            //// print front of the queue 
            //q.queueFront();


            InheritanceExample();
            Console.ReadLine();

        }
        static void InheritanceExample()
        {
            var vertibrate = new Vertibrate("Human");

            Console.WriteLine("Type of Vertibrate =>" + vertibrate.GetType());

            var livingthing = (LivingThing)vertibrate;

            

        }
    }
}