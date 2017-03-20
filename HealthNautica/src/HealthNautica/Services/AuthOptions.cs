namespace HealthNautica.Physician.Services

{
    /// <summary>
    /// Adds a token generation endpoint to an application pipeline.
    /// </summary>
    public class AuthOptions       
    {
        public string Name {get; set;}
        public string Role { get; set; }
        public string UserName { get; set; }
    }
}