using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScipt : MonoBehaviour
{
    [SerializeField]private GameObject DeathBar;

    public void DeathBtn() 
    {
        DeathBar.SetActive(true);
    }

    public void RespawnBtn() 
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene,LoadSceneMode.Single);
    }

    public void MenuBtn() 
    {
        SceneManager.LoadScene("Menu");
    }
}
