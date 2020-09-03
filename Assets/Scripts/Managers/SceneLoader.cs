using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : Singleton<SceneLoader>
{
    public void LoadScene(int scene)
    {
        AsyncOperation a = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
    }

    public void LoadScene(string scene)
    {
        AsyncOperation a = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
    }
}