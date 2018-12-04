using System;

namespace POCAspCore.RateCalculator.Rates
{
    public class InterestCompoundRate : AbstractBaseRate
    {
        private decimal initialValue;
        private int period;
        private int ratePercentage;

        public InterestCompoundRate() { }

        public override void Load(decimal initialAmount, int timePeriod, int ratePercentage) {
            this.initialValue = initialAmount;
            this.period = timePeriod;
            this.ratePercentage = ratePercentage;
        }


        public override double Calculate()
        {
            var rateValue = Convert.ToDouble(initialValue) * Math.Pow((1.0 + (ratePercentage / 100.0)), period);

            return rateValue;
        }
    }
}
