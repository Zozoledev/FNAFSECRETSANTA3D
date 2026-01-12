using UnityEngine;
using UnityEngine.UI;

public class RaycastMouse : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject rightdoor;
    public GameObject leftdoor;


    //LUMIERE DROITE VARIABLES
    private float timerright;
    private bool activatedright;
    public UnityEngine.Light lightright;

    //LUMIERE GAUCHE VARIABLES
    private float timerleft;
    private bool activatedleft;
    public UnityEngine.Light lightleft;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerright = 0f;
        activatedright = false;

        timerleft = 0f;
        activatedleft = false;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f; // Distance from the camera
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(Camera.main.transform.position, mousePos - Camera.main.transform.position, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                Debug.Log("Hit object: " + hit.collider.gameObject.name);
                if(hit.collider.gameObject.name == "ButtonClosedRight")
                {
                    MooveDoor doorScript = rightdoor.GetComponent<MooveDoor>();
                    doorScript.Activate = true;
                }
                if(hit.collider.gameObject.name == "ButtonClosedLeft")
                {
                    MooveDoor doorScript = leftdoor.GetComponent<MooveDoor>();
                    doorScript.Activate = true;
                }
                if(hit.collider.gameObject.name == "LightRight")
                {
                    activatedright = !activatedright;
                    
                }
                if(hit.collider.gameObject.name == "LightLeft")
                {
                    activatedleft = !activatedleft;

                }
            }
        }

        if (activatedright)
        {
            timerright += Time.deltaTime;
            Debug.Log("Timer Right: " + timerright);
            if (timerright <= Random.Range(0f, 1f))
            {
                lightright.enabled = true;
            }
            else
            {
                lightright.enabled = false;
            }
            if (timerright >= Random.Range(0f, 1f))
            {
                timerright = 0f;
            }
        }
        else
        {
            lightright.enabled = false;

        }

        if (activatedleft)
        {
            timerleft += Time.deltaTime;
            Debug.Log("Timer Left: " + timerleft);
            if (timerleft <= Random.Range(0f, 1f))
            {
                lightleft.enabled = true;
            }
            else
            {
                lightleft.enabled = false;
            }
            if (timerleft >= Random.Range(0f, 1f))
            {
                timerleft = 0f;
            }
        }
        else
        {
            lightleft.enabled = false;
        }

    }
}
