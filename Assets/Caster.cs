using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Caster : MonoBehaviour
{
    public bool Cast()
    {
        Vector3 forward = transform.TransformDirection(-Vector3.forward);
        return Physics.BoxCast(transform.position, new Vector3(0.25f, 0.1f, 0.01f), forward, Quaternion.identity, 0.5f, 3 );
    }
}
