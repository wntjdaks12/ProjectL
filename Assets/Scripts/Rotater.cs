using UnityEngine;

public class Rotater : MonoBehaviour
{
    public Vector3 rotateValue;

    private void Update()
    {
        transform.Rotate(rotateValue.x, rotateValue.y, rotateValue.z);
    }
}
