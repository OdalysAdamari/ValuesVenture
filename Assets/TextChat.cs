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

        const string apiKey = "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";

        string firstApproach = "Vamos a crear una historia en partes. Tu seras el narrador que decida las consecuencias de las acciones de mi personajes. La creacion de la historia sera separada por lo que no necesitas adelantar ninguna parte de ella, la siguiente vez que te contacte te enviare lo que ya se sabe de la historia para continuar donde estaba.\r\nA partir de lo siguiente comenzara la historia. Primero deberas crear un entorno inicial donde exista una problematica principal sobre la inseguridad.";
        string history = "";

        public void Start()
        {
            retrieveContext();
        }

        public async void retrieveContext()
        {
            ChatGPT chatbot = new ChatGPT(apiKey);

            string response = await chatbot.GenerateResponse(firstApproach);

            history += "ChatGPT: " + response + '\n';

            gameResponse.text = response;
        }

        public async void GetAnswer()
        {
            #region conexionAPI

            
            ChatGPT chatbot = new ChatGPT(apiKey);

            #endregion

            string userMessage = "";
            

            //Console.Write("Usuario: ");
            //string userMessage = Console.ReadLine();

            history += '\n' + "Usuario: " + userAnswer.text + '\n';

            string response = await chatbot.GenerateResponse(history);


            history += "ChatGPT: " + response + '\n';

            //Console.WriteLine("ChatGPT: " + response);

            gameResponse.text = response;


            //Debug.Log(userAnswer.text);
            //gameResponse.text = userAnswer.text;
        }
    }
}


