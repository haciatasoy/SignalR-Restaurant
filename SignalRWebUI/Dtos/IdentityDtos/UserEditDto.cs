namespace SignalRWebUI.Dtos.IdentityDtos
{
    public class UserEditDto
    {
        public string Mail { get; set; }
        public string NameSurname { get; set; }
        
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
