namespace UserLibrary.Application.Companies
{
    /// <summary>
    /// Company information
    /// </summary>
    public record CompanyDto
    {
        /// <summary>
        /// Id of the company
        /// </summary>
        public int Id { get; set; }
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