namespace Row13.RpnCalculator.Operators
{
    public interface ITokenResult<T> : ITokenResult
    {
        T Result { get; set; }
    }

    public interface ITokenResult
    {
        TokenType TokenType { get; set; }
    }
}