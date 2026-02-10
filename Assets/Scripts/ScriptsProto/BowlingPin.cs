using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    private bool hasFallen = false;
    public float fallThreshold = 30f; // Angle � partir duquel on consid�re qu'elle est tomb�e

    public bool HasFallen()
    {
        // On compare l'axe "Up" de la quille avec l'axe "Up" du monde (verticale)
        float angle = Vector3.Angle(transform.up, Vector3.up);

        if (!hasFallen && angle > fallThreshold)
        {
            hasFallen = true;
            return true;
        }
        return false;
    }

    // Optionnel : pour r�initialiser la quille plus tard
    public void ResetPin(Vector3 position, Quaternion rotation)
    {
        hasFallen = false;
        transform.position = position;
        transform.rotation = rotation;
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}