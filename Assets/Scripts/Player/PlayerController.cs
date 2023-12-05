using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerAnimationController animationController;

    Vector2 input;

    [SerializeField] int speed;
    [SerializeField] GameObject weapon;
    IWeapon weaponScript;

    // variaveis de controle
    private bool isMoving;


    void Start()
    {
        speed = 5;  // initial value
        isMoving = false;
        animationController = GetComponent<PlayerAnimationController>();
        weaponScript = weapon.GetComponent<IWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
    
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (input != Vector2.zero)
        {
            animationController.SetMovingAnimation(true);
            isMoving = true;
        }
        else
        {
            animationController.SetMovingAnimation(false);
            isMoving = false;
        }

        if(weapon != null )
        {
            weaponScript.AutoAttack();
        }

        
    }

    void FixedUpdate()
    {
        if (isMoving)
            Move(); 

    }

    private void Move()
    {
        input = input.normalized;
        input = input * speed * Time.fixedDeltaTime;

        transform.position += new Vector3(input.x, input.y, 0); 
    }
}
