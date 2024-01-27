namespace UserLibrary.Application.Users
{
    /// <summary>
    /// User's company information
    /// </summary>
    public record UserCompanyDto
    {
        /// <summary>
        /// Dunno
        /// </summary>
        public string Bs { get; set; } = null!;
        /// <summary>
        /// Catch phrase
        /// </summary>
        public string CatchPhrase { get; set; } = null!;
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = null!;
    }
}