using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 Play_Vec;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public Vector2 GetMoveInput()
    {
        Play_Vec.x = Input.GetAxis("Horizontal");
        Play_Vec.y = Input.GetAxis("Vertical");
        return Play_Vec.normalized;
    }


    public bool GetJumpInput()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public int GetNumberInput()
    {
        for (int i = 0; i < 9; ++i)
        {
            int idx = i;
            if (Input.GetKeyDown(KeyCode.Alpha1 + idx))
            {
                return idx;
            }
        }

        return -1;
    }
}
