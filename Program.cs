using System;

namespace Program
{

    class Ticking
    {

        static void Main(string[] args)
        {
            //TickingBomb();


            RunWithTimer time = new RunWithTimer(49);

            string[] wires = { "Red ", "Blue ", "Yellow" };

            Console.WriteLine("There are three wires in the Bomb: Red = 1 , Blue = 2, Yellow = 3");

            Console.WriteLine("If you choose the wrong one the bomb will explode");


            Random random = new Random();

            random.Next(0, wires.Length);

            string userinput = Console.ReadLine();

            int input = int.Parse(userinput);


            if (input == random.Next(0, wires.Length))
            {
                Console.WriteLine("This is the right wire!!!");

            }
            else 
            {
                Console.WriteLine("This is the wrong wire");
                return; 
            }



        }


        static void TickingBomb ()
        {
            int count = 0;

            for (int i = 49; i > count; i--) 
            {
                Thread.Sleep(1000); 
                Console.WriteLine("The time is " + i);
            }


        }


    }

    //class Made to check timer inside it with the method
    public class RunWithTimer
    {
        private DateTime finish { get; set; }
        public bool timeLeft { get => finish > DateTime.Now; }

        private System.Threading.Timer time = null;

        private void TimerCallback(object state)
        {
            string timeLeft = (finish - DateTime.Now).ToString(@"hh\:mm\:ss");

            Console.WriteLine("Time Remaining: {0}" , timeLeft, true);


            if (!this.timeLeft)
            {
                Console.WriteLine("The time has run out! ");
                time.Dispose();
            }
        }
        public RunWithTimer(int numberOfSeconds)
        {
            finish = DateTime.Now.AddSeconds(numberOfSeconds);

            time = new Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(1.0));
        }
    }
}