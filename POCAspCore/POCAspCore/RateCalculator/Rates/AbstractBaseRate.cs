using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POCAspCore.RateCalculator.Rates
{
    public abstract class AbstractBaseRate
    {
        public virtual void Load(decimal initialAmount, int timePeriod, int ratePercentage)
        {
            throw new NotImplementedException();
        }

        public virtual double Calculate()
        {
            throw new NotImplementedException();
        }
    }
}
