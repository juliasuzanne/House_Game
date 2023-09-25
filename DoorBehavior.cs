using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{

    private bool openable = false;
    private SceneSwitch _sceneManager;

    public float pickup_distance;

    public GameObject cutscene;

    private UIManager _uiManager;
    private Transform mockPlayer;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        _sceneManager = GameObject.Find("GameManager").GetComponent<SceneSwitch>();
        player = GameObject.FindGameObjectWithTag("Player");
        mockPlayer = cutscene.transform.GetChild(0);

    }

    // Update is called once per frame
    void Update()
    {

        mockPlayer.transform.position = Vector2.MoveTowards(mockPlayer.transform.position, new Vector3(8, 10, 0), 3 * Time.deltaTime);
    }

    void OnMouseDown()
    {
        //add menu here to confirm leaving the room? or animation with the door swinging open, on hover message "go to ..."
        if (openable == true)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            print("distance is " + distance + " from door");
            if (distance < pickup_distance)
            {
                StartCoroutine("GoInDoor");

            }
            else
            {
            }

        }
        else
        {

        }
    }

    IEnumerator GoInDoor()
    {
        mockPlayer.transform.position = player.transform.position;
        cutscene.SetActive(true);
        player.SetActive(false);
        mockPlayer.transform.position = Vector2.MoveTowards(mockPlayer.transform.position, new Vector3(8, 1, 0), 3 * Time.deltaTime);
        yield return new WaitForSeconds(2f);
        _sceneManager.GoInDoor();

    }

    void OnMouseUp()
    {
        Debug.Log("Released mouse from door");
    }


    public void OpenDoor()
    {
        openable = true;
        _uiManager.so.stairDoorOpen = true;
    }
}
