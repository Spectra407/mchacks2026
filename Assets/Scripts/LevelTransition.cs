using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelTransition : MonoBehaviour
{
    int index;

    void Start()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            index = currentScene.buildIndex;
            Debug.Log(index);
        }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        Debug.Log("Player reached the end!");
        SceneManager.LoadScene(index + 1);
    }
}
