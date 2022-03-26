using UnityEngine;
using UnityEngine.UI;

public class ControlLaser : MonoBehaviour
{
    [SerializeField]
    private int maxBounses = 5;

    [SerializeField]
    private Slider distans;
   
    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    private Transform startPoint;
    private float maxDistanse;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        
    }

    private void Update()
    {
        maxDistanse = distans.value;

        RaycastHit hit;
        Ray ray = new Ray(startPoint.position, startPoint.up);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, startPoint.position);
        float remainingLength = maxDistanse;

        for (int i = 0; i < maxBounses; i++)
        {
            if(Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength))
            {
                float damp = maxDistanse - hit.collider.GetComponent<ObstacleProperties>().Damping;
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount -1, hit.point);
                remainingLength -= Vector3.Distance(ray.origin, hit.point);                
               
                if (hit.collider.tag != "Mirror") { break; }

                if (damp > remainingLength)
                {
                    ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                }
            }
            else
            {   
                    lineRenderer.positionCount += 1;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);
            }
        }
    }
}
