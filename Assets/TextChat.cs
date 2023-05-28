using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace chatgpt
{
    public class TextChat : MonoBehaviour
    {
        [SerializeField] TMP_InputField userAnswer;
        [SerializeField] TMP_Text gameResponse;
        // Start is called before the first frame update


        public async void GetAnswer()
        {
            #region conexionAPI

            string apiKey = "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";
            ChatGPT chatbot = new ChatGPT(apiKey);

            #endregion

            string userMessage = "";


            //Console.Write("Usuario: ");
            //string userMessage = Console.ReadLine();

            userMessage = userAnswer.text;

            //userMessage += "Usuario: " + userMessage + Environment.NewLine;

            string response = await chatbot.GenerateResponse(userMessage);



            //userMessage += "ChatGPT: " + response + Environment.NewLine;

            //Console.WriteLine("ChatGPT: " + response);

            gameResponse.text = response;


            //Debug.Log(userAnswer.text);
            //gameResponse.text = userAnswer.text;
        }
    }
}


