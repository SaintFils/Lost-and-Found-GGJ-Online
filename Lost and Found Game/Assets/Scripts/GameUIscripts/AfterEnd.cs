using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterEnd : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject Titri;

    private void Start()
    {
        Invoke("OffScreen",7);
    }


    private void OffScreen() 
    {
        panel.SetActive(false);
        button.SetActive(true);
        Titri.SetActive(true);
    }

    public void ToMEnu() 
    {
        SceneManager.LoadScene("Menu");
    }
}
