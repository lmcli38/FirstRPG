using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] string levelToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            SceneManager.LoadScene(levelToLoad);
    }

}
