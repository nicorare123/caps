using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartUI : MonoBehaviour
{
    public GameObject gameobject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Startbutton()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void ExiTbutton()
    {
        Application.Quit();
    }
    public void waybutton()
    {
        gameobject.SetActive(false);
    }
    public void waybutton1()
    {
        gameobject.SetActive(true);
    }

}
