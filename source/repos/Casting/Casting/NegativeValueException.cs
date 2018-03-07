using System;

namespace Casting
{
    public class NegativeValueException :Exception
    {
        //public NegativeValueException()
        //{
            
        //}

        public NegativeValueException(int a, int b, int c)
            : base(String.Format("given values " + a + " " + b + " " + c + " cannot be null"))
        {
          
        }
    }
}