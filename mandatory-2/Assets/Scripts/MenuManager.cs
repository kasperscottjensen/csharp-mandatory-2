using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public int level1;
    public int level2;
    public int level3;

    public void LoadLevel1()
    {
        SceneManager.LoadScene(level1);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(level2);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(level3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
