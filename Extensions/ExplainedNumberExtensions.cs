using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Extensions
{
    public static class ExplainedNumberExtensions
    {
        public static void AddMultiplier(this ref ExplainedNumber explainedNumber, float multiplier)
        {
            explainedNumber.AddFactor(multiplier - 1);
        }

        public static void AddPercentage(this ref ExplainedNumber explainedNumber, int percentage)
        {
            var factor = (1f - (percentage / 100f)) * -1;

            explainedNumber.AddFactor(factor);
        }
    }
}
