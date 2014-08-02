namespace InstaSharp.Models.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public class MediaResponse : Response
    {
        /// <summary>
        /// Gets or sets the pagination.
        /// </summary>
        /// <value>
        /// The pagination.
        /// </value>
        public Pagination Pagination { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public Media Data { get; set; }
    }
}
