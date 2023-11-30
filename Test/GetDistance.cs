using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDistance : MonoBehaviour
{
    private float _originalX, _originalY, _distanceX, _distanceY, _parentX, _parentY;
    [SerializeField]
    private float _yScaler, _xScaler;
    private Vector2 _newPos, _mousePos;
    // Start is called before the first frame update
    void Start()
    {
        _parentX = transform.parent.position.x;
        _parentY = transform.parent.position.y;
        _originalX = transform.position.x;
        _originalY = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        _distanceX = _mousePos.x - _originalX;
        _distanceY = _mousePos.y - _originalY;
        Debug.Log(_distanceX + " " + _distanceY);

        _newPos = new Vector2(_distanceX, _distanceY);


        transform.position = new Vector2(_parentX + _newPos.x * _xScaler, _parentY + _newPos.y * _yScaler);




    }
}
