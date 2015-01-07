using System.Collections.Generic;

namespace InstaSharp.Models
{
    public interface IPagination<T>
    {
        Pagination Pagination { get; set; }
        List<T> Data { get; set; }
    }
}