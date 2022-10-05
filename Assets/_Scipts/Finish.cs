using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent (out Head Head))
        {
            Debug.Log("You win");
            Head.rb.velocity=Vector3.zero;
            Head.enabled=false;
        }
    }

}
