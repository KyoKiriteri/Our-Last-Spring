using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderScript : MonoBehaviour
{
    private Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    public IEnumerator FadeAni()
    {
        ani.SetTrigger("Fade");

        yield return null;
    }

    public IEnumerator DoneAni()
    {
        ani.SetTrigger("Done");

        yield return null;
    }
}
