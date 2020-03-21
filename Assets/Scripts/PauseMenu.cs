using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Pause"))
        {
            Time.timeScale = 0;
            menu.SetActive(true);
        }
    }

    public void PlayButtonPressed()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }
}
