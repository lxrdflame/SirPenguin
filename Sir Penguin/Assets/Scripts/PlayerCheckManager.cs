using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCheckManager : MonoBehaviour
{
    //[SerializeField]
    //private GameObject PlayerManagerGameObject;
    //[SerializeField]
    //private PlayerInputManager PlayerInputManager;
    [SerializeField]
    private PlayerInput playerInput;

    public GameObject Player1MiniMap, Player2MiniMap;
    public GameObject Player1MiniCam, Player2MiniCam;
    [SerializeField] private GameObject Indicator;
    [SerializeField] private Material indicatorMaterial;
    [SerializeField] private MeshRenderer indicatorMesh;
    private void Start()
    {
        //PlayerManagerGameObject = GameObject.FindGameObjectWithTag("Manager");
        //PlayerInputManager = PlayerManagerGameObject.GetComponent<PlayerInputManager>();
        playerInput = GetComponent<PlayerInput>();
        if (playerInput.playerIndex == 0)
        {
            Destroy(Player2MiniMap);
            Destroy(Player2MiniCam);
            indicatorMesh = Indicator.GetComponent<MeshRenderer>();
            indicatorMaterial = indicatorMesh.materials[0];
            indicatorMaterial.color = Color.blue;
        }
        else if (playerInput.playerIndex == 1) 
        {
            Destroy(Player1MiniMap);
            Destroy(Player1MiniCam);
            indicatorMesh = Indicator.GetComponent<MeshRenderer>();
            indicatorMaterial = indicatorMesh.materials[0];
            indicatorMaterial.color = Color.red;
        }

    }


}
