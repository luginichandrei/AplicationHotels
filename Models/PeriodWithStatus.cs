using System.ComponentModel;

namespace Models
{
    public enum PeriodWithStatus
    {
        [Description("Free Period")]
        FreePeriod,

        [Description("Reserved Period")]
        ReservedPeriod
    }
}