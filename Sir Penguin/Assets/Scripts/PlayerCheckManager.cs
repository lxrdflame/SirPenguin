using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCheckManager : MonoBehaviour
{

    [SerializeField]
    private PlayerInput playerInput;

    [SerializeField] private GameObject Indicator;
    [SerializeField] private Material indicatorMaterial;
    [SerializeField] private MeshRenderer indicatorMesh;
    private void Start()
    {
        
        playerInput = GetComponent<PlayerInput>();
        if (playerInput.playerIndex == 0)
        {
            indicatorMesh = Indicator.GetComponent<MeshRenderer>();
            indicatorMaterial = indicatorMesh.materials[0];
            indicatorMaterial.color = Color.blue;
        }
        else if (playerInput.playerIndex == 1) 
        {
            indicatorMesh = Indicator.GetComponent<MeshRenderer>();
            indicatorMaterial = indicatorMesh.materials[0];
            indicatorMaterial.color = Color.red;
        }

    }


}
