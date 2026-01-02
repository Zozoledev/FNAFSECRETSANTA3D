using UnityEngine;
using UnityEngine.UI;

public class RaycastMouse : MonoBehaviour
{
    public LayerMask layerMask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            }
        }

    }
}
