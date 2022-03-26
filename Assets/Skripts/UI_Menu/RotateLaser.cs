using UnityEngine;

public class RotateLaser : MonoBehaviour
{
    public Transform Barrel;
    public Transform Base;
    public float SpeedRotate = 30f;

    private bool barrelRotate = false;
    private bool barrelDown = false;



    public void BtUp()
    {
        barrelDown = false;
        barrelRotate = false;
    }

    public void BtDownGun()
    {
        barrelDown = true;
    }

    public void BtRotateBase()
    {
        barrelRotate = true;
    }


    private void Update()
    {
        if (barrelDown)
        {
            Base.Rotate(Vector3.forward * SpeedRotate * Time.deltaTime);
        }

        if (barrelRotate)
        {
            
            Base.Rotate(Vector3.up * SpeedRotate * Time.deltaTime, Space.World);
        }
    }
}
