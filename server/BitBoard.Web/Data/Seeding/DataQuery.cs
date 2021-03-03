// using System.Collections.Generic;
// using System.IO;
// using System.Net.Http;
// using System.Text;
// using System.Threading.Tasks;

// namespace API.Data.Seeding
// {
//     public class DataQuery
//     {
//         private readonly string _baseUrl = "https://next.json-generator.com/api/json/get";
//         private readonly List<QueryConfig> _configs;

//         public DataQuery()
//         {
//             _configs = ParseConfiguration();
//         }

//         public async Task GenerateDataAsync()
//         {
//             foreach (var config in _configs)
//             {
//                 var configUri = $"{_baseUrl}/{config.Id}";

//                 HttpClient client = new HttpClient();
//                 var sb = new StringBuilder();

//                 for (int i = 0; i < config.Iterations; i++)
//                 {
//                     HttpResponseMessage response = await client.GetAsync(configUri);
//                     response.EnsureSuccessStatusCode();
//                     string responseBody = await response.Content.ReadAsStringAsync();

//                     var trimChars = new char[] { '[', ']' };

//                     responseBody = responseBody.Trim();
//                     responseBody = responseBody.Trim(trimChars);
                    
//                     if (i != 0) sb.Append(',');
//                     sb.Append(responseBody);
//                 }
                
//                 var outputPath = Path.Combine("Data", "Seeding", "Generated", $"{config.Model}.json");
//                 await System.IO.File.WriteAllTextAsync(outputPath, $"[{sb.ToString()}]");
//             }
//         }

//         private List<QueryConfig> ParseConfiguration()
//         {
//             var currentDir = Directory.GetCurrentDirectory();
//             var configFile = Path.Combine(currentDir, "Data", "Seeding", "Configuration.json");
//             var json = System.IO.File.ReadAllText(configFile);
//             return System.Text.Json.JsonSerializer.Deserialize<List<QueryConfig>>(json);
//         }
//     }

//     public class QueryConfig
//     {
//         public string Model { get; set; }
//         public int PerRequest { get; set; }
//         public int Iterations { get; set; }
//         public string Id { get; set; }
//     }
// }