namespace InstaSharp.Models.Responses
{
    public class MediaResponse : Response
    {
        public Pagination Pagination { get; set; }

        public Media Data { get; set; }
    }
}
