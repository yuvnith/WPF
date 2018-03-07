namespace Casting
 
{
    public class Vehichle : IVehichle
    {
       

        public double MileageCalculator(int a, int b, int c)
        {
            if (a < 0 || b < 0 || c < 0)
            {
                throw new NegativeValueException(a,b,c);
           
            }
            double  mileage = a * b * c;
            return mileage;
        }
    }
}