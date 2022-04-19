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

    private void Start()
    {
        player = GameObject.Find("Player");
        FaderScript fD = GameObject.FindGameObjectWithTag("Fader").GetComponent<FaderScript>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (nearDoor == true && Input.GetKeyDown(KeyCode.F))
        {
            if (nameCollect == "CLS_TP_Corridor")
            {
                StartCoroutine(TransitionCLSCo());
                
            }
            else if (nameCollect == "CLS_TP_CLS")
            {
                StartCoroutine(TransitionCorCo());
            }
        }
    }

    public IEnumerator TransitionCLSCo()
    {
        FaderScript fd = GameObject.FindGameObjectWithTag("Fader").GetComponent<FaderScript>();
        yield return StartCoroutine(fd.FadeAni());

        new WaitForSeconds(1);
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = tpEnd.transform.position;
        player.GetComponent<CharacterController>().enabled = true;
    }

    public IEnumerator TransitionCorCo()
    {
        FaderScript fd = GameObject.FindGameObjectWithTag("Fader").GetComponent<FaderScript>();
        yield return StartCoroutine(fd.FadeAni());

        new WaitForSeconds(1);
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = tpStart.transform.position;
        player.GetComponent<CharacterController>().enabled = true;
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
