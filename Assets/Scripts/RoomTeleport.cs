using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTeleport : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject tpStart;
    [SerializeField] private GameObject tpEnd;
    [SerializeField] private bool nearDoor;
    public string nameCollect;

    // Update is called once per frame
    private void Update()
    {
        if (nearDoor == true && Input.GetKeyDown(KeyCode.F))
        {
            if (nameCollect == "CLS_TP_Corridor")
            {
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = tpEnd.transform.position;
                player.GetComponent<CharacterController>().enabled = true;
            }
            else if (nameCollect == "CLS_TP_CLS")
            {
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = tpStart.transform.position;
                player.GetComponent<CharacterController>().enabled = true;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nearDoor = true;
            nameCollect = gameObject.name;
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nearDoor = false;
            nameCollect = "";
        }
    }
}
