using UnityEngine;

public class Player : MonoBehaviour
{ 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            GameManager.GameOver();
        }
    }
}
