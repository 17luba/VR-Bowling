using UnityEngine;

public class BallDetector : MonoBehaviour
{
    public BowlingScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        // On vérifie si c'est bien la boule qui entre dans la zone
        if (other.CompareTag("Boule") || other.GetComponent<Rigidbody>() != null)
        {
            scoreManager.StartCalculation();
        }
    }
}