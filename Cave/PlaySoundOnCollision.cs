using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    private AudioSource _sound;
    [SerializeField]
    private float speed = 0.85f;

    void Start()
    {
        _sound = GetComponent<AudioSource>();
        _sound.Play(0);
        Destroy(this.gameObject, 4f);

    }

    void Update()
    {

        transform.Translate(Vector3.right * speed * Time.deltaTime);

    }


}
