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
        public String _name;
        public string Name { get { return _name; } set {
                if (value.Length < 1)
                    throw new Exception("Name can not be empty!");
                else if (value.Any(Char.IsDigit))
                {
                    throw new Exception("Numbers are not Allowed in Name!");
                }
                else
                {
                    _name = value;
                }
            }
        }
        public String _phone;
        public string Phone { get { return _phone; } set {if (value.Length < 1)
            {
                throw new Exception(" No Phone Number!");
            } else
            {
                    _phone = value;
            }
            }
        }
            

        ArrayList _numbers = new ArrayList();

        public ArrayList balls
        {
            get { return _numbers; }
            set
            { //_numbers = value; 
                for (int i = 0; i < 6; i++)
                {
                    int number;
                    try {
                        number = Convert.ToInt32(value[i]); //to integer
                    }
                    catch (Exception ex) {
                        throw new Exception("Invlaid Number Added");
                    }

                    if (number < 1)
                    {
                        throw new Exception("Number Too Low");
                    }
                    else if (number > 49)
                    {
                        throw new Exception("Number Too High");
                    }
                    else if (_numbers.Contains(number))
                    {
                        throw new Exception("Duplicate Number!");
                    }
                    else
                    {
                        _numbers.Add(value[i]);
                    }
                }
            }
        }

        public void LuckyDipGenerator()
        {
            Random rnd = new Random();
            ArrayList dip = new ArrayList();
            for(int i = 0; i < 6; i++)
            {
                int num = 0;
                do
                {
                    num = rnd.Next(1, 50);
                } while (_numbers.Contains(num));
                _numbers.Add(rnd.Next(1, 50)); 
            }
           
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
