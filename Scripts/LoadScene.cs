
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public string NextScene;
    public GameObject SceneCamera;
    public GameObject UIF;
    public void Load()
    {
        SceneCamera.SetActive(false);
        UIF.SetActive(false);
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene(NextScene, LoadSceneMode.Additive);
    }
}

