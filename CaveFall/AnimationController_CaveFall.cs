using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController_CaveFall : MonoBehaviour
{
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GameObject.Find("Player").GetComponent<Animator>();
        _anim.SetBool("Falling", true);
    }

    public void AnimatorWalking()
    {
        _anim.SetBool("Falling", false);

    }
}
