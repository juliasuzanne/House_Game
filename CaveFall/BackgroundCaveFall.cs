using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCaveFall : MonoBehaviour
{
    private Hand _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Hand>();
        _player.MoveableTrue();
    }

    // Update is called once per frame
    void Update()
    {


    }
}
