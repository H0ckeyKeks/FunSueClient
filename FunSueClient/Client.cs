using System;
using System.Collections.Concurrent;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using FunSueClient.Model;
using Newtonsoft.Json;

namespace FunSueClient
{
    public class Client
    {
        private HttpClient httpClient;

        public string BaseUrl { get; set; }
        public Client(string baseUrl)
        {
            this.BaseUrl = baseUrl;
            this.httpClient = new HttpClient();
        }

        private JsonContent ToJsonContent<T>(T obj)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = null
            };

            var content = JsonContent.Create(obj, options: options);
            return content;
        }

        // Method for Converting the response of the server --> Output
        private async Task<T?> Output<T>(HttpResponseMessage response)
        {

            if (response.IsSuccessStatusCode)
            {
                // Get response from server
                string? responseBody = await response.Content.ReadAsStringAsync();

                // Convert response of type JSON into a PingResponse object
                T? convertedResponse = JsonConvert.DeserializeObject<T>(responseBody);

                return convertedResponse;

            }
            else
            {
                Console.WriteLine($"Fehler: {(int)response.StatusCode} ({response.StatusCode})");
                return default(T);
            }
        }
        
        // Ping method (Get-Request)
        public async Task Ping()
        {
            // HTTP GET-Request /ping
            HttpResponseMessage? response = await this.httpClient.GetAsync($"{this.BaseUrl}/api/v1/ping");

            PingResponse? awaitedReturn = await Output<PingResponse>(response);

            Console.WriteLine(awaitedReturn.Message);
        }

        // Greeting method (Get-Request)
        public async Task Greeting(string name)
        {
            HttpResponseMessage? response = await this.httpClient.GetAsync($"{this.BaseUrl}/api/v1/greet?name={name}");

            GreetingResponse? awaitedReturn = await Output<GreetingResponse>(response);

            Console.WriteLine(awaitedReturn.Greeting);
        }

        // CalcAdd Method (Post-Request)
        public async Task CalcAdd(CalcAddRequest request)
        {
            JsonContent? content = ToJsonContent(request);

            HttpResponseMessage? response = await this.httpClient.PostAsync($"{this.BaseUrl}/api/v1/calc/add", content);

            CalcAddResponse? awaitedReturn = await Output<CalcAddResponse>(response);

            // Output
            Console.WriteLine(awaitedReturn.Result);
        }

        // Listing all Authors (Get-Request)
        public async Task ListAuthors()
        {
            HttpResponseMessage? response = await this.httpClient.GetAsync($"{this.BaseUrl}/api/v1/author");

            ListAuthorsResponse? awaitedReturn = await Output<ListAuthorsResponse>(response);

            foreach (Author i in awaitedReturn.Items)
            {
                Console.WriteLine($"{i.AuthorId}, {i.LastName}, {i.FirstName}");
            }
        }

        // Getting the author by its id (Get-Request)
        public async Task GetAuthor(string authorId)
        {
            HttpResponseMessage? response = await this.httpClient.GetAsync($"{this.BaseUrl}/api/v1/author/{authorId}");

            GetAuthorResponse? awaitedReturn = await Output<GetAuthorResponse>(response);

            Console.WriteLine($"{awaitedReturn.AuthorId}, {awaitedReturn.LastName}, {awaitedReturn.FirstName}");
        }

        // Creating a new author (Post-Request)
        public async Task CreateAuthor(CreateAuthorRequest author)
        {
            JsonContent? content = ToJsonContent(author);

            HttpResponseMessage? response = await this.httpClient.PostAsync($"{this.BaseUrl}/api/v1/author", content);

            CreateAuthorResponse? awaitedReturn = await Output<CreateAuthorResponse>(response);

            Console.WriteLine($"{awaitedReturn.AuthorId}, {awaitedReturn.LastName}, {awaitedReturn.FirstName}");
        }

        // Updating an existing author (Put-Request)
        public async Task UpdateAuthor(string authorId, UpdateAuthorRequest updateAuthor)
        {
            JsonContent? content = ToJsonContent(updateAuthor);

            HttpResponseMessage? response = await this.httpClient.PutAsync($"{this.BaseUrl}/api/v1/author/{authorId}", content);

            UpdateAuthorResponse? awaitedReturn = await Output<UpdateAuthorResponse>(response);

            Console.WriteLine($"{awaitedReturn.AuthorId}, {awaitedReturn.LastName}, {awaitedReturn.FirstName}");
        }

        // Delete an author (Delete-Request)
        public async Task DeleteAuthor(string authorId)
        {
            JsonContent? content = ToJsonContent(authorId);
            
            HttpResponseMessage? response = await this.httpClient.DeleteAsync($"{this.BaseUrl}/api/v1/author/{authorId}");

            DeleteAuthorResponse? awaitedReturn = await Output<DeleteAuthorResponse>(response);

            Console.WriteLine($"Author successfully deleted!");
        }
    
        // Listing all books (Get-Request)
        public async Task ListBooks()
        {
            HttpResponseMessage? response = await this.httpClient.GetAsync($"{this.BaseUrl}/api/v1/book");

            ListBooksResponse? awaitedReturn = await Output<ListBooksResponse>(response);

            foreach (Book i in awaitedReturn.Items)
            {
                Console.WriteLine($"{i.BookId}, {i.Title}, {i.PageCount}");
            }
        }
        
        // Creating a new book (Post-Request)
        public async Task CreateBook(CreateBookRequest book)
        {
            JsonContent? content = ToJsonContent(book);

            HttpResponseMessage? response = await this.httpClient.PostAsync($"{this.BaseUrl}/api/v1/book", content);

            CreateBookResponse? awaitedReturn = await Output<CreateBookResponse>(response);

            Console.WriteLine($"{awaitedReturn.BookId}, {awaitedReturn.Title}, {awaitedReturn.PageCount}");
        }
    
        // Getting the book by its id (Get-Request)
        public async Task GetBook(string bookId)
        {
            HttpResponseMessage? response = await this.httpClient.GetAsync($"{this.BaseUrl}/api/v1/book/{bookId}");

            GetBookResponse? awaitedReturn = await Output<GetBookResponse>(response);

            Console.WriteLine($"{awaitedReturn.BookId}, {awaitedReturn.Title}, {awaitedReturn.PageCount}");
        }
    
        // Updating an existing book (Put-Request)
        public async Task UpdateBook(string bookId, UpdateBookRequest updateBook)
        {
            JsonContent? content = ToJsonContent(updateBook);

            HttpResponseMessage? response = await this.httpClient.PutAsync($"{this.BaseUrl}/api/v1/book/{bookId}", content);

            UpdateBookResponse? awaitedReturn = await Output<UpdateBookResponse>(response);

            Console.WriteLine($"{awaitedReturn.BookId}, {awaitedReturn.Title}, {awaitedReturn.PageCount}");
        }

        // Deleting a book (Delete-Request)
        public async Task DeleteBook(string bookId)
        {
            HttpResponseMessage? response = await this.httpClient.DeleteAsync($"{this.BaseUrl}/api/v1/book/{bookId}");

            DeleteBookResponse? awaitedReturn = await Output<DeleteBookResponse>(response);

            Console.WriteLine("Book successfully deleted!");
        }

        // Connecting a book with an author (Post-Request)
        public async Task AddBookToAuthor(string authorId, string bookId)
        {
            HttpResponseMessage? response = await this.httpClient.PostAsync($"{this.BaseUrl}/api/v1/author/{authorId}/book/{bookId}", null);

            ConnectBookAndAuthorResponse? awaitedReturn = await Output<ConnectBookAndAuthorResponse>(response);

            Console.WriteLine($"Book successfully added to author");
        }

        // Connecting an author with a book (Post-Request)
        public async Task AddAuthorToBook(string bookId, string authorId)
        {
            HttpResponseMessage? response = await this.httpClient.PostAsync($"{this.BaseUrl}/api/v1/book/{bookId}/author/{authorId}", null);

            ConnectBookAndAuthorResponse? awaitedReturn = await Output<ConnectBookAndAuthorResponse>(response);

            Console.WriteLine($"Author successfully added to Book");
        }

        // Listing all books by the same author (Get-Request)
        public async Task ListBooksByAuthor(string authorId)
        {
            HttpResponseMessage? response = await this.httpClient.GetAsync($"{this.BaseUrl}/api/v1/author/{authorId}/book");

            ListBooksByAuthorResponse? awaitedReturn = await Output<ListBooksByAuthorResponse>(response);

            foreach (Book i in awaitedReturn.Items)
            {
                Console.WriteLine($"{i.BookId}, {i.Title}, {i.PageCount}");
            }
        }

        // Getting the relation between an author and a book (Get-Request)
        public async Task GetAuthorBookRelation(string authorId, string bookId)
        {
            HttpResponseMessage? response = await this.httpClient.GetAsync($"{this.BaseUrl}/api/v1/author/{authorId}/book/{bookId}");

            GetAuthorBookRelationResponse? awaitedReturn = await Output<GetAuthorBookRelationResponse>(response);

            Console.WriteLine($"{awaitedReturn.AuthorBookRelationId}, {awaitedReturn.AuthorId}, {awaitedReturn.BookId}");
        }

        // Removing an author from a book (Delete-Request)
        public async Task RemoveAuthorFromBook(string bookId, string authorId)
        {
            HttpResponseMessage? response = await this.httpClient.DeleteAsync($"{this.BaseUrl}/api/v1/book/{bookId}/author/{authorId}");

            RemoveConnectionBookAndAuthorRequest? awaitedReturn = await Output<RemoveConnectionBookAndAuthorRequest>(response);

            Console.WriteLine("Author Successfully removed from the book!");
        }

        // Removing a book from an author (Delete-Request)
        public async Task RemoveBookFromAuthor(string authorId, string bookId)
        {
            HttpResponseMessage? response = await this.httpClient.DeleteAsync($"{this.BaseUrl}/api/v1/author/{authorId}/book/{bookId}");

            RemoveConnectionBookAndAuthorRequest? awaitedReturn = await Output<RemoveConnectionBookAndAuthorRequest>(response);

            Console.WriteLine("Book Successfully removed from the author!");
        }

        // Listing all authors by a book (Get-Request)
        public async Task ListAuthorsByBook(string bookId)
        {
            HttpResponseMessage? response = await this.httpClient.GetAsync($"{this.BaseUrl}/api/v1/book/{bookId}/author");

            ListAuthorsByBooksResponse? awaitedReturn = await Output<ListAuthorsByBooksResponse>(response);

            foreach (Author i in awaitedReturn.Items)
            {
                Console.WriteLine($"{i.AuthorId}, {i.FirstName}, {i.LastName}");
            }
        }
    }
}
