namespace EndPoint.Request.ViewModelRequest
{
    public class PaginationRequest
    {
        public int Page { get; set; } = 1;

        public int QuantityPerPage { get; set; } = 4;
    }
}