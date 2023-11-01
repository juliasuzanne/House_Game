using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCaveFall : MonoBehaviour
{
    private Hand _player;
    private Animator _anim;

    private bool obj1;
    private bool obj2;
    private bool obj3;

    private SpawnManager spawnManager;


    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _player = GameObject.Find("Player").GetComponent<Hand>();
        _player.MoveableTrue();
        _anim = GameObject.Find("Background").GetComponent<Animator>();

    }

    void Update()
    {
        Debug.Log("BAND IS " + obj1);
        Debug.Log("LEAF IS " + obj2);
        Debug.Log("ROCK IS " + obj3);

    }

    // Update is called once per frame
    public void ChangeObj1()
    {
        obj1 = true;

    }
    public void ChangeObj2()
    {
        obj2 = true;

    }
    public void ChangeObj3()
    {
        obj3 = true;


    }

    public void CheckObjs()
    {
        if (obj1 == true && obj2 == true && obj3 == true)
        {
            spawnManager.OnPlayerLand();
            _player.UseGravity();
            _anim.SetTrigger("StopFalling");
        }
    }


}
