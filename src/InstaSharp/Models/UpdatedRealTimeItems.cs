using System.Collections.Generic;

namespace InstaSharp.Models
{
    public class UpdatedRealTimeItems
    {
        public UpdatedRealTimeItems()
        {
            Tags = new Dictionary<string, List<Media>>();
        }
        public Dictionary<string, List<Media>> Tags { get; private set; }

        public void AddTag(string tagName, List<Media> media)
        {
            Tags.Add(tagName, media);
        }
    }
}