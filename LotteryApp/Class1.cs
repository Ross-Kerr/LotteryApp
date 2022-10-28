using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryApp
{
    public class Ticket
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        ArrayList _numbers = new ArrayList();

        public ArrayList balls
        {
            get { return _numbers; }
            set { _numbers = value; }
        }

        public Ticket()
        {
            Name = "undefined";
            Phone = "undefined";
        }

        public override string ToString()
        {
            return String.Format($"Name: {Name} Phone: {Phone}\n {_numbers[0]}  {_numbers[1]}  {_numbers[2]}  {_numbers[3]}  {_numbers[4]}  {_numbers[5]} ");
        }

    }

    
}
