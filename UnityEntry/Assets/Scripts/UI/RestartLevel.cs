using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ReloadCurrentLevel);
    }
    private void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
