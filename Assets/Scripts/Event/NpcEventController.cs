using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Creature;
using CharacterCamera;

public class NpcEventController : MonoBehaviour
{
    private GameObject Npc;
    private GameObject guardObj;
    private Guard guard;
    private GameObject player;
    private GameObject barricade;
    private float npcEventTime = 5f;
    private float blackOutDelay = 3f;
    private void Start()
    {
        guardObj = GameObject.Find("Guard");
        guard = guardObj.GetComponent<Guard>(); 

        player = Character.Instance.gameObject;

        barricade = GameObject.Find("Barricade");

        Npc = GameObject.Find("NPC");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& player.transform.position.x < -2)
        {
            StartNpcEvent();
        }
    }

    private void StartNpcEvent()
    {
        InputManager.Instance.SetMovementState(false);
        guard.StopPatrol();
        //startdialog
        barricade.SetActive(false);
        StartCoroutine(WaitAndFinishNpcEvent());
    }

    private IEnumerator WaitAndFinishNpcEvent()
    {
        yield return new WaitForSeconds(npcEventTime);
        yield return CameraEffector.Instance.FadeOut();
        Destroy(Npc);
        yield return CameraEffector.Instance.FadeIn();
        FinishNpcEvent();
    }

    private void FinishNpcEvent()
    {
        InputManager.Instance.SetMovementState(true);
        guard.StartPatrol();
        Destroy(this);
    }
}