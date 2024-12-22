using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Networking
{
    using UnityEngine;
    using UnityEngine.Networking;
    using System.Collections;

    public class ServerManager
    {
        private const string ApiUrl = "https://wadahub.manerai.com/api/inventory/status";
        private const string AuthToken = "Bearer kPERnYcWAY46xaSy8CEzanosAgsWM84Nx7SKM4QBSqPq6c7StWfGxzhxPfDh8MaP";

        public void SendItemEvent(string itemId, string action)
        {
            string postData = $"{{\"itemId\":\"{itemId}\",\"action\":\"{action}\"}}";
            CoroutineHandler.StartStaticCoroutine(PostRequest(ApiUrl, postData));
        }

        private IEnumerator PostRequest(string url, string jsonData)
        {
            using UnityWebRequest request = new UnityWebRequest(url, "POST");
            {
                byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");
                request.SetRequestHeader("Authorization", AuthToken);

                Debug.Log($"Отправка запроса: {jsonData}");

                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log($"Ответ от сервера: {request.downloadHandler.text}");
                }
                else
                {
                    Debug.LogError($"Ошибка: {request.error}\nОтвет: {request.downloadHandler.text}");
                }
            }
        }
    }
}