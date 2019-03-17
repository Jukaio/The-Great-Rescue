using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    public PlayerController Player;
    public float moveSpeed;
    private float originalMoveSpeed;

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

    bool isMovingUp = true;
    public bool isInDash = false;

    void Start()
    {
        Player = Player.GetComponent<PlayerController>();
        originalMoveSpeed = moveSpeed;



        StartCoroutine(Shoot());
    }

    void Update()
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

        if(Player.transform.position.y < gameObject.transform.position.y + 0.5f &&
            Player.transform.position.y > gameObject.transform.position.y - 0.5f &&
            !isInDash && dashAttackCooldownCounter <= 0)
        {
            StartCoroutine(DashAttack(Player.transform.position, gameObject.transform.position.x));
        }

        dashAttackCooldownCounter -= Time.deltaTime;
        if (dashAttackCooldownCounter < 0)
            dashAttackCooldownCounter = 0;
        
    }

    IEnumerator Shoot()
    {
        while(true)
        {

            bullets.RemoveRange(0, bullets.Count);
            for (int i = 0; i < transform.childCount; i++)
                bullets.Add(gameObject.transform.GetChild(i).gameObject);

            switch (indexMode)
            {
                case 0:
                    indexCount = bullets.Count - 7;
                    break;
                case 1:
                    indexCount = bullets.Count - 6;
                    break;
                case 2:
                    indexCount = bullets.Count - 5;
                    moveSpeed = originalMoveSpeed * 2;
                    break;
            }

            if (!isInDash)
            {
                for (int i = 0; i < indexCount; i++)
                {
                    bullets[i].transform.position = gameObject.transform.position;
                    bullets[i].SetActive(true);
                    bullets[i].transform.parent = gameObject.transform.parent.parent;
                    yield return new WaitForSeconds(fireRate);
                }
            }
            yield return new WaitForSeconds(reloadTime);
        }
    }

    IEnumerator DashAttack(Vector3 playerPositionOld, float oldBossX)
    {
        isInDash = true;
        while (true)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, playerPositionOld, Time.deltaTime * moveSpeed * 2);
            Debug.Log("Dash");
            if (gameObject.transform.position == playerPositionOld)
            {
                while (true)
                {
                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector2(oldBossX, playerPositionOld.y), Time.deltaTime * moveSpeed);
                    if (gameObject.transform.position.x == oldBossX)
                    {
                        Debug.Log("Dash");
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
}
