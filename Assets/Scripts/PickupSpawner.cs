using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    private PickupManager _pickupManager;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _pickupManager = FindObjectOfType<PickupManager>();
    }

    private void OnEnable()
    {
        float a = Random.Range(-1, 1) * 1.5f;
        float b = Random.Range(-1, 1) * 1.5f;
        float c = Random.Range(-1, 1) * 1.5f;
       
        createPickup(new Vector3(a, 0, 0));
        if (GameManager.AmountOfPickups < 5) createPickup(new Vector3(b, 0, -5));
        if (GameManager.AmountOfPickups < 10) createPickup(new Vector3(c, 0, -10));
    }

    private void createPickup(Vector3 position)
    {
        GameObject pickup = _pickupManager.GetPickup();
        pickup.SetActive(true);
        pickup.transform.parent = _transform;
        pickup.transform.localPosition = position;
    }

    private void OnDisable()
    {
        foreach (Transform child in _transform)
        {
            if (child.tag == "Pickup")
            {
                _pickupManager.AddToPickups(child.gameObject);
            }
        }
    }
}
