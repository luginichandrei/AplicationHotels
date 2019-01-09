using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
