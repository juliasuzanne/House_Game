using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaLeaf : MonoBehaviour
{

    private int _numTeaLeaves = 0;
    private int _numTeaLeaves2 = 0;

    [SerializeField]
    private GameObject _leafContainer2;
    [SerializeField]
    private GameObject _leafContainer;
    private bool _stopSpawning = false;

    [SerializeField]
    private GameObject _teaLeaves;
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

        while (_numTeaLeaves < 10)
        {

            GameObject newEnemy = Instantiate(_teaLeaves, (Random.insideUnitCircle * 3), Quaternion.Euler(0, Random.Range(0f, 40f), Random.Range(0f, 360f)));
            newEnemy.transform.parent = _leafContainer.transform;
            _numTeaLeaves = _numTeaLeaves + 1;
        }

        while (_numTeaLeaves2 < 30)
        {

            GameObject newEnemy = Instantiate(_teaLeaves, (Random.insideUnitCircle * 1), Quaternion.Euler(0, Random.Range(0f, 40f), Random.Range(0f, 360f)));
            newEnemy.transform.parent = _leafContainer2.transform;
            _numTeaLeaves2 = _numTeaLeaves2 + 1;
        }

    }

    //spawn game objects every 5 seconds
    //create a coroutine of type IEnumerator -- Yield Events
    //while loop

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(3f);
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-7f, 7f), -3, 0);
            GameObject newEnemy = Instantiate(_teaLeaves, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _leafContainer.transform;
            //parent is a type transform, not a gameObject (enemyContainer is a gameObject)
            yield return new WaitForSeconds(.1f);
        }
        // always use infinite loops because we can use yield events
        // instantiate referenced object, enemy prefab
        // yield, wait for 5 seconds

    }


    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }


}
