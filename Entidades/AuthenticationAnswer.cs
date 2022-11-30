namespace Vehicles.Entities
{
    public class AuthenticationAnswer
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}