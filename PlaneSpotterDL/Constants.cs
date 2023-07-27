using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotterDL
{
    public static class Constants
    {
        /// <summary>
        /// Creating a random guid to save with new aircraft spotter record
        /// </summary>
        /// <returns></returns>
        public static Guid GetRandomRecordId() 
        { 
            return Guid.NewGuid();
        }
    }
}
