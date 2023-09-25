using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LivingRoomScene : MonoBehaviour
{
    private Player _player;
    public Text NPC;

    private BoxCollider2D StartTalking;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _player.MoveableFalse();
        StartTalking = GameObject.Find("NPC").GetComponent<BoxCollider2D>();
        StartTalking.enabled = false;
        NPC.gameObject.SetActive(true);
        StartCoroutine("StopTalking");

    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator StopTalking()
    {
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        NPC.text = "You had another nightmare.";
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        NPC.text = "Please come and have some tea.";
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        _player.MoveableTrue();
        NPC.gameObject.SetActive(false);


    }
}
