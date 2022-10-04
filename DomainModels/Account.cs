using AggregateAndValueObjectCompositeIndex.Abstractions;

namespace AggregateAndValueObjectCompositeIndex.DomainModels
{
    public class Account : Aggregate<Guid>
    {
#nullable disable warnings
        public Account() { }
#nullable enable warnings

        public Account(Guid id, string username, string password, Email email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public string Username { get; }
        public string Password { get; }
        public Email Email { get; }

        public static Account Register(string username, string password, Email email)
        {
            var id = Guid.NewGuid();
            var account = new Account(id, username, password, email);
            return account;
        }
    }
}