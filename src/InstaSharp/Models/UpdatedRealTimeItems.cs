using System.Collections.Generic;

namespace InstaSharp.Models
{
    public class UpdatedRealTimeItems
    {
        public UpdatedRealTimeItems()
        {
            TagMedia = new Dictionary<string, List<Media>>();
        }
        public Dictionary<string, List<Media>> TagMedia { get; private set; }

        public void AddTag(string tagName, List<Media> media)
        {
            TagMedia.Add(tagName, media);
        }
    }
} 