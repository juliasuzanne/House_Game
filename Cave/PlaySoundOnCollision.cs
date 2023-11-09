using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    private AudioSource _sound;
    private Animator _animator;
    private Transform _player;
    private bool moving = false;
    [SerializeField]
    private float speed = 0.85f;
    [SerializeField]
    private GameObject _nextObject;
    // Start is called before the first frame update
    void Start()
    {
        _sound = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (moving == true)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

        }

    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        moving = true;
        _animator.SetTrigger("hit");
        _sound.Play(0);
        if (_nextObject != null)
        {
            Invoke("CreateNext", 3.5f);

        }
        Destroy(this.gameObject, 5f);

    }

    void CreateNext()
    {
        Instantiate(_nextObject, new Vector3(_player.position.x + 2f, _player.position.y + 3f, 90f), Quaternion.identity);
    }

}
