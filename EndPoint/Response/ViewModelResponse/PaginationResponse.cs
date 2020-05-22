namespace EndPoint.Response.ViewModelResponse
{
    public class PaginationResponse<T>
    {
        public T Response { get; set; }

       public int TotalAmountPages { get; set; }
    }
}
