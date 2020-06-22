using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2Animation : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        animator.SetFloat("VelocityY", rigidbody.velocity.y);
        animator.SetFloat("VelocityX", rigidbody.velocity.z);
    }
}
