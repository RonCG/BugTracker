namespace BugTracker.Data.Helpers
{
    /// <summary>
    /// Define JWT Settings
    /// </summary>
    public class JWTSettings
    {
        public string Secret { get; set; }
        public int DurationDays { get; set; }
    }
}
