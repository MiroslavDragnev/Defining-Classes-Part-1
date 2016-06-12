using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Classes___Part_1
{
    public enum BatteryType
    {
        LiIon = 0,
        NiMH = 1,
        NiCd = 2
    }

    public class Battery
    {
        private string batteryModel;
        private uint? batteryIdleHours;
        private uint? batteryTalkHours;
        private BatteryType? batteryChemical;

        public BatteryType? BatteryChemical
        {
            get
            {
                return this.batteryChemical;
            }
            set
            {
                if (!Enum.IsDefined(typeof(BatteryType), value))
                {
                    throw new ArgumentNullException("Invalid input for battery type.");
                }

                this.batteryChemical = value;
            }
        }

        public string BatteryModel
        {
            get
            {
                return this.batteryModel;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid input for battery model.");
                }

                this.batteryModel = value;
            }
        }

        public uint? BatteryIdleHours
        {
            get
            {
                return this.batteryIdleHours;
            }
            set
            {
                if(!value.HasValue || (value.HasValue && value <= 0))
                {
                    throw new ArgumentException("Invalid input for battery idle hours.");
                }

                this.batteryIdleHours = value;
            }
        }

        public uint? BatteryTalkHours
        {
            get
            {
                return this.batteryTalkHours;
            }
            set
            {
                if (!value.HasValue || (value.HasValue && value <= 0))
                {
                    throw new ArgumentException("Invalid input for battery talk hours.");
                }

                this.batteryTalkHours = value;
            }
        }

        public Battery()
        {

        }

        public Battery(string model)
        {
            this.BatteryModel = model;
        }

        public Battery(string model, uint? idle, uint? talk, BatteryType type) : 
            this(model)
        {
            this.BatteryIdleHours = idle;
            this.BatteryTalkHours = talk;
            this.BatteryChemical = type;
        }
    }
}
