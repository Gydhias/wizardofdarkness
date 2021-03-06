using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void LoadScene();
public delegate void LoadSceneByName(string name);

public class SceneManagementSystem : MonoBehaviour
{
    public static SceneManagementSystem Instance;
    public event LoadScene LoadNextScene;
    public event LoadSceneByName LoadSceneWithName;

    [HideInInspector] public List<string> sceneNames = new List<string>();
    [Tooltip("0 = main Menu, 1 = tutorial, 2 = donjon")] public int actualSceneIndex;

    public void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        sceneNames.Add("Tutorial");
        sceneNames.Add("DungeonScene");
        sceneNames.Add("MainMenu");
    }
    public string GetActualSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
    public void FireLoadSceneEvent()
    {
        SceneManagementSystem_LoadNextScene();
        if (LoadNextScene != null)
        {
            LoadNextScene.Invoke();
        }
    }
    public void FireLoadSceneEvent(string name)
    {
        SceneManagementSystem_LoadNextScene(name);
        if (LoadNextScene != null)
        {
            LoadSceneWithName.Invoke(name);
        }
    }
    public void SceneManagementSystem_LoadNextScene()
    {
        if (actualSceneIndex == 0)//On est au main menu
        {
            StartCoroutine(LoadYourAsyncScene(sceneNames[0]));
            actualSceneIndex = 1;
        }
        else if (actualSceneIndex == 1) // On est au tuto, on veux un donjon
        {
            StartCoroutine(LoadYourAsyncScene(sceneNames[1]));
            actualSceneIndex = 2;
        }
        else if (actualSceneIndex == 2)//On est au donjon,  on reveux le mainMenu
        {
            StartCoroutine(LoadYourAsyncScene(sceneNames[2]));
            actualSceneIndex = 0;
        }
    }
    public void SceneManagementSystem_LoadNextScene(string name)
    {
        StartCoroutine(LoadYourAsyncScene(name));
    }
    IEnumerator LoadYourAsyncScene(string sceneToLoad)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.
        //Fade?
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone && GameUIController.Instance.FadedOut)
        {
            yield return null;
        }

    }
}
