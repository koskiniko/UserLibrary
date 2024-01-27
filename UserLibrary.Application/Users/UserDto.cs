using UserLibrary.Application.Companies;

namespace UserLibrary.Application.Users
{
    /// <summary>
    /// User data transfer object
    /// </summary>
    public record UserDto
    {
        /// <summary>
        /// Address
        /// </summary>
        public AddressDto Address { get; set; } = new();

        /// <summary>
        /// Company of the user
        /// </summary>
        public UserCompanyDto? Company { get; set; }

        /// <summary>
        /// Email address of the user
        /// </summary>

        public string Email { get; set; } = null!;

        /// <summary>
        /// Id of the user
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Full name of the user
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Phone number of the user
        /// </summary>
        public string Phone { get; set; } = null!;

        /// <summary>
        /// Username of the user
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// Website of the user
        /// </summary>
        public string Website { get; set; } = null!;
    }
}