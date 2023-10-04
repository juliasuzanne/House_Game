using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaLeaf : MonoBehaviour
{

    private int _numTeaLeaves = 0;
    private int _numTeaLeaves2 = 0;
    private int _numTeaLeaves3 = 0;
    private int _startNumTeaLeaves2 = 0;

    private int _startNumTeaLeaves = 0;

    private int _startNumTeaLeaves3 = 0;


    [SerializeField]
    private GameObject _leafContainer3;

    [SerializeField]
    private GameObject _leafContainer2;
    [SerializeField]
    private GameObject _leafContainer;

    [SerializeField]
    private GameObject[] _teaLeaves;


    // Start is called before the first frame update

    void Start()
    {
        _startNumTeaLeaves = Random.Range(10, 200);
        _startNumTeaLeaves2 = Random.Range(10, 60);
        _startNumTeaLeaves3 = Random.Range(100, 300);
    }

    // Update is called once per frame
    void Update()
    {
        startSpawn();
    }

    public void resetSpawn()
    {
        foreach (Transform child in _leafContainer.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in _leafContainer2.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in _leafContainer3.transform)
        {
            Destroy(child.gameObject);
        }

        _numTeaLeaves = 0;
        _numTeaLeaves2 = 0;
        _numTeaLeaves3 = 0;
        _startNumTeaLeaves = Random.Range(10, 200);
        _startNumTeaLeaves2 = Random.Range(10, 60);
        _startNumTeaLeaves3 = Random.Range(100, 300);
        startSpawn();

    }
    public void startSpawn()
    {

        while (_numTeaLeaves < _startNumTeaLeaves)
        {

            GameObject newEnemy = Instantiate(_teaLeaves[Random.Range(0, 2)], (Random.insideUnitCircle * 3), Quaternion.Euler(0, Random.Range(0f, 140f), Random.Range(0f, 360f)));
            newEnemy.transform.parent = _leafContainer.transform;
            _numTeaLeaves = _numTeaLeaves + 1;
        }
        while (_numTeaLeaves3 < _startNumTeaLeaves3)
        {

            GameObject newEnemy = Instantiate(_teaLeaves[Random.Range(0, 2)], (Random.insideUnitCircle * Random.Range(0f, 2.3f)), Quaternion.Euler(0, Random.Range(0f, 140f), Random.Range(0f, 360f)));
            newEnemy.transform.parent = _leafContainer3.transform;
            _numTeaLeaves3 = _numTeaLeaves3 + 1;
            if (_numTeaLeaves3 == _startNumTeaLeaves3)
            {
                _leafContainer3.transform.position = new Vector3(Random.Range(-1.3f, 1.3f), Random.Range(-1.3f, 1.3f), 0);
            }
        }

        while (_numTeaLeaves2 < _startNumTeaLeaves2)
        {

            GameObject newEnemy = Instantiate(_teaLeaves[Random.Range(0, 2)], (Random.insideUnitCircle * 1), Quaternion.Euler(0, Random.Range(0f, 40f), Random.Range(0f, 360f)));
            newEnemy.transform.parent = _leafContainer2.transform;
            _numTeaLeaves2 = _numTeaLeaves2 + 1;
            if (_numTeaLeaves2 == _startNumTeaLeaves2)
            {
                _leafContainer2.transform.position = new Vector3(Random.Range(0f, 4f), Random.Range(0f, 4f), 0);
            }

        }




    }



}
