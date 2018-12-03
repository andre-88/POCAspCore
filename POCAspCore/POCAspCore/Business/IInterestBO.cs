using Microsoft.Extensions.Configuration;

namespace POCAspCore.Business
{
    public interface IInterestBO
    {
        string getGitHubRepository();
        string getCompoundInterestValue(string valorinicial, string meses, int ratePercentage);
    }
}
