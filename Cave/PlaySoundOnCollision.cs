using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    private AudioSource _sound;
    private Transform _player;
    [SerializeField]
    private float speed = 0.85f;

    void Start()
    {
        _sound = GetComponent<AudioSource>();
        _player = GameObject.Find("Player").transform;
    }

    void Update()
    {

        transform.Translate(Vector3.right * speed * Time.deltaTime);

    }

    public void LeadingText(GameObject prefab)
    {
        Instantiate(prefab, new Vector3(_player.position.x + 2f, _player.position.y + 3f, 90f), Quaternion.identity);
        _sound.Play(0);
        Destroy(this.gameObject, 5f);

    }


}
