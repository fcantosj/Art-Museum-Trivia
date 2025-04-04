/* This script is for importing JSON files and creating scriptable objects
 / The format will depend on the structure of the JSON file.
 / THIS FILE MUST BE IN THE "Editor" folder you created in the assets folder. 
 / This will output data to Resources/Questions folder
*/

using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

public class JSONtoSO
{
    private static string questionsJSONPath = "/Resources/Questions/questions.json";
    private static string questionsPath = "Assets/Resources/Questions/Meninas/";

    [MenuItem("Utilities/Generate Questions-JSON")]
    public static async Task GeneratePhrasesAsync()
    {
        string jsonContent = File.ReadAllText(Application.dataPath + questionsJSONPath);
        List<QuestionJson> questions = JsonUtility.FromJson<QuestionList>(jsonContent).trivia;

        foreach (var questionJson in questions)
        {
            await Task.Run(() =>
            {
                // Prepare data on a background thread
                string[] answers = new string[questionJson.respuestas.Count];
                for (int i = 0; i < questionJson.respuestas.Count; i++)
                {
                    answers[i] = questionJson.respuestas[i].texto;
                }
                string questionName = questionJson.pregunta.Replace("?", "").Replace("¿", "");

                // Switch to the main thread for Unity-specific operations
                UnityEditor.EditorApplication.delayCall += () =>
                {
                    if (!Directory.Exists(questionsPath))
                    {
                        Directory.CreateDirectory(questionsPath);
                    }

                    QuestionData questionData = ScriptableObject.CreateInstance<QuestionData>();
                    questionData.question = questionJson.pregunta;
                    questionData.answers = answers;
                    questionData.name = questionName;

                    AssetDatabase.CreateAsset(questionData, $"{questionsPath}/{questionName}.asset");
                    AssetDatabase.SaveAssets();
                };
            });
        }

        Debug.Log($"Generated Questions");
    }
}

[System.Serializable]
public class QuestionJson
{
    public string pregunta;
    public List<RespuestaJson> respuestas;
}

[System.Serializable]
public class RespuestaJson
{
    public string texto;
    public bool correcto;
}

[System.Serializable]
public class QuestionList
{
    public List<QuestionJson> trivia;
}
