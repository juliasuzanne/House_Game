using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private bool _stopSpawning = false;

    [SerializeField]
    private GameObject[] _items;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnRoutine");

    }

    // Update is called once per frame
    void Update()
    {

    }

    //spawn game objects every 5 seconds
    //create a coroutine of type IEnumerator -- Yield Events
    //while loop


    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(3f);
        while (_stopSpawning == false)
        {
            Vector3 posToSpawnPowerUp = new Vector3(Random.Range(0.25f, 7.5f), -7, 100);
            GameObject newPowerUp = Instantiate(_items[Random.Range(0, 3)], posToSpawnPowerUp, Quaternion.identity);
            yield return new WaitForSeconds(10f);
        }
    }

    public void OnPlayerLand()
    {
        _stopSpawning = true;
    }


}
