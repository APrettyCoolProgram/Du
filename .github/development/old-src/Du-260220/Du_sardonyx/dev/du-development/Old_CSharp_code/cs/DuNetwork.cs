#region HEADER
//   PROJECT: Du
//  FILENAME: DuNetwork.cs
//   VERSION: 0.12.0-alpha
//     BUILD: 180227
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2017 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/Du
#endregion

#region CLASS_DESCRIPTION
// Does things with networking.
#endregion

using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;

namespace Du
{
    public class DuNetwork
    {
        /// <summary>Ping a device.</summary>
        /// <param name="ipAddress"> The IP Address OR name of the device to ping (i.e. "192.168.1.1" / "machine-name").</param>
        /// <returns>The success or failure of the ping.</returns>
        /// <remarks>This method pings a device, either by name or IP Address, and returns a single success or failure.
        /// If you need more control over pinging a device, use PingDeluxe().</remarks>
        /// <build>180225</build>
        public static bool PingDevice(string device)
        {
            var pingResults = new Ping();
            var pingOptions = new PingOptions
            {
                DontFragment = true
            };

            const string data = "thisisathirtytwobitstringtoping!";
            var buffer        = Encoding.ASCII.GetBytes(data);
            const int timeout = 120;
            var reply         = pingResults.Send(device, timeout, buffer, pingOptions);

            return reply.Status == IPStatus.Success;
        }

        /// <summary>Gets the number of successful or unsuccessful pings. </summary>
        /// <param name="device">          The IP Address to ping (i.e. "192.168.1.1").</param>
        /// <param name="quantity">        The number of pings to execute (i.e. "4").</param>
        /// <param name="returnSuccesses"> Return the number of successful pings [true/false].</param>
        /// <returns>The number of sucessful or unsuccessful pings.</returns>
        /// <remarks></remarks>
        /// <build>180225</build>
        public static int PingDeluxe(string device, int quantity, bool returnSuccesses)
        {
            var command = "/c ping -n" + quantity + " " + device;
            var failures = new Regex(Regex.Escape("unreachable")).Matches(DuSystem.ExecuteCommand("start /b ", command)).Count;

            return returnSuccesses
                ? quantity - failures
                : failures;
        }
    }
}