using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string targetSceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TransitionScene()
    {
        TransitionScene(targetSceneName);
    }

    public void TransitionScene(string targetScene)
    {
        SceneManager.LoadScene(targetScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
