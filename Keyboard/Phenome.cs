using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phenome : MonoBehaviour
{
    public AudioClip phenome;

    [SerializeField]
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D
    {
        _audioSource.clip = phenomes [0];
        _audioSource.Play();
    }
}
