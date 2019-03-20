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
    }




    IEnumerator OrcAttack(float length)
    {
        Anim.SetBool("activate", true);

        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<Collider2D>().offset = new Vector2(-2f, gameObject.GetComponent<Collider2D>().offset.y);
        yield return new WaitForSeconds(10);
    }


    void Update()
    {
        if (gameObject.transform.position.x < -4.2f && Anim.GetBool("activate") == false)
            StartCoroutine(OrcAttack(CurrentStateInfo.length));
    }
}
