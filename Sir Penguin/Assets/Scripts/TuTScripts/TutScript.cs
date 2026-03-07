using UnityEngine;
using UnityEngine.SceneManagement;

public class TutScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnowBall"))
        {
            SceneManager.LoadScene("FreeForAll");
        }
    }
}
