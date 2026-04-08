using System;
using UnityEngine;

public class PickableScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]
    public PickableType pickableType;

    public Action<PickableScript> OnPicked;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(pickableType +" Picked Up");
            Destroy(gameObject);

            if (OnPicked != null)
            {
                OnPicked(this);
            }

        }

    }
}
