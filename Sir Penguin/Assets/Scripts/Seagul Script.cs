using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class SeagulScript : MonoBehaviour
{
    [SerializeField]
    private List<Transform> FlyPoints;
    [SerializeField] private int FlySpeed;
    [SerializeField] private int FlyIndex;
    [SerializeField] private Transform TargetFlyPoint;

    //player Checker
    public List<bool> playerHasPebbles;
    public List<bool> canAttckPlayer;
    [SerializeField] private List<Transform> Players;
    [SerializeField] private int seagullAttackChance;
    [SerializeField] private bool canGenerateNewNumber;

    [SerializeField] private List<GameObject> seagullWarning;
    private bool warningPlaying;

    //Seagull Animations
    private Animator animator;
    AudioSource audioSource;
    private void Start()
    {
        StartCoroutine(SeagullAttackChances());
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        //set Player as Target 
        if (playerHasPebbles[0] && canAttckPlayer[0])
        {
            if (seagullAttackChance == 2)
            {
                TargetFlyPoint = Players[0].transform;
            }
        }
        else if (playerHasPebbles[1] && canAttckPlayer[1])
        {
            if (seagullAttackChance == 3)
            {
                TargetFlyPoint = Players[1].transform;
            }
        }
        else if (!canAttckPlayer[0] && !canAttckPlayer[0])
        {
            TargetFlyPoint = FlyPoints[FlyIndex];
        }
        
        
        if (playerHasPebbles[0] && !canAttckPlayer[0])
        {
            StartCoroutine(ReAttackPlayer());
        }
        else if (playerHasPebbles[1] && !canAttckPlayer[1])
        {
            StartCoroutine(ReAttackPlayer());
        }

        //Check if You can Generate Number 
        if (Players.Contains(TargetFlyPoint))
        {
            canGenerateNewNumber = false;
            animator.SetBool("Attack", true);
            FlySpeed = 25;
            if (!warningPlaying)
            {
                StartCoroutine(PlayWarning());
                audioSource.Play();
            }
        }
        else
        {
            animator.SetBool("Attack", false);
            canGenerateNewNumber = true;
            warningPlaying = false;
            audioSource.Stop();


        }



        transform.LookAt(TargetFlyPoint);
        transform.position = Vector3.MoveTowards(transform.position, TargetFlyPoint.position, FlySpeed * Time.deltaTime);


        float distance = Vector3.Distance(transform.position, TargetFlyPoint.position);
        if (distance <= 0)
        {
            ChangeFlyPoint();
        }

    }

    void ChangeFlyPoint()
    {
        if (FlyPoints.Contains(TargetFlyPoint))
        {
            // Move to next fly point
            FlyIndex = (FlyIndex + 1) % FlyPoints.Count; // This wraps around automatically
            TargetFlyPoint = FlyPoints[FlyIndex];
        }
        else if (Players.Contains(TargetFlyPoint))
        {
            // Switch from player to first fly point
            FlyIndex = 0;
            TargetFlyPoint = FlyPoints[FlyIndex];
            StartCoroutine(SeagullAttackChances());
        }
    }

    IEnumerator SeagullAttackChances()
    {
        if (canGenerateNewNumber)
        {
            seagullAttackChance = Random.Range(0, 5);
            yield return new WaitForSeconds(5);

        }
        else
        {
            yield return new WaitForSeconds(5);

        }
        StartCoroutine(SeagullAttackChances());

    }


    IEnumerator PlayWarning()
    {
        if (Players.Contains(TargetFlyPoint))
        {
            warningPlaying = true;
            if (Players[0] == TargetFlyPoint)
            {
                seagullWarning[0].SetActive(true);
            }
            else if (Players[1] == TargetFlyPoint)
            {
                seagullWarning[1].SetActive(true);
            }
            yield return new WaitForSeconds(0.5f);

            for (int i = 0; i < seagullWarning.Count; i++)
            {
                seagullWarning[i].SetActive(false);
            }
            StartCoroutine(PlayWarning());
        }
    }


    IEnumerator ReAttackPlayer()
    {
        yield return new WaitForSeconds(4);

        if (playerHasPebbles[0])
        {
            canAttckPlayer[0] = true;
        }
        else if (playerHasPebbles[1])
        {
            canAttckPlayer[1] = true;
        }


    }
}
