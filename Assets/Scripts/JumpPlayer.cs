using System;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Animator animator;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!animator.GetBool("IsPressEnter")) {
                animator.SetBool("IsPressEnter", true);
            }
        }
    }
}
