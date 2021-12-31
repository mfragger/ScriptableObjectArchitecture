using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class DefaultReferenceBehaviourTemplate : MonoBehaviour
{
    //Replace this to your actual Object
    public RefInt SampleReference;

    private void Awake()
    {
#if UNITY_EDITOR
        //Boilerplate code to handle resetting after playmode
        if (SampleReference.ResetAfterPlayMode)
        {
            if (SampleReference.CopyObject == null)
            {
                SampleReference.CopyObject = Instantiate(SampleReference);
            }
            EditorApplication.playModeStateChanged += SampleReference.ReInitCache;
        }
#endif
        //Continue Initializing from here

    }

    private void Start()
    {

    }

    private void Update()
    {

    }
}
