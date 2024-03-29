using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * @memo 2022
 * base code for enemies
 */
public class enemyScript : MonoBehaviour
{
    [SerializeField] protected Sprite deathSprite;//goomba should be flat, koopa should be shell
    /**
 * @memo 2022
 * on collision enter if player then die if stomped or hit player
 */
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Controller.instance.getIsStar())
            {
                hit();
            }
            //chack dir of player is going down, meaning they stomped him
            else if (collision.transform.dotProduct(transform, Vector2.down))
            {
                onDie();
            }
            else
            {
                Controller.instance.getHit();//instance works only if single player if networkigng then do different
            }
        }
    }
    /**
 * @memo 2022
 * on trigger enter if its hit by shell then die
 */
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shell"))
        {
            hit();
        }
    }
    /**
 * @memo 2022
 * on hit then disable animation and enable death anim and then destroy
 */
    protected void hit()
    {
        GetComponent<animationScript>().enabled = false;
        GetComponent<deathAnimation>().enabled = true;
        Controller.instance.Play(gameManager.instance.getSoundManager().enemyDie);
        Destroy(gameObject, 3f);
    }
    /**
 * @memo 2022
 * when this enemy dies
 */
    protected virtual void onDie()
    {
        Controller.instance.Play(gameManager.instance.getSoundManager().enemyDie);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<itemEnemyMovement>().enabled = false;
        GetComponent<animationScript>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = deathSprite;
    }
    /**
     * @memo 2022
     * call action when this entity is on top of a block that the player hit
     */
    public void blockHit()
    {
        transform.eulerAngles = new Vector3(0f, 0f, 180f);
        hit();
    }
}
