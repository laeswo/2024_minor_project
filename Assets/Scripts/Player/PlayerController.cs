using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private WeaponHeld weaponHeld;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement.MoveByInput(playerInput.GetMoveInput());
        if(playerInput.GetJumpInput())playerMovement.JumpByInput();
        playerMovement.ImplementGravity();
        int num = playerInput.GetNumberInput();
        if (num >= 0)
        {
            weaponHeld.HoldWeapon(num);
        }
    }
}
