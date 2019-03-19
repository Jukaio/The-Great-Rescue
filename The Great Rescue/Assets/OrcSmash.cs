using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcSmash : MonoBehaviour
{
    public GameObject AnimatorChild;
    private Animator Anim;
    public float length;
    AnimatorStateInfo CurrentStateInfo;

    void Start()
    {
        Anim = AnimatorChild.GetComponent<Animator>();
        CurrentStateInfo = Anim.GetCurrentAnimatorStateInfo(0);
        length = CurrentStateInfo.length;
        StartCoroutine(OrcAttack(CurrentStateInfo.length));
    }

    IEnumerator OrcAttack(float length)
    {
        while (true)
        {
            yield return new WaitForSeconds((length / 3) * 2);
            gameObject.GetComponent<Collider2D>().offset = new Vector2(-2f, gameObject.GetComponent<Collider2D>().offset.y);

            yield return new WaitForSeconds(length / 3);
            gameObject.GetComponent<Collider2D>().offset = new Vector2(0, gameObject.GetComponent<Collider2D>().offset.y);

        }
    }


    void Update()
    {

    }
}
