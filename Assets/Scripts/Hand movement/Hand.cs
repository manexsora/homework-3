using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    public float speed;

    Animator animator;
    private float peaceTarget;
    private float peaceCurrent;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
    }
    internal void SetPeace(float v)
    {
        peaceTarget = v;
    }
    void AnimateHand()
    {
        if (peaceCurrent != peaceTarget)
        {
            peaceCurrent = Mathf.MoveTowards(peaceCurrent, peaceTarget, Time.deltaTime * speed);
            animator.SetFloat("Trigger", peaceCurrent);
        }
    }
}
