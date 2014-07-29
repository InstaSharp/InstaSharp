namespace InstaSharp.Models.Responses {
    public abstract class Response
    {
        public Meta Meta { get; set; }

        /// <summary>
        /// The total number of calls allowed within the 1-hour window
        /// </summary>
        public int RateLimitLimit { get; set; }

        /// <summary>
        /// The remaining number of calls available to your app within the 1-hour window
        /// </summary>
        public int RateLimitRemaining { get; set; }
    }
}
