using System.Collections;
using UnityEngine;

namespace Networking
{
    public class CoroutineHandler : MonoBehaviour
    {
        private static CoroutineHandler _instance;

        public static void Initialize()
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("CoroutineHandler");
                _instance = obj.AddComponent<CoroutineHandler>();
                DontDestroyOnLoad(obj);
            }
        }

        public static Coroutine StartStaticCoroutine(IEnumerator coroutine)
        {
            Initialize();
            return _instance.StartCoroutine(coroutine);
        }
    }
}