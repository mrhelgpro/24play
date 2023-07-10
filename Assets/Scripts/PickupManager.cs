using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public List<GameObject> Pickups = new List<GameObject>();
    public GameObject PrefabPickup;

    public GameObject GetPickup()
    {
        if (Pickups.Count > 0)
        {
            GameObject pickup = Pickups[0];
            Pickups.Remove(pickup);

            return pickup;
        }

        return Instantiate(PrefabPickup);
    }

    public void AddToPickups(GameObject pickup)
    {
        pickup.SetActive(false);

        Pickups.Add(pickup);
    }
}
