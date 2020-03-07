using System.Linq;

namespace Odie
{
    public class FlagsBuilder : Builder<Flags, FlagsBuilder>
    {
        public FlagsBuilder AddFlag(Flag flag)
        {
            return Update(x => x.Add(flag));
        }

        public FlagsBuilder AddFlags(params Flag[] flags)
        {
            return Update(x => x.AddRange(flags));
        }

        public FlagsBuilder RemoveFlag(Flag flag)
        {
            return Update(x => x.Remove(flag));
        }

        public FlagsBuilder RemoveFlag(string name)
        {
            return Update(x => x.Remove(x.SingleOrDefault(y => y.Name == name)));
        }
    }
}