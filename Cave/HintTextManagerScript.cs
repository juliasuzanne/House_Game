using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintTextManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject textObjectPrefab;
    private Transform _player;
    private bool _keepInstantiating = false;
    private bool _continue = true;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (_keepInstantiating == true)
        {
            _keepInstantiating = false;
            StartCoroutine("CreateText");
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("PLAYER COLLISION");
            _keepInstantiating = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _continue = false;

        }

    }

    IEnumerator CreateText()
    {
        _keepInstantiating = false;
        Debug.Log("INSTANTIATE");
        Instantiate(textObjectPrefab, new Vector3(_player.position.x + 1f, _player.position.y + Random.Range(0f, 4f), 90f), Quaternion.identity);
        yield return new WaitForSeconds(3f);
        if (_continue == true)
        {
            _keepInstantiating = true;
        }

    }

}
