using PudelkoLibrary.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PudelkoLibrary.Pudelko
{
    public class Pudelko
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        
        public Pudelko(double a = 0.1, double b = 0.1, double c = 0.1, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            if(a < 0 || b < 0 || c < 0)
            {
                throw new ArgumentOutOfRangeException("The argument can't be negative.");
            }

            double[] doubles = { a, b, c };

            double limit = 10;

            switch(unit){
                case UnitOfMeasure.meter:
                    limit = 10;
                    break;
                case UnitOfMeasure.centimeter:
                    limit = 1000;
                    break;
                case UnitOfMeasure.milimeter:
                    limit = 10000;
                    break;
            }

            foreach (double s in doubles)
            {
                if (s > limit)
                {
                    throw new ArgumentOutOfRangeException("The argument can't be bigger than 10 meters.");
                }
            }

            A = ToMeter(a, unit);
            B = ToMeter(b, unit);
            C = ToMeter(c, unit);
        }

        public double ToMeter(double value, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            if(unit == UnitOfMeasure.centimeter)
            {
                return value / 100;
            }
            else if(unit == UnitOfMeasure.milimeter)
            {
                return value / 1000;
            }
            else
                return value;
        }

        public override string ToString()
        {
            string a = String.Format("{0:0.000}", A);
            string b = String.Format("{0:0.000}", B);
            string c = String.Format("{0:0.000}", C);

            return $"{UnitToString(A)} × {UnitToString(B)} × {UnitToString(C)}";
        }

        public string UnitToString(double value, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            if(unit == UnitOfMeasure.centimeter)
            {
                return $"{String.Format("{0:0.0}", value * 100)} cm";
            }
            else if (unit == UnitOfMeasure.milimeter)
            {
                return $"{String.Format("{0:0}", value * 1000)} mm";
            }
            else
            {
                return $"{String.Format("{0:0.000}", value)} m";
            }
        }

        public string ToString(string unit = "m")
        {
            double[] values = { A, B, C };

            UnitOfMeasure unitOfMeasure = UnitOfMeasure.meter;

            switch (unit)
            {
                case "m":
                    unitOfMeasure = UnitOfMeasure.meter;
                    break;
                case "cm":
                    unitOfMeasure = UnitOfMeasure.meter;
                    break;
                case "mm":
                    unitOfMeasure = UnitOfMeasure.meter;
                    break;
            }

            //return base.ToString() + ": " + value.ToString();
            return $"{UnitToString(A, unitOfMeasure)} × {UnitToString(B, unitOfMeasure)} × {UnitToString(C, unitOfMeasure)}";
        }

        private List<double> CalculateUnits(UnitOfMeasure unit)
        {
            double[] values = { A, B, C };
            List<double> results = new List<double>();
            
            if(unit == UnitOfMeasure.centimeter)
            {
                foreach (double value in values)
                {
                    results.Add(100 * value);
                }
                return results;

            }
            else if (unit == UnitOfMeasure.milimeter)
            {
                foreach (double value in values)
                {
                    results.Add(1000 * value);
                }
                return results;
            }
            else
            {
                return values.ToList();
            }

            
        }
    }
}
