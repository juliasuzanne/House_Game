using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    private AudioSource _sound;
    [SerializeField]
    private float speed = 4.85f;
    [SerializeField]
    private Transform target;


    void Start()
    {
        _sound = GetComponent<AudioSource>();
        _sound.Play(0);
        Destroy(this.gameObject, 10f);
        target = GameObject.Find("Target_Face").transform;

    }

    void Update()
    {

        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);


    }


}
