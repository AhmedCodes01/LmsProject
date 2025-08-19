namespace Lms.Core
{
    public class User
    {
        public int Id { get; set; }          // Unique ID
        public string Name { get; set; }     // Full name
        public string Email { get; set; }    // Contact email

        public User(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Id}: {Name} ({Email})";
        }
    }
}
