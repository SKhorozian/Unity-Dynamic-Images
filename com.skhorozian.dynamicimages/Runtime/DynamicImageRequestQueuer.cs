using System.Collections.Generic;
using UnityEngine;
using System;

namespace DynamicImages {
    public class DynamicImageRequestQueuer : MonoBehaviour
    {
        Queue <TextureLoad> queue = new Queue<TextureLoad> ();
        [SerializeField] int count;

        public void QueueURL (string url, Func<Texture, bool> onSucceed, Func<bool> onFail) {
            queue.Enqueue (new TextureLoad (url, onSucceed, onFail));
            count++;
            if (queue.Count == 1)
                StartCoroutine (queue.Peek ().GetTexture()); //Else, Start Coroutine.
        }

        void Update () {
            if (queue.Count == 0) return; //If there are none on the Queue, we return.

            if (queue.Peek ().isDone) { //If it is done,
                queue.Dequeue (); //we dequeue
                count--;
                if (queue.Count == 0) return; //If there are none on the Queue, we return.
                StartCoroutine (queue.Peek ().GetTexture()); //and Start Coroutine.
            }
        }

    }
}