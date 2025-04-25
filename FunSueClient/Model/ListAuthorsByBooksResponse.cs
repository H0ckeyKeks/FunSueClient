using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunSueClient.Model
{
    public class ListAuthorsByBooksResponse
    {
        public List<Author> Items { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
    }
}
