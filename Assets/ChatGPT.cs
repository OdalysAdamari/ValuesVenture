using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using UnityEngine;

namespace chatgpt
{
    public class ChatGPT : MonoBehaviour
    {
        private readonly string apiKey;
        private readonly string apiUrl = "https://api.openai.com/v1/completions";

        public ChatGPT(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<string> GenerateResponse(string message)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

                var requestBody = new
                {
                    prompt = message,
                    max_tokens = 50,
                    temperature = 0.7,
                    model = "text-davinci-003"
                };

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                Thread.Sleep(5000);
                var response = await client.PostAsync(apiUrl, content);
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                dynamic responseData = JsonConvert.DeserializeObject<dynamic>(responseJson);
                string completionText = responseData.choices[0].text;

                return completionText;
            }
        }
    }
}
