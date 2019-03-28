using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    public PlayerController Player;

    public float moveSpeed;
    private float originalMoveSpeed;
    Animator m_Animator;
    public GameObject shotSpawn;
    public List<GameObject> bullets;
    private float nextFire;
    public float fireRate;
    public float reloadTime;

    public float dashAttackCooldown;
    public float dashAttackCooldownCounter;

    public int indexMode;
    private int indexCount;

    Vector3 HighestLineVec;
    Vector3 LowestLineVec;

    Vector2 slide;

    bool isMovingUp = true;
    bool isInIntro = true;
    public bool isInDash = false;

    public float randomDir;

    void Start()
    {
        Player = Player.GetComponent<PlayerController>();
        originalMoveSpeed = moveSpeed;
        m_Animator = GetComponent<Animator>();
        StartCoroutine(entrance());
        StartCoroutine(Shoot());
    }


    void Update()
    {

        if (!isInIntro)
        {
            //Y-Movement
            HighestLineVec = new Vector3(transform.position.x, Player.moveDistance * Player.returnHighestLine(), transform.position.z);
            LowestLineVec = new Vector3(transform.position.x, Player.moveDistance * Player.returnLowestLine(), transform.position.z);
            if (!isInDash)
            {
                if (isMovingUp)
                {
                    transform.position = Vector3.MoveTowards(gameObject.transform.position, HighestLineVec, Time.deltaTime * moveSpeed);
                    if (transform.position.y >= HighestLineVec.y)
                        isMovingUp = false;
                }

                else if (!isMovingUp)
                {
                    transform.position = Vector3.MoveTowards(gameObject.transform.position, LowestLineVec, Time.deltaTime * moveSpeed);
                    if (transform.position.y <= LowestLineVec.y)
                        isMovingUp = true;
                }
            }

            if (Player.transform.position.y < gameObject.transform.position.y + 0.5f &&
                Player.transform.position.y > gameObject.transform.position.y - 0.5f &&
                !isInDash && dashAttackCooldownCounter <= 0)
            {
                StartCoroutine(DashAttack(Player.transform.position, gameObject.transform.position.x));
            }

            dashAttackCooldownCounter -= Time.deltaTime;
            if (dashAttackCooldownCounter < 0)
                dashAttackCooldownCounter = 0;
        }
    }

    IEnumerator Shoot()
    {
        while(true)
        {
            if (!isInIntro)
            {
                bullets.RemoveRange(0, bullets.Count);
                for (int i = 0; i < transform.childCount; i++)
                    bullets.Add(gameObject.transform.GetChild(i).gameObject);


                if (GetComponent<BossStatus>().currentHP > (GetComponent<BossStatus>().MaxHP / 2))
                {
                    indexMode = 0;
                    indexCount = bullets.Count - 6;
                    dashAttackCooldown = 6.1f;
                }

                else
                {
                    indexMode = 2;
                    indexCount = bullets.Count - 5;
                    moveSpeed = originalMoveSpeed * 1.6f;
                    dashAttackCooldown = 3.8f;
                }

                
                if (!isInDash)
                {
                    m_Animator.SetBool("isRangeAttacking", true);
                    for (int i = 0; i < indexCount; i++)
                    {
                        
                        bullets[i].transform.position = gameObject.transform.position;
                        bullets[i].SetActive(true);
                        bullets[i].transform.parent = gameObject.transform.parent.parent;
                        yield return new WaitForSeconds(fireRate);
                    }
                    m_Animator.SetBool("isRangeAttacking", false);
                }
            }
            yield return new WaitForSeconds(reloadTime);
        }
    }

    IEnumerator entrance()
    {
        isInIntro = true;
        yield return new WaitForSeconds(1.2f);
        isInIntro = false;
    }

    IEnumerator DashAttack(Vector3 playerPositionOld, float oldBossX)
    {
        isInDash = true;
        m_Animator.SetBool("isCharging", true);

        randomDir = Random.value - 0.5f;
        if (randomDir >= 0)
        {
            slide = new Vector2(playerPositionOld.x + 3, playerPositionOld.y - 1);
        }
        else
        {
            slide = new Vector2(playerPositionOld.x + 3, playerPositionOld.y + 1);
        }


        while (true)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, playerPositionOld, Time.deltaTime * moveSpeed * 2.2f);
            if (gameObject.transform.position == playerPositionOld)
            {

                while (true)
                {
                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, slide, Time.deltaTime * moveSpeed);

                    if (gameObject.transform.position.x == playerPositionOld.x + 3)
                    {
                        while (true)
                        {
                            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector2(oldBossX, playerPositionOld.y), Time.deltaTime * moveSpeed * 2.5f);
                            if (gameObject.transform.position.x == oldBossX)
                            {
                                m_Animator.SetBool("isCharging", false);

                                dashAttackCooldownCounter = dashAttackCooldown;
                                isInDash = false;
                                yield break;
                            }
                            yield return new WaitForEndOfFrame();
                        }
                    }
                    yield return new WaitForEndOfFrame();
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
