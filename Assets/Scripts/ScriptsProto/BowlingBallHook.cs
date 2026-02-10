using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BowlingBallHook : MonoBehaviour
{
    private Rigidbody rb;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    [Header("Settings du Hook")]
    public float hookForce = 2.0f; // Puissance de l'effet
    private bool isReleased = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        // On �coute l'�v�nement de l�cher de la boule
        grabInteractable.selectExited.AddListener(OnBallReleased);
    }

    void OnBallReleased(SelectExitEventArgs args)
    {
        isReleased = true;
    }

    void FixedUpdate()
    {
        if (isReleased && rb.linearVelocity.magnitude > 0.5f)
        {
            // On calcule l'effet bas� sur la rotation de la boule (son axe Z ou X)
            // Plus la boule tourne sur elle-m�me, plus elle d�vie
            Vector3 sideForce = Vector3.Cross(rb.linearVelocity, Vector3.up);

            // On applique une force lat�rale proportionnelle � la rotation angulaire
            float torqueEffect = rb.angularVelocity.y;

            rb.AddForce(sideForce * torqueEffect * hookForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // On arr�te d'appliquer l'effet si on touche les quilles ou le fond
        if (collision.gameObject.CompareTag("Pin"))
        {
            isReleased = false;
        }
    }
}