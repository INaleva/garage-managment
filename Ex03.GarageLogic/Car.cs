using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{ 
    public class Car
    {
        public enum eColor
        {
            Grey,
            Blue,
            White,
            Black
        }

        public enum eDoorCount
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        private eDoorCount m_DoorsAmount;
        private eColor m_Color;

        public Car(eDoorCount i_DoorsAmount, eColor i_Color)
        {
            m_DoorsAmount = i_DoorsAmount;
            m_Color = i_Color;
        }

        public eDoorCount DoorsAmount
        {
            get { return m_DoorsAmount; }
        }

        public eColor Color
        {
            get { return m_Color; }
        }

        public override string ToString()
        {
            string output = string.Format(
@"Doors: {0}
Color: {1}", 
DoorsAmount, 
Color);

            return output;
        }
    }
}
