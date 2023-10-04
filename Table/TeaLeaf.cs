using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaLeaf : MonoBehaviour
{

    private int _numTeaLeaves = 0;
    private int _numTeaLeaves2 = 0;
    private int _numTeaLeaves3 = 0;
    [SerializeField]
    private GameObject _leafContainer3;

    [SerializeField]
    private GameObject _leafContainer2;
    [SerializeField]
    private GameObject _leafContainer;

    [SerializeField]
    private GameObject _teaLeaves;
    [SerializeField]
    private GameObject _teaLeaves2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        startSpawn();
    }

    public void startSpawn()
    {

        while (_numTeaLeaves < 90)
        {

            GameObject newEnemy = Instantiate(_teaLeaves, (Random.insideUnitCircle * 3), Quaternion.Euler(0, Random.Range(0f, 140f), Random.Range(0f, 360f)));
            newEnemy.transform.parent = _leafContainer.transform;
            _numTeaLeaves = _numTeaLeaves + 1;
        }
        while (_numTeaLeaves3 < 220)
        {

            GameObject newEnemy = Instantiate(_teaLeaves, (Random.insideUnitCircle * Random.Range(0f, 2.3f)), Quaternion.Euler(0, Random.Range(0f, 140f), Random.Range(0f, 360f)));
            newEnemy.transform.parent = _leafContainer3.transform;
            _numTeaLeaves3 = _numTeaLeaves3 + 1;
            if (_numTeaLeaves3 == 220)
            {
                _leafContainer3.transform.position = new Vector3(Random.Range(-1f, 1.5f), Random.Range(-1.5f, 1f), 0);
            }
        }

        while (_numTeaLeaves2 < 50)
        {

            GameObject newEnemy = Instantiate(_teaLeaves2, (Random.insideUnitCircle * 1), Quaternion.Euler(0, Random.Range(0f, 40f), Random.Range(0f, 360f)));
            newEnemy.transform.parent = _leafContainer2.transform;
            _numTeaLeaves2 = _numTeaLeaves2 + 1;
            if (_numTeaLeaves2 == 50)
            {
                _leafContainer2.transform.position = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0);
            }

        }




    }



}
