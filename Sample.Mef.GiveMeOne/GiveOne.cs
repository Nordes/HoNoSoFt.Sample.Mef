using Sample.Mef.Api;
using System.Composition;

namespace Sample.Mef.GiveMeOne
{
    [Export(typeof(IGiveNumber))]
    public class GiveOne : IGiveNumber
    {
        public int GiveInt()
        {
            return 1;
        }
    }
}
