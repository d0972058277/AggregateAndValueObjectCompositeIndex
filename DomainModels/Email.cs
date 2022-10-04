using CSharpFunctionalExtensions;

namespace AggregateAndValueObjectCompositeIndex.DomainModels
{
    public class Email : ValueObject
    {
        private Email() : this(string.Empty) { }

        private Email(string value)
        {
            Value = value;
        }

        public string Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public Result<Email> Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return Result.Failure<Email>("email 不可為空");

            return new Email(email);
        }
    }
}