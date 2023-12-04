using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 input;
    Animator animator;
    [SerializeField] int speed;
    void Start()
    {
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero)
            {
                animator.SetBool("isMoving", true);
                Debug.Log(input.x);
                animator.SetFloat("x", input.x);
                Move(input);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        
        

    }

    void Move(Vector2 input)
    {
        


        input = input.normalized;
        input = input * speed * Time.deltaTime;

        transform.position += new Vector3(input.x,input.y,0);

       

        
    }
}
