using System.Collections;
using UnityEngine;

public class PiranhaPlantScript : enemyScript
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Controller.instance.getHit();
        }
    }
    private IEnumerator whileOnScreen()
    {
        Vector2 _pos=transform.position;
        while (true)
        {
            _pos.y = Mathf.PingPong(Time.time, 4);
            transform.position=_pos;
            print(_pos.y);
            yield return new WaitForFixedUpdate();
        }
    }
    private void OnBecameVisible()
    {
        print("hello");
       // StartCoroutine(whileOnScreen());
    }
    private void OnBecameInvisible()
    {
        //StopAllCoroutines();
    }

}
