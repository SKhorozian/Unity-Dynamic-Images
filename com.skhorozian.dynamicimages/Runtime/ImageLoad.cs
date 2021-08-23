using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Networking;

namespace DynamicImages {
    [System.Serializable]
    public class TextureLoad 
    {
        [SerializeField] string url;
        [SerializeField] bool done;
        Func<Texture, bool> onSucceed;
        Func<bool> onFail;

        public TextureLoad (string url, Func<Texture, bool> onSucceed, Func<bool> onFail) {
            this.url = url;
            this.onSucceed = onSucceed;
            this.onFail = onFail;
            this.done = false;
        }

        public IEnumerator GetTexture () {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture (url);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success) {
                Debug.Log(www.error);
                onFail ();
            } else {
                Texture texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                onSucceed (texture);
                www.Dispose();
            }

            done = true;
        }

        public bool isDone {get {return done;}}

    }
}