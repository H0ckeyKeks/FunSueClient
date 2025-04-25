using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunSueClient.Model
{
    public class CreateBookRequest
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
    }
}
