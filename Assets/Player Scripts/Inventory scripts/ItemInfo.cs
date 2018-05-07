using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 [System.Serializable] 
[RequireComponent(typeof(Collider))]
public class ItemInfo : MonoBehaviour {
    public enum ItemType {weapon, armor ,potion,other};
    public ItemType type;
    public Item item;
    private PlayerInventory playerInventory;

    
    public Vector3 position;
    public Vector3 rotation;

    public int damage;
    public int healValue;
    public int defense;

    GameObject helperPanel;
    void Awake ()
    {
        playerInventory = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerInventory>() as PlayerInventory;
        helperPanel=GameObject.FindGameObjectWithTag("Helper");
        //helperPanel.SetActive(false);
     //   Debug.Log(playerInventory.inventory.Count);
    }
    
    void Start ()
    {
        switch (type)
        {
            case (ItemType.weapon):
            {
                item=new Weapon(item.name,item.description,item.stackable,item.value,item.modelPath,item.weight,damage,position,rotation);
                break;
            }
            case (ItemType.potion):
            {
                 item=new Potion(item.name,item.description,item.stackable,item.value,item.modelPath,item.weight,healValue);
                break;
            }
            case (ItemType.armor):
            {
                item=new Armor(item.name,item.description,item.stackable,item.value,item.modelPath,item.weight,defense);
                break;
            }
        }
        item.modelPath = "Items/" + gameObject.name;
    }
    void OnMouseDown ()
    {
        Debug.Log("Probuje dodac rzecz");
        playerInventory.AddToInventory(item);
        GameObject.Destroy(gameObject);

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag.Equals("Player"))
        {
            Debug.Log("WCHODZE");
            helperPanel.SetActive(true);
            
        }
    }
    void OnTriggerStay(Collider collider)
    {
        if (Input.GetKey(KeyCode.F) && collider.tag.Equals("Player"))
        {
            Debug.Log("DODAJE");
            playerInventory.AddToInventory(item);
            GameObject.Destroy(gameObject);
            helperPanel.SetActive(false);
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag.Equals("Player"))
        {
            Debug.Log("WYCHODZE");
            helperPanel.SetActive(false);
        }
    }
}
