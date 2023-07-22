// using System.Text.RegularExpressions;
// // using System.Collections;
// // List<int> FindAll(string input, string pattern)
// // {
// //     var result = new List<int>();
// //     var currentIndex = 0;
// //     while (currentIndex != input.Length - 1)
// //     {
// //         currentIndex = input.IndexOf(pattern, currentIndex + 1);
// //         if (currentIndex == -1)
// //         {
// //             break;
// //         }
// //         result.Add(currentIndex);
// //     }
// //     return result;
// // }
// // List<int> FindAllAsWord(string input, string pattern)
// // {
// //     var pre_result = FindAll(input, pattern);
// //     var result = new List<int>();
// //     foreach (var item in pre_result)
// //     {
        
// //     }
// //     return result;
// // }
// try
// {
//     var a = 3;
//     var b = +-+-a;
//     Console.WriteLine(b);
// }
// catch (Exception exception)
// {
//     Console.Error.WriteLine(exception);
// }
// finally
// {
//     Console.ReadKey();
// }
// class HtmlSnippet
// {
//     HtmlSnippet(string url)
//     {
//         Url = url;
//     }
//     public static async Task<HtmlSnippet> Get(string url)
//     {
//         HtmlSnippet snippet = new(url);
//         await snippet.Init();
//         return snippet;
//     }
//     public string[] GetReferences()
//     {
//         return HtmlParser.Matches(Code).Select(m => m.Groups[1].Value).ToArray();
//     }
//     public string Url { get; }
//     public string Code = "";
//     public async Task Init()
//     {
//         Code = await (await Client.GetAsync(Url)).Content.ReadAsStringAsync();
//     }
//     static HttpClient Client = new HttpClient();
//     static Regex HtmlParser = new(@"<a\s(?:[^>]*?\s|)href=""([^""]*?)""", RegexOptions.CultureInvariant);
// }
