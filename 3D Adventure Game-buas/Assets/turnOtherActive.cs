using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOtherActive : MonoBehaviour
{
    [SerializeField] private bool turnOn;
    [SerializeField] private GameObject target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target.SetActive(turnOn);
            Destroy(this.gameObject);
        }
    }
}