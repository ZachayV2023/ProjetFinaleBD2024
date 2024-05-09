namespace ProjetFinalV2.Models
{
    public class FilteredDownloadsViewModel
    {
        public string LibraryNameFilter { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public IEnumerable<VueUserDownload> Downloads { get; set; }
    }
}