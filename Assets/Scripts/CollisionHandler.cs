using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    bool wasTouchingGround;
    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            wasTouchingGround = true;
        }
    }

    void OnCollisionExit(Collision other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            wasTouchingGround = false;
        }
    }

    public bool GetTouchingGround()
    {
        return wasTouchingGround;
    }

}
