using Domain;

namespace Jada30Core.Common.Event
{
    public class CreateEventDto
    {
        public string Title { get; set; }
        public string TitleAr { get; set; }
        public long TypeId { get; set; }
        public long BranchId { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsForJadah30Customers { get; set; }
        public string SpeakersNames { get; set; }
        public int NumberSeats { get; set; }
        public string SocialMediaLinks { get; set; }
        public bool RegistrationForm { get; set; }
        public bool isFreePaid { get; set; }
        public ICollection<MediaFile>? MediaFiles { get; set; } = new List<MediaFile>();
    }
}
