namespace ChatRealTime.Domain.Models
{
    public class AppSettings
    {
        public string SqlConnection { get; set; } = string.Empty;
        public string FileSizeLimitInBytes { get; set; } = string.Empty;
        public IEnumerable<string> AllowedExtensions { get; set; } = new List<string>();
    }
}
