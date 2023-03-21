namespace MathProApi.Common
{
    /// <summary>
    /// The API request.
    /// </summary>
    public class BigNumberCalculationRequest
    {
        /// <summary>
        /// Customer reference number
        /// </summary>
        public string CustomerReferenceNumber { get; set; } = string.Empty;

        /// <summary>
        /// First operand.
        /// </summary>
        public string Num1 { get; set; } = string.Empty;

        /// <summary>
        /// Second operand.
        /// </summary>
        public string Num2 { get; set; } = string.Empty;
    }
}