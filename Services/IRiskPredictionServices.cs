using Danciu_Lavinia_Lab5.Models;
using System.Threading.Tasks;
namespace Danciu_Lavinia_Lab5.Services
{
    public interface IRiskPredictionService
    {
        Task<string> PredictRiskAsync(RiskInput input);
    }
}
