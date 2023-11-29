using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyeball : MonoBehaviour
{
    private GameObject _iris;
    private Vector2 _irisPos;
    [SerializeField]
    private float _xMin, _xMax;
    // Start is called before the first frame update
    void Start()
    {
        _iris = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_irisPos);
    }
}
