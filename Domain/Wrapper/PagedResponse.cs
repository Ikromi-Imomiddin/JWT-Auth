namespace Domain.Wrapper;

public class PagedResponse<T> : Response<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }

    public PagedResponse(T data, int totalRecords, int pageNumber, int pageSize) : base(data)
    {
        TotalRecords = totalRecords;
        TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    // totalRecords = 105, pageSize = 10, pageNumber = 1
    // totalPages = Ceiling(totalRecords / pageSize) = Ceiling(105 / 10) = 11;

}