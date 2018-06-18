using System.Collections.Generic;

namespace Contacts.Api.Http
{
    public class ResourceCollection<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public long TotalItems { get; set; }
        public List<T> Items { get; set; }        
        public ResourceCollection()
        {        
            Items = new List<T>();         
        }
    }
}