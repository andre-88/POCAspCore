using POCAspCore.RateCalculator.Rates;
using System;

namespace POCAspCore.RateCalculator
{
    public enum RateType
    {
        InterestCompound
    }

    public class RateFactory
    {
        public AbstractBaseRate Create(RateType type)
        {
            switch (type)
            {
                case RateType.InterestCompound:
                    return new InterestCompoundRate();

                default:
                        throw new InvalidOperationException("Tipo de calculo nao encontrado");
            }
        }
    }
}
