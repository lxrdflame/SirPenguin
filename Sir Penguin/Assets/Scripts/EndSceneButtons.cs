using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneButtons : MonoBehaviour
{
    public void OnClickReplay()
    {
        SceneManager.LoadScene("FreeForAll");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

}
