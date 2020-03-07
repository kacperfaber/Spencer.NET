using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Odie
{
    public class Flags : List<Flag>
    {
        public bool HasFlag(string name)
        {
            return this.SingleOrDefault(x => x.Name == name) != null;
        }

        public bool HasFlags(params string[] names)
        {
            foreach (string name in names)
            {
                Flag flag = this.SingleOrDefault(x => x.Name == name);

                if (flag == null)
                    return false;
            }

            return true;
        }
    }
}