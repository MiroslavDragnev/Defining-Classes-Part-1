using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Classes___Part_1
{
    class Program
    {
        static void Main()
        {
            GSMTest();
        }

        static void GSMTest()
        {
            //let's create a few other phones
            var samsung = new GSM("Galaxy S3", "Samsung", 299, "Pesho Terziev",
                new Battery() { BatteryChemical = BatteryType.LiIon },
                new Display() { DisplaySize = 4.8 });

            var lenovo = new GSM("A536", "Lenovo", 199, new Battery(), new Display());

            var htc = new GSM("Hero", "HTC", "Penka Stankova", new Battery(), new Display());

            //let's print the info on those and the static iPhone 4S
            Console.WriteLine(GSM.apple.ToString());
            Console.WriteLine(samsung.ToString());
            Console.WriteLine(lenovo.ToString());
            Console.WriteLine(htc.ToString());

            //adding a few calls to the samsung
            samsung.AddCall("01.02.2016", "14:02", "0892626725", 37);
            samsung.AddCall("13.03.2016", "16:37", "0882412412", 152);
            samsung.AddCall("25.05.2016", "18:12", "0898124124", 255);

            //calculate the price of the calls (0.37 lv per minute)
            Console.WriteLine($"Price of all calls: {samsung.CallsPrice(0.37).ToString("F2")}");

            Console.WriteLine();

            //finally, let's print the call history
            Console.WriteLine(samsung.CallsInfo());
        }
    }
}
