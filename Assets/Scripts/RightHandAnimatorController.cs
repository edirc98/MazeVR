using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandAnimatorController : MonoBehaviour
{
    private Animator RightHandAnimator;
    // Start is called before the first frame update
    void Start()
    {
        RightHandAnimator = GetComponent<Animator>(); 
    }

    public void GrabTorch()
    {
        RightHandAnimator.Play("GrabTorch");
    }
    public void UngrabTorch()
    {
        RightHandAnimator.Play("Idle");
    }
    public void ToggleTorch()
    {
        Debug.Log("PlayToggle");
        RightHandAnimator.Play("ToggleTorch");
    }
}
