using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Classes___Part_1
{
    public class GSM
    {
        public static readonly GSM apple = new GSM("iPhone 4S", "Apple", 1000, "Gosho Ivanov",
                new Battery() { BatteryModel = "Apple", BatteryIdleHours = 500, BatteryTalkHours = 10, BatteryChemical = BatteryType.LiIon },
                new Display() { DisplaySize = 3.5, DisplayColors = "16 milion" });

        private string gsmModel;
        private string gsmManufacturer;
        private int? gsmPrice;
        private string gsmOwner;
        private Battery gsmBattery;
        private Display gsmDisplay;
        private List<Calls> callHistory;

        //calls
        public void AddCall(string date, string time, string receiver, int duration)
        {
            var thisCall = new Calls()
            {
                Date = date,
                Time = time,
                Receiver = receiver,
                Duration = duration
            };

            this.callHistory.Add(thisCall);
        }

        public void RemoveCall(Calls call)
        {
            this.callHistory.Remove(call);
        }

        public double CallsPrice(double pricePerMinute)
        {
            double res = 0;

            foreach(var call in callHistory)
            {
                res += Math.Ceiling((double)call.Duration/60) * pricePerMinute;
            }
            
            return res;
        } 

        public string CallsInfo()
        {
            var calls = new StringBuilder();
            calls.AppendLine($"Displaying call history for device: {GsmManufacturer} {GsmModel}");

            foreach(var call in this.callHistory)
            {
               calls.AppendLine($"On: {call.Date}, At: {call.Time}, To: {call.Receiver}, Duration: {call.Duration} seconds");
            }

            return calls.ToString();
        }

        //ToString override
        public override string ToString()
        {
            var res = new StringBuilder();

            res.AppendLine($"Manufacturer: {gsmManufacturer}");

            res.AppendLine($"Model: {gsmModel}");

            if(gsmPrice.HasValue)
                res.AppendLine($"Price: ${gsmPrice}");

            if(!string.IsNullOrEmpty(gsmOwner))
                res.AppendLine($"Owner: {gsmOwner}");

            if (!string.IsNullOrEmpty(gsmBattery.BatteryModel))
                res.AppendLine($"Battery model: {gsmBattery.BatteryModel}");

            if(gsmBattery.BatteryChemical.HasValue)
                res.AppendLine($"Battery type: {gsmBattery.BatteryChemical}");

            if(gsmBattery.BatteryIdleHours.HasValue)
                res.AppendLine($"Battery idle hours: {gsmBattery.BatteryIdleHours}");

            if(gsmBattery.BatteryTalkHours.HasValue)
                res.AppendLine($"Battery talk hours: {gsmBattery.BatteryTalkHours}");

            if(gsmDisplay.DisplaySize.HasValue)
                res.AppendLine($"Display size: {gsmDisplay.DisplaySize} inches");

            if(!string.IsNullOrEmpty(gsmDisplay.DisplayColors))
                res.AppendLine($"Display colors: {gsmDisplay.DisplayColors}");

            return res.ToString();
        }

        //properties
        public string GsmModel
        {
            get
            {
                return this.gsmModel;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid input for phone model");
                }

                this.gsmModel = value;
            }
        }

        public string GsmManufacturer
        {
            get
            {
                return this.gsmManufacturer;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid input for phone manufacturer");
                }

                this.gsmManufacturer = value;
            }
        }

        public int? GsmPrice
        {
            get
            {
                return this.gsmPrice;
            }
            set
            {
                if(!value.HasValue)
                {
                    throw new ArgumentNullException("Invalid input for phone price");
                }

                this.gsmPrice = value;
            }
        }

        public string GsmOwner
        {
            get
            {
                return this.gsmOwner;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid input for owner");
                }

                this.gsmOwner = value;
            }
        }

        //various ctors for flexibility when creating instances
        public GSM(string model, string manufacturer)
        {
            callHistory = new List<Calls>();
            this.GsmModel = model;
            this.GsmManufacturer = manufacturer;
        }

        public GSM(string model, string manufacturer, int price) :
            this(model, manufacturer)
        {
            this.GsmPrice = price;
        }

        public GSM(string model, string manufacturer, int price, Battery battery, Display display) :
            this(model, manufacturer, price)
        {
            this.gsmBattery = battery;
            this.gsmDisplay = display;
        }

        public GSM(string model, string manufacturer, string owner) :
           this(model, manufacturer)
        {
            this.GsmOwner = owner;
        }

        public GSM(string model, string manufacturer, string owner, Battery battery, Display display) :
            this(model, manufacturer, owner)
        {
            this.gsmBattery = battery;
            this.gsmDisplay = display;
        }

        public GSM(string model, string manufacturer, int price, string owner) :
            this(model, manufacturer)
        {
            this.GsmPrice = price;
            this.GsmOwner = owner;
        }

        public GSM(string model, string manufacturer, int price, string owner, Battery battery, Display display) : 
            this(model, manufacturer, price, owner)
        {
            this.gsmBattery = battery;
            this.gsmDisplay = display;
        }
    }
}
