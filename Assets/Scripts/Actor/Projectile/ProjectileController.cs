using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private ProjectileObject projectileObject;

    private void Update()
    {
        if (projectileObject != null)
        {
            projectileObject.Move();
        }
    }
}
