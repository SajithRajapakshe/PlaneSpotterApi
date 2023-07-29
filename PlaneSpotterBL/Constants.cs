using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotterBL
{
    /// <summary>
    /// Constants in business layer
    /// </summary>
    public static class Constants
    {
        public static string ApiAuthKey = "XApiKey";

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
