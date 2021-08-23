using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DynamicImages {
    [RequireComponent (typeof (Renderer))]
    public class TextureRequester : MonoBehaviour
    {
        [SerializeField] DynamicImageRequestQueuer queuer;
        [SerializeField] string url;

        [Space (10), SerializeField] new Renderer renderer;

        void Awake () {
            if (!renderer)
                renderer = GetComponent <Renderer> ();
        }

        // Start is called before the first frame update
        void Start() {
            QueueThis ();
        }

        public void QueueThis () {
            queuer.QueueURL (url, OnSucceed, OnFail);
        }

        bool OnSucceed (Texture texture) {
            Destroy (renderer.material.mainTexture);
            renderer.material.SetTexture ("_MainTex", texture);
            Debug.Log ("Recieved Texture!");
            return false;
        }

        bool OnFail () {
            return false;
        }
    }
}