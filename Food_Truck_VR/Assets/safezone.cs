using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safezone : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Interactable"))
        {
            other.GetComponent<Interactable>().LeaveSafe();
        }
    }
}
