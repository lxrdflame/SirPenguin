using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    [SerializeField] private float HP;
    [SerializeField] private int MaxHP;
    [SerializeField] private Slider HPSlider;

    private PlayerInput playerInput;
    private bool CanRegen;
    public float HitTimer;
    //Player1 Settings
    private GameObject playerHPSliderGameObject;
    public int maxTimer = 10;

    private void Start()
    {
        ResetHp();
        playerInput = GetComponent<PlayerInput>();

        if (playerInput != null)
        {
            if (playerInput.playerIndex == 0)
            {
                playerHPSliderGameObject = GameObject.FindGameObjectWithTag("P1HpSlider");
                HPSlider = playerHPSliderGameObject.GetComponent<Slider>();
            }
            else
            {
                playerHPSliderGameObject = GameObject.FindGameObjectWithTag("P2HpSlider");
                HPSlider = playerHPSliderGameObject.GetComponent<Slider>();

            }
        }
    }
    private void Update()
    {
        HPSlider.value = HP;

        if (HP < MaxHP && HitTimer <= 0)
        {
            HP += Time.deltaTime * 5;
        }

        if (HitTimer > 0)
        {
            HitTimer -= Time.deltaTime;
        }
    }

    public void DepleteHP(int amount)
    {
        HP -= amount;
    }

    public void ResetHp()
    {
        HP = MaxHP;
    }

    public void HpRestore()
    {
        HitTimer = maxTimer;
    }
}
