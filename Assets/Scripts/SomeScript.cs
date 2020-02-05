using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
    

class SomeScript : MonoBehaviour
{
    private const string pluginName = "BULLETHOLICPHYSICS.dll";
    [DllImport(pluginName)]


    private static extern float FooPluginFunction();

    void Awake()
    {
        // Calls the FooPluginFunction inside the plugin
        // And prints 5 to the console
        Debug.Log(FooPluginFunction());
    }
}