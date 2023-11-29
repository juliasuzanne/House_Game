using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyeball : MonoBehaviour
{
    private GameObject _iris;
    private Vector2 _mousePos;
    [SerializeField]
    private float _xScaler, _yScaler, _xMin, _xMax, _yMin, _yMax;
    private float _distanceX, _distanceY, _irisPosx, _irisPosy, _newXPos, _newYPos;

    // Start is called before the first frame update
    void Start()
    {
        _iris = this.gameObject;
        _irisPosx = _iris.transform.parent.position.x;
        _irisPosy = _iris.transform.parent.position.y;
        _xMin = _irisPosx + _xMin;
        _xMax = _irisPosx + _xMax;
        _yMin = _irisPosy + _yMin;
        _yMax = _irisPosy + _yMax;


    }

    // Update is called once per frame
    void Update()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.Log("_iris.transform.position.x: " + _iris.transform.position.x);

        _distanceX = _iris.transform.position.x + _mousePos.x;
        _distanceY = _iris.transform.position.y + _mousePos.y;
        _newXPos = _irisPosx + (_mousePos.x * _xScaler);
        _newYPos = _irisPosy + (_mousePos.y * _yScaler);
        if (_newXPos < _xMin)
        {
            _newXPos = _xMin + 0.005f;
        }
        else if (_newXPos > _xMax)
        {
            _newXPos = _xMax - 0.005f;
        }
        if (_newYPos < _yMin)
        {
            _newYPos = _yMin + 0.005f;
        }
        else if (_newYPos > _yMax)
        {
            _newYPos = _yMax - 0.005f;
        }

        _newYPos = _irisPosy + _distanceY * _yScaler;
        _iris.transform.position = new Vector2(_newXPos, _newYPos);


    }
}
