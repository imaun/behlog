namespace Behlog.Core.Exceptions {

    public class EntityDataIsWrongException: BehlogException {

        public EntityDataIsWrongException(string propertyName, object propertyValue = null)
            :base(message: $"The value provided for '{propertyName}' is wrong.") {
            EntityPropertyName = propertyName;
            EntityPropertyValue = propertyValue;
        }

        public string EntityPropertyName { get; set; }
        public object EntityPropertyValue { get; set; }
    }
}
