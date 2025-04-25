using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunSueClient.Model
{
    public class RemoveConnectionBookAndAuthorRequest
    {
        public string BookId { get; set; }
        public string AuthorId { get; set; }
    }
}
