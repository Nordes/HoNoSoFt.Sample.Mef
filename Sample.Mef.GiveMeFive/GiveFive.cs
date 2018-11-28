using Sample.Mef.Api;
using System.Composition;

namespace Sample.Mef.GiveMeFive
{
    [Export(typeof(IGiveNumber))]
    public class GiveFive : IGiveNumber
    {
        public int GiveInt()
        {
            return 5;
        }
    }
}