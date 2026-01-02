using UnityEngine;

public class MooveDoor : MonoBehaviour
{
    private bool isOpen = false;
    private Vector3 OpenPosition;
    private Vector3 ClosedPosition;
    private float speed = 15f;

    public bool Activate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OpenPosition = new Vector3(transform.position.x, 0f, transform.position.z);
        ClosedPosition = new Vector3(transform.position.x, 2f, transform.position.z);
        Activate = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Activate && !isOpen)
        {
            transform.Translate(new Vector3(0f, 0f, 1f) * speed * Time.deltaTime);
            if (transform.position.y >= 2)
            {
                isOpen = true;
                Activate = false;
            }
        }

        if(Activate && isOpen)
        {
            transform.Translate(new Vector3(0f, 0f, -1f) * speed * Time.deltaTime);
            if (transform.position.y <= 0f)
            {
                isOpen = false;
                Activate = false;
            }
        }

        if(!isOpen && transform.position.y < 0f)
        {
            transform.position = ClosedPosition;
        }

        if(isOpen && transform.position.y > 2f)
        {
            transform.position = OpenPosition;
        }



    }
}
