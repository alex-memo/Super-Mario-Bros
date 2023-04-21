using System.Collections;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform target;
    private void Start()
    {
        target = Controller.instance.transform;
    }
    private IEnumerator lookAtPlayer()
    {
        while (true)
        {
            transform.LookAt(target,Vector2.up);
            yield return new WaitForFixedUpdate();
        }
    }
    private void OnBecameVisible()
    {
        StartCoroutine(lookAtPlayer());
    }
    private void OnBecameInvisible()
    {
        StopAllCoroutines();
    }
}
