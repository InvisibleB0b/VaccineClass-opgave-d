using System;
using System.Drawing;
using System.Linq.Expressions;

namespace VaccineClassLib
{
    public class Vaccine
    {
        private string _producer;
        private int _price;
        private int _efficiency;



        public int Id { get; set; }

        public string Producer
        {
            get { return _producer; }


            set
            {
                //tjekker længden her
                if (value.Length < 4)
                {
                    //hvis mindre end 4 så kastes en argument exc
                    throw new ArgumentException("Producer name too short");
                }
                else
                {
                    _producer = value;
                }


            }
        }

        public int Price
        {
            get { return _price; }
            set
            {
                //tjekker på value
                if (value < 0)
                {
                    //smider exception hvis pris prøves at sættes til mindre end 0
                    throw new ArgumentOutOfRangeException("Price must be above 0");
                }
                else
                {
                    _price = value;
                }

            }
        }

        public int Efficiency
        {
            get { return _efficiency; }
            set
            {
                if (value < 50)
                {
                    throw new ArgumentOutOfRangeException("Efficiency must be above 50");
                }
                else if (value > 100)
                {
                    throw new ArgumentOutOfRangeException("Efficiency must be below 100");
                }
                else
                {
                    _efficiency = value;
                }

                //if (value < 50 || value > 100)
                //{
                //    throw new ArgumentOutOfRangeException("Efficiency must be between 50 and 100");
                //}
                //else
                //{
                //    _efficiency = value;
                //}

            }
        }


        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Producer)}: {Producer}, {nameof(Price)}: {Price}, {nameof(Efficiency)}: {Efficiency}";
        }

    }
}
