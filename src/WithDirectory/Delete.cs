using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du.WithDirectory
{
    public class Delete
    {
        public static void ListOf(List<string> directories)
        {
            foreach (var directory in directories)
            {
                if (Directory.Exists(directory))
                {
                    Directory.Delete(directory, true);
                }
            }
        }
    }
}
