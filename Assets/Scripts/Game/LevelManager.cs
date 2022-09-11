using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    

    private void Awake()
    {
        if (levelManager == null)
        {
            levelManager = this;
        }
    }

    public void SceneChanger(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void SceneChanger(string name)
    {
        SceneManager.LoadScene(name);
    }

    // There is no quit button but this function is really necessary!
    public void Quit()
    {
        Application.Quit();
    }
}
