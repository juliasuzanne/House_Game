using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintTextManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject textObjectPrefab;
    private Transform _player;
    private bool _keepInstantiating = false;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (_keepInstantiating == true)
        {
            StartCoroutine("CreateText");
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _keepInstantiating = true;

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _keepInstantiating = false;

        }

    }

    IEnumerator CreateText()
    {
        _keepInstantiating = false;
        Instantiate(textObjectPrefab, new Vector3(_player.position.x + 2f, _player.position.y + 3f, 90f), Quaternion.identity);
        yield return new WaitForSeconds(3f);
        Destroy(textObjectPrefab, 4f);
        _keepInstantiating = true;

    }

}
