using UnityEngine;
public class ObstacleProperties : MonoBehaviour
{
    public float Damping;
    private void Start()
    {
        Damping = Random.Range(0, 10f);
    }
}
