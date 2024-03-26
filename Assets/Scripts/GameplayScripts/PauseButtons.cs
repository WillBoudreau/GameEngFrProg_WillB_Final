using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtons : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject OptionsMenu;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Pause Button
    public void PauseButt()
    {
        Time.timeScale = 0.0f;
        PauseMenu.SetActive(true);
    }
    //Resume Button
    public void ResumeButt()
    {
        Time.timeScale = 1.0f;
        PauseMenu.SetActive(false);
    }
    //Options Button
    public void ControlButt()
    {
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }
    //OptionsBackButton
    public void ControlBackButt()
    {
        PauseMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
