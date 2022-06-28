// See https://aka.ms/new-console-template for more information

static List<List<string>> SearchSuggestions(List<string> reviewsRepository, string userInput)
{
    if (userInput.Length<2) return new List<List<string>>();

    List<List<string>> keywordSuggestions = new();
    
    string input= userInput.ToLower();//time - O(n2), space - O(n2)
    List<string> temp = new();//space - na kraju je O(n1*n2^2) ili O(n1*n2) - ako ne brojimo stringove na koje pokazuju reference
    reviewsRepository.ForEach(x => temp.Add(x.ToLower()));//time - O(n1*?), pretpostavimo O(n1*n2), space(reviewsRepository) - isto

    temp.Sort();//time - O(n1*log n1), space(Sort) - O(n1)

    for (int i = 1; i < input.Length; i++)//time - O(n2)
    {
        string x = input.Substring(0, i+1);//time - O(n2), space - O(n2)
        temp = temp.FindAll(a=>a.StartsWith(x));//time - O(n1*n2)
        if (temp.Count == 0) break;
        keywordSuggestions.Add(temp.Take(3).ToList());//time - O(1)
    }
    return keywordSuggestions;
}

int reviewsRepositoryCount = Convert.ToInt32(Console.ReadLine().Trim());

List<string> reviewsRepository = new();

for (int i = 0; i < reviewsRepositoryCount; i++)
{
    string reviewsRepositoryItem = Console.ReadLine();
    reviewsRepository.Add(reviewsRepositoryItem);
}

string userInput = Console.ReadLine();

List<List<string>> foo = SearchSuggestions(reviewsRepository, userInput);

Console.WriteLine(String.Join("\n", foo.Select(x => String.Join(" ", x))));

