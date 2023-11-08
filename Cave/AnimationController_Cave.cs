using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController_Cave : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _sp;
    private UIManager _uiManager;
    [SerializeField]
    private float alphaStart = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _anim.SetBool("Falling", false);
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        _uiManager.SaveColor(0, 0, 0, alphaStart);


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AnimatorFalling()
    {
        _anim.SetBool("Falling", true);
    }

    public void AnimatorWalking()
    {
        _anim.SetBool("Falling", false);
    }


    public void AnimatorMakeFist()
    {
        _anim.SetTrigger("MakeFist");
    }


}
