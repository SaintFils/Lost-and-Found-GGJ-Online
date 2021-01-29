using UnityEngine;
using UnityEngine.SceneManagement;

//Меню скрипт отвечающий за пермещение между вкладками
public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject MenuBar; //Подключаем Раздел "Меню"
    [SerializeField] private GameObject OptionsBar; //Подключаем Раздел "Опции"

    public void PLayBtn() //Метод загрузки уровня
    {
        SceneManager.LoadScene(1);  // Загружаем следующую сцену
    }

    public void OptionsBtn() // Метод перемещения в Вкладку "Опции"
    {
        MenuBar.SetActive(false); //Делаем не активной Вкладку с Меню
        OptionsBar.SetActive(true);//Делаем активной Вкладку с ОПциями
    }

    public void CLoseOptionsBarBtn() // Метод перемещения в Вкладку "Меню" и выход из "Опции"
    {
        MenuBar.SetActive(true); 
        OptionsBar.SetActive(false);
    }

    public void ExitBtn() //Метод закрытия игры
    {
        Application.Quit();
    }
}
