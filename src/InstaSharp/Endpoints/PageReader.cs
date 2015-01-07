using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstaSharp.Models;

namespace InstaSharp.Endpoints
{
    internal class PageReader<TResult, T1>
        where T1 : IPagination<TResult>
        where TResult : class
    {
        public async Task<List<TResult>> ReadPages(int userId, Func<int, string, Task<T1>> method, int pageLimit = 0)
        {
            var result = new List<TResult>();
            var pageCount = 0;
            string nextCursor = null;
            do
            {
                var response = await method(userId, nextCursor);
                result.AddRange(response.Data);
                nextCursor = response.Pagination.NextCursor;
                pageCount++;
                if (pageLimit != 0 && pageCount == pageLimit)
                {
                    break;
                }
            } while (!String.IsNullOrEmpty(nextCursor));
            return result;
        }
    }
}