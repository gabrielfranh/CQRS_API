using System.Text.Json.Serialization;

namespace CleanArch.Domain.Entities
{
    public class Member : Entity
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Gender { get; private set; }
        public string? Email { get; private set; }
        public bool? IsActive { get; private set; }

        public Member()
        {
        }

        [JsonConstructor]
        public Member(string? firstName, string? lastName, string? gender, string? email, bool? isActive)
        {

            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            IsActive = isActive;
        }

        public Member(int id, string? firstName, string? lastName, string? gender, string? email, bool? isActive)
        {

            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            IsActive = isActive;
        }

        public void Update(string? firstName, string? lastName, string? gender, string? email, bool? isActive)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            IsActive = isActive;
        }
    }
}
