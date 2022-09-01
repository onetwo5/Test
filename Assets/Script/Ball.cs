using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour, IDragHandler
{
     
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    //拖拽
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z);
        transform.position = Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            GameManager.Instance.score += 0.25f;
            GameManager.Instance.count -= 0.25f;
            Destroy(transform.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
