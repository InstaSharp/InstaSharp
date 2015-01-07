namespace InstaSharp.Models.Responses
{
    /// <summary>
    /// Media Response containing a list of media and pagination
    /// </summary>
    public class MediaResponse : Response
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public Media Data { get; set; }
    }
}
