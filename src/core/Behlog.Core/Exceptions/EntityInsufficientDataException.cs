namespace Behlog.Core.Exceptions {

    public class EntityInsufficientDataException: BehlogException
    {
        public EntityInsufficientDataException(string fieldName)
            : base(message: $"The field '{fieldName}' is required.") {
            EntityPropertyName = fieldName;
        }

        public string EntityPropertyName { get; set; }
    }
}
