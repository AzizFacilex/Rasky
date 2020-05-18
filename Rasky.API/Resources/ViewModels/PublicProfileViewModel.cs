namespace Rasky.API.ViewModels
{
    public class PublicProfileViewModel
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserExperience { get; set; }
        public string UserExperienceText { get ; set; }
        public string UserImage { get; set; }
        public string UserSummary { get; set; }
        public float UserRating { get; set; }
        public int UserRides { get; set; }
        public string UserSince { get; set; }
        public string PrefMusicText { get; set; }
        public string PrefSmokeText { get; set; }
        public string PrefDiscussionText { get; set; }
        public string PrefPetText { get; set; }
        public bool PrefMusic { get; set; }
        public bool PrefSmoke { get; set; }
        public bool PrefDiscussion { get; set; }
        public bool PrefPet { get; set; }
        public bool IdVerified { get; set; }
        public bool MobileVerified { get; set; }
        public bool EmailVerified { get; set; }
        public string IdVerifiedText { get; set; }
        public string MobileVerifiedText { get; set; }
        public string EmailVerifiedText { get; set; }
    }
}