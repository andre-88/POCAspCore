using Microsoft.Extensions.Configuration;
using POCAspCore.RateCalculator;
using System;

namespace POCAspCore.Business
{
    public class InterestBO : IInterestBO
    {
        private IConfiguration configuration;

        public InterestBO(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        public string getGitHubRepository()
        {

            var url = configuration.GetSection("GitHubUrl");
            if (url.Value == null)
                throw new Exception("GithHubUrl not found.");

            return url.Value;
        }

        public string getCompoundInterestValue(string valorinicial, string meses, int ratePercentage)
        {

            decimal initialValue;
            int period;

           if (!Decimal.TryParse(valorinicial, out initialValue))
                throw new InvalidCastException("O valor inicial e invalido.");

            if (!Int32.TryParse(meses, out period))
                throw new InvalidCastException("O tempo de meses e invalido.");

            if(ratePercentage < 0 || ratePercentage > 100)
                throw new ArgumentOutOfRangeException("O parametro juros e invalido.");

            var rate = new RateFactory().Create(RateType.InterestCompound);
            rate.Load(initialValue, period, ratePercentage);
            var result = rate.Calculate();

            var rounded = Math.Round(result, 2);

            return rounded.ToString("0.00");
        }
    }
}
