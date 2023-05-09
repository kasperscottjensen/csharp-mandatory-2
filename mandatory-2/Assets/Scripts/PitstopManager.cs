using UnityEngine;
using UnityEngine.SceneManagement;

public class PitstopManager : MonoBehaviour
{

    [SerializeField] private int mainMenu;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

}
