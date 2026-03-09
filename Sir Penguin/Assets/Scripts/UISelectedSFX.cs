using UnityEngine;
using UnityEngine.EventSystems;

public class UISelectSound : MonoBehaviour, ISelectHandler
{
    public AudioSource audioSource;
    public AudioClip selectSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnSelect(BaseEventData eventData)
    {
        audioSource.PlayOneShot(selectSound);
    }
}