using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Classes___Part_1
{
    public class Calls
    {
        private string date;
        private string time;
        private string receiver;
        private int duration;

        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public string Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }

        public string Receiver
        {
            get
            {
                return this.receiver;
            }
            set
            {
                this.receiver = value;
            }
        }

        public int Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                this.duration = value;
            }
        }

        public Calls()
        {

        }
    }
}
