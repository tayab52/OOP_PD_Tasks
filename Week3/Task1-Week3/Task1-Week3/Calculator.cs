using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_LabOOP
{
    internal class Calculator
    {
        public Calculator() { 
        value1 = 10;
        value2 = 10;
        
        
        }
        public Calculator(float value1,float value2)
        {
            this.value1 = value1;
            this.value2 = value2;

        }
        public float value1;
        public float value2;
        //public float result;

        public void updateObjectValues(float value1,float value2)
        {
            this.value1=value1; 
            this.value2=value2;
            
        }
        public float addition()
        {
            float result;
            result = value1 + value2;
            return result;

        }
        public float subtraction()
        {
            float result;
            result = value1 - value2;
            return result;
        }
        public float multiplication()
        {
            float result;
            result = value1 * value2;
            return result;

        }
        public float division()
        {
            float result;
            result = value1 / value2;
            return result;

        }
        public float Modulo()
        {
            float result;
            result = value1 % value2;
            return result;
        }
    }

}
