using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DynamicImages;

namespace DynamicImages {
    [CustomEditor(typeof(TextureRequester))]
    public class RequestTextureLoadButton : Editor
    {
        public override void OnInspectorGUI () {
            DrawDefaultInspector();

            TextureRequester thisTarget = target as TextureRequester;
            
            if(GUILayout.Button("Send New Request")) {
                thisTarget.QueueThis ();
            }
        }
    }
}