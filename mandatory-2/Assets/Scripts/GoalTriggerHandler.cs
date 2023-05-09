using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTriggerHandler : MonoBehaviour
{

    [SerializeField] private int winScreen;
    [SerializeField] private int lossScreen;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Equals("Game Goal Trigger"))
        {
            SceneManager.LoadScene(winScreen);
        } else if (collision.gameObject.name.Equals("Player Goal Trigger"))
        {
            SceneManager.LoadScene(lossScreen);
        }
    }
    
}
