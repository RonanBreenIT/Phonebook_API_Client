using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookClient.Models
{
    public class Phonebook
    {
        public int ID { get; set; }

        public String Name { get; set; }

        public String Number { get; set; }

        public String Address { get; set; }

        public override string ToString()
        {
            return "\nID: " + ID + "\nName: " + this.Name + "\nNumber: " + this.Number + "\nAddress: " + this.Address;
        }

    }
}
