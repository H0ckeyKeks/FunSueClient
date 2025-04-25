using FunSueClient;
using FunSueClient.Model;

namespace FunSueClientConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Client funSueClient = new Client("http://192.168.178.70:8000");
            await funSueClient.Greeting("Jasmin");

            
            var request = new CalcAddRequest()
            {
                Number1 = 1,
                Number2 = 2
            };

            await funSueClient.CalcAdd(request);
            await funSueClient.ListAuthors();
            await funSueClient.GetAuthor("680a584a735dcf6250ed979c");
            
            var author = new CreateAuthorRequest()
            {
                FirstName = "Steven",
                LastName = "Cavanagh"
            };
            
            await funSueClient.CreateAuthor(author);
            

            var updateAuthor = new UpdateAuthorRequest()
            {
                FirstName = "Steven",
                LastName = "CavanaghV2"
            };
            await funSueClient.UpdateAuthor("680b96a017003b94de24d7d7", updateAuthor);

            await funSueClient.DeleteAuthor("680b96a017003b94de24d7d7");
            
            var book = new CreateBookRequest()
            {
                Title = "Die Komplizin",
                PageCount = 480
            };

            await funSueClient.CreateBook(book);

            await funSueClient.GetBook("680a92d82bef1b0fceed349f");

            var updateBook = new UpdateBookRequest()
            {
                Title = "Liar2",
                PageCount = 125
            };

            await funSueClient.UpdateBook("680ba1461320ec05b38c00a5", updateBook);

            await funSueClient.DeleteBook("680ba1461320ec05b38c00a5");
            
            await funSueClient.AddBookToAuthor("680b968417003b94de24d7d6", "680bbbdfa576f6da8cc7e19f");
            

            await funSueClient.GetAuthorBookRelation("680b968417003b94de24d7d6", "680bbbdfa576f6da8cc7e19f");

            await funSueClient.RemoveAuthorFromBook("680bbbdfa576f6da8cc7e19f", "680b968417003b94de24d7d6");

            await funSueClient.RemoveBookFromAuthor("680b968417003b94de24d7d6", "680bbbdfa576f6da8cc7e19f");

            await funSueClient.ListBooksByAuthor("680b968417003b94de24d7d6");

            await funSueClient.ListAuthorsByBook("680bbbdfa576f6da8cc7e19f");

            await funSueClient.ListAuthors();
        }
    }
}
