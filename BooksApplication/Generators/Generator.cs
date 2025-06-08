using BooksApplication.Models;
using Bogus;

namespace BooksApplication.Generators
{
    public class Generator
    {
        public List<Book> GenerateBooks(string locale, int userSeed, int page, double minLikes, double review, int count = 20)
        {
            Randomizer.Seed = new Random(userSeed + page);
            var faker = new Faker(locale);
            var books = new List<Book>();

            int attempts = 0;
            while (books.Count < count && attempts < count * 10)
            {
                attempts++;

                var authorList = new List<string> { faker.Name.FullName() };
                if (faker.Random.Bool())
                    authorList.Add(faker.Name.FullName());

                string reviews = "";
                if (faker.Random.Double(0, 1) < review)
                {
                    int revCount = faker.Random.Int(1, 5);
                    for (int r = 0; r < revCount; r++)
                    {
                        var author = faker.Name.FullName();
                        var text = faker.Lorem.Sentence();
                        reviews += $"- {text} ({author})\n";
                    }
                    reviews = reviews.TrimEnd('\n');
                }

                int likesValue = faker.Random.Int(0, 20); 
                if (likesValue >= minLikes)
                {
                    books.Add(new Book
                    {
                        Index = page * count + books.Count + 1,
                        ISBN = faker.Commerce.Ean13(),
                        Title = faker.Lorem.Sentence(3).TrimEnd('.'),
                        Author = string.Join(", ", authorList),
                        Publisher = faker.Company.CompanyName() + ", " + faker.Date.Past(20).Year,
                        Likes = likesValue,
                        Description = faker.Lorem.Paragraph(),
                        Cover = $"https://placehold.co/100x150?text={Uri.EscapeDataString(faker.Random.Word())}",
                        Reviews = reviews
                    });
                }
            }

            return books;
        }
    }
}
