using Unity.VisualScripting;
using UnityEngine;

public class MouseLight : MonoBehaviour
{
    Camera cam;
    public GameObject Light;
    
    
    void Start()
    {
        cam = Camera.main;
        Light.SetActive(true);
    }

    
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPos = cam.ScreenToWorldPoint(mousePos);
        transform.position = worldPos;
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!Light.activeSelf) return; 

        if (collision.tag == "Ground" || collision.tag == "Player")
        {
            return;
        }
        
        //    && - (and) |  true && true
        //    || - (or)  |  (true || false), ili (false || true), ili (true || true)
        //    != - (not equal)
        //    == - (equal)
        //    >= - (more or equal then)
        //    <= - (less or equal then)
        //    <  - (less then)
        //    >  - (more then)
        //    

        EnemyHP enemy = collision.transform.GetComponent<EnemyHP>();

        if (enemy != null)
        {
            enemy.ReceiveDamage(0.1f);
        }
    }

}
