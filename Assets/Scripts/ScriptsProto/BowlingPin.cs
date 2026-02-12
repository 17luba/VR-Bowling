using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    private bool hasFallen = false;
    public float fallThreshold = 30f;

    // On va stocker l'orientation initiale "debout"
    private Quaternion uprightRotation;

    void Start()
    {
        // On enregistre la rotation actuelle (celle à -90, 0, 0) comme étant "le haut"
        uprightRotation = transform.rotation;
    }

    public bool HasFallen()
    {
        // On calcule l'angle entre la rotation actuelle et la rotation initiale
        float angle = Quaternion.Angle(transform.rotation, uprightRotation);

        if (!hasFallen && angle > fallThreshold)
        {
            hasFallen = true;
            return true;
        }
        return false;
    }

    public void ResetPin(Vector3 position, Quaternion rotation)
    {
        hasFallen = false;
        transform.position = position;
        transform.rotation = rotation;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}