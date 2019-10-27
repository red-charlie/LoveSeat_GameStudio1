using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("Apartment0");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("_Entry");
    }
}