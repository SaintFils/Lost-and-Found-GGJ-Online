using UnityEngine;
using UnityEngine.SceneManagement;

//Скрипт позволяющий открыть меню паузы во время игры с помощью клавиши ESC
public class PauseControl : MonoBehaviour
{
    [SerializeField] private GameObject PauseBar;
    [SerializeField] private GameObject OptionsBar_PauseMenu;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))  //При нажатии на ESCAPE открывается меню паузы и игра стопиться
        {
            PauseBar.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Resume() 
    {
        PauseBar.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenOptionsBar() //Открытие меню опции
    {
        OptionsBar_PauseMenu.SetActive(true);
        PauseBar.SetActive(false);
    }

    public void CloseOptionsBar() //Закрытие меню опции
    {
        OptionsBar_PauseMenu.SetActive(false);
        PauseBar.SetActive(true);
    }

    public void MenuBtn() //Метод перехода в меню
    {
        SceneManager.LoadScene("Menu");   
    }

    public void ExitBtn() 
    {
        Application.Quit();
    }
}
