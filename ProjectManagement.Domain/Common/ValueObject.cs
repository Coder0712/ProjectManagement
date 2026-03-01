namespace ProjectManagement.Domain.Common
{
    /// <summary>
    /// The value object base.
    /// </summary>
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        /// <summary>
        /// Gets the values of the value object.
        /// </summary>
        /// <returns>A list with all values.</returns>
        public abstract IEnumerable<object> GetAtomicValues();

        /// <summary>
        /// Equals two value objects.
        /// </summary>
        /// <param name="obj">The second value object.</param>
        /// <returns>True if the value objects are equal.</returns>
        public override bool Equals(object? obj)
            => obj is ValueObject value && ValuesAreEqual(value);

        public override int GetHashCode()
            => GetAtomicValues().Aggregate(default(int), HashCode.Combine);

        /// <summary>
        /// Checks if the values object the value objects are equal.
        /// </summary>
        /// <param name="valueObj">The second value object.</param>
        /// <returns>True if the values are equal.</returns>
        private bool ValuesAreEqual(ValueObject valueObj)
        {
            return GetAtomicValues().SequenceEqual(valueObj.GetAtomicValues());
        }

        /// <summary>
        /// Equals value objects.
        /// </summary>
        /// <param name="other">The second value object.</param>
        /// <returns>True if value objects are equal.</returns>
        public bool Equals(ValueObject? other)
            => other is not null && ValuesAreEqual(other);
    }
}
