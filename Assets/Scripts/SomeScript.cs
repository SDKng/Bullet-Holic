using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


class SomeScript : MonoBehaviour
{

    int countDown;
    private const string pluginName = "BULLETHOLICPHYSICS.dll";
    [DllImport(pluginName)] private static extern float FooPluginFunction(float X);
    [DllImport(pluginName)] private static extern int IterateANumber();

    [DllImport(pluginName)] private static extern void CreateBullet(float PosX, float PosY, float VelX, float VelY, float AccX, float AccY, int ID, int Alignment);
    [DllImport(pluginName)] private static extern void UpdatePhysics();

    [DllImport(pluginName)] private static extern float ReturnData(int ID, int DataIndex);

    [DllImport(pluginName)] private static extern bool RemoveBullet(int ID, bool useTrue);

    void Awake()
    {
        // Calls the FooPluginFunction inside the plugin
        // And prints 5 to the console


        countDown = 10;
        CreateBullet(1.0f, 1.0f, 0.5f, 0.0f, 0.1f, 0.0f, 1, 1);



    }

    void Update()
    {

        Debug.Log(ReturnData(1, 1));
        UpdatePhysics();

        countDown--;

        if (countDown < 0)
        {

            RemoveBullet(1, true);
            Debug.Log("tried to remove");
        }
    }
}