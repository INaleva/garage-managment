using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue, string i_ValueType) 
               : base(string.Format("{2} is out of range. enter Value between {0} and {1}, Operation Aborted.", i_MinValue, i_MaxValue, i_ValueType))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    }
}
