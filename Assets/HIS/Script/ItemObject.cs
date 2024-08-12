using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemData item;
    public GameObject Text;

    private void Start()
    {
        Text.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2d(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Text.gameObject.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                Inventory.instance.AddItem(item);
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerExit2d(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Text.gameObject.SetActive(false);
        }
    }
}