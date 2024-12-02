

namespace BountyHunters.Web.ViewModels.BountyHunter
{
    public class BountyHunterInputModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Rank { get; set; } = null!;

        public string Bio { get; set; } = null!;

        public int CaptureCount { get; set; } = 0;
    }
}
