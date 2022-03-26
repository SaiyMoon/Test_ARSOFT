using UnityEngine;

public class InstansObj : MonoBehaviour
{
    public GameObject[] gameObjects;
    public int CountObjects;
    public Transform PointInstans;
    public float RadiusInstans = 10f;

    void Start()
    {        
        while (CountObjects > 0)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                Instantiate(gameObjects[i], Random.insideUnitSphere * RadiusInstans, Quaternion.identity);
            }
            CountObjects--;
        }        
    }
}
