public interface IPaginationOptions
{
    int Page { get; set; }
    int PageSize { get; set; }
    int Offset { get; }
    int Limit { get; }
}