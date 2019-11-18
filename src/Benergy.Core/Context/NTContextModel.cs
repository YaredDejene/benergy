namespace Benergy.Core.Context
{
    /// <summary>
    /// This contains the data that is cached in the call context
    /// </summary>
    public class NTContextModel
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string FullName
        {
            get
            {
                return $"{this.FirstName} {this.LastName}";
            }
        }
    }
}