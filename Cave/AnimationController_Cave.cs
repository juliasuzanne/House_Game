using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController_Cave : MonoBehaviour
{
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _anim.SetBool("Falling", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AnimatorFalling()
    {
        _anim.SetBool("Falling", true);
        _anim.SetBool("Walking", false);


    }

    public void AnimatorWalking()
    {
        _anim.SetBool("Walking", true);
        _anim.SetBool("Falling", false);

    }

    public void AnimatorMakeFist()
    {
        _anim.SetTrigger("MakeFist");
    }


}
