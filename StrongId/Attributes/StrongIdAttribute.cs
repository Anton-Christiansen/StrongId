namespace StrongId.Attributes
{
    /// <summary>
    /// Source generating a strongly typed identifier and property
    /// The strongly typed record will be named after the class with an "Id" appended at the end
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class StrongIdAttribute : Attribute
    {
        /// <summary>
        /// The Type of the identifier (defaults to System.Guid)
        /// </summary>
        public Type ParameterType { get; set; } = typeof(Guid);
    
        /// <summary>
        /// The property name in the marked class (defaults to "Id")
        /// </summary>
        public string ParameterName { get; set; } = "Id";
    }
}
