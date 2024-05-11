using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du
{
    /// <summary>System stuff.</summary>
    public static partial class WithSystem
    {
        /// <summary>System stuff for Windows.</summary>
        public static class Windows
        {
            /// <summary>Execute a command.</summary>
            /// <param name="command">The command to execute.</param>
            /// <param name="arguments">Optional command arguemnts.</param>
            /// <param name="terminateAfterExecution">Determines if the console is terminated after executing the command.</param>
            public static void ExecuteCommand(string command, string arguments, bool terminateAfterExecution = true)
            {
                if (terminateAfterExecution)
                {
                    Process.Start(command, $"/c {arguments}");
                }
                else
                {
                    Process.Start(command, arguments);
                }
            }
        }
    }
}