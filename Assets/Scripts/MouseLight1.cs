using Unity.VisualScripting;
using UnityEngine;

public class MouseLight : MonoBehaviour
{
    Camera cam;
    public GameObject Light;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        Light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Light.SetActive(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Light.SetActive(false);
        }

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

        Debug.Log(collision.transform.name);
        //collision.transform.position = new Vector2(10,15);

        EnemyHP enemy = collision.transform.GetComponent<EnemyHP>();

        if (enemy != null)
        {
            enemy.ReceiveDamage(0.1f);
        }
    }

}
