using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Level1");
    }
}
