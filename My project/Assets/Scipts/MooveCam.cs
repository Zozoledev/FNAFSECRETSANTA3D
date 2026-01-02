using UnityEngine;

public class MooveCam : MonoBehaviour
{
    public float sensitivity = 100f;
    public float minAngle = 160f;   // limite gauche réelle
    public float maxAngle = 200f;   // limite droite réelle

    private float currentY;

    void Start()
    {
        // angle de départ (par ex. 180)
        currentY = transform.localEulerAngles.y;
    }

    void Update()
    {
        // delta souris horizontal (ancien système)
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;

        currentY += mouseX;
        currentY = Mathf.Clamp(currentY, minAngle, maxAngle);

        transform.localRotation = Quaternion.Euler(0f, currentY, 0f);
    }
}
