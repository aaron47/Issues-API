namespace AuthApiTest.Utilities
{
    public sealed class ResponseHelper<T>
    {
        public T? ResponseObject { get; set; }
        public string Message { get; set; }
    }
}
