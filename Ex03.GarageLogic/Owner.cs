using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Owner
    {
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhone;

        public Owner(string i_OwnerName, string i_OwnerPhone)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhone = i_OwnerPhone;
        }

    
        public override string ToString()
        {
            string output = string.Format(
@"Owner Name: {0}
Owner Phone: {1}", 
r_OwnerName,
r_OwnerPhone);

            return output;
        }
    }
}
