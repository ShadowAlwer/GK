using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Class which is responsible for inventory menu.
*/
public class InventoryMenu : MonoBehaviour {

	/**
	* Game object which is item to show.
	*/
	public GameObject itemFrame;
	/**
	* Field which show if item is selected
	*/
	public Color iconActive, iconNotActive;
	/**
	* Field which holds state which inventory option is picked
	* we can show all items, only weapons, potions or armors.
	*/
	public enum IconFilter {all, weapon, potion,armor};
	/**
	* Field which is used to filter.
	*/
	public IconFilter iconFilter;
	/**
	* Field which holds icons.
	*/
	public InventoryIcon[] icons;
	/**
	* Field which is temporary.
	*/
    GameObject tmp;
	/**
	* List with items.
	*/
    List<ItemFrame> listItemFrame=new List<ItemFrame>();
	/**
	* Field which holds position of frame.
	*/
    RectTransform item_frame_rt, tmp_rt, rect_trans;
	/**
	* Field which is temporary.
	*/
    ItemFrame tmpIF;
	/**
	* Field which holds player inventory.
	*/
    PlayerInventory playerInventory;
    [HideInInspector]
	/**
	* List of item frames.
	*/
    public List<ItemFrame> itemFrames;
	/**
	* Field which holds size.
	*/
    int rectSize;

	/**
	* Method used when inventory is opened.
	*/
    void Awake ()
    {
        playerInventory = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerInventory>();
        item_frame_rt = itemFrame.GetComponent<RectTransform>();
      //  rect_trans = gameObject.GetComponent<RectTransform>();
    }   
	/**
	* Method which starts inventory.
	*/
    void Start ()
    {
        disableIcons();
        activeIcons(1);
    }
	/**
	* Method which updates inventory content
	*/
    public void updateInventory()
    {
        while (itemFrames.Count != 0)
        {
            GameObject go = itemFrames[0].gameObject;
            itemFrames.RemoveAt(0);
            GameObject.Destroy(go);
        }
        rectSize = 0;
        //  disableIcons();
        //activeIcons(1);
         listItemFrame.Clear();
        //for (int i = 0; i < playerInventory.inventory.Count; ++i)
        //{

        //}
        itemFrame.SetActive(true);
        if (iconFilter == IconFilter.all || iconFilter == IconFilter.weapon)
            for (int i = 0; i < playerInventory.inv_weapon.Count; ++i)
                drawItem(playerInventory.inv_weapon[i]);
        if (iconFilter == IconFilter.all || iconFilter == IconFilter.potion)
            for (int i = 0; i < playerInventory.inv_potion.Count; ++i)
              drawItem(playerInventory.inv_potion[i]);
        if (iconFilter == IconFilter.all)
            for (int i = 0; i < playerInventory.inv_other.Count; ++i)
              drawItem(playerInventory.inv_other[i]);

        
        itemFrame.SetActive(false);
     //   rect_trans.sizeDelta = new Vector2(0, (item_frame_rt.rect.height + 1.5f) * rectSize);
     //   rect_trans.anchoredPosition += new Vector2(0, -(item_frame_rt.rect.height + 1.5f) * rectSize / 2);
        highlightCurrentWeapon();
        
    }
	/**
	* Method which draw items in inventory
	*/
    void drawItem(Item it)
    {
        tmp = GameObject.Instantiate(itemFrame);
        tmp.transform.SetParent(gameObject.transform);
        tmp_rt = tmp.GetComponent<RectTransform>();
        tmp_rt.localScale = item_frame_rt.localScale;
        tmp_rt.anchoredPosition = item_frame_rt.anchoredPosition;
        tmp_rt.anchoredPosition += new Vector2(0, (item_frame_rt.rect.height + 1.5f) * -rectSize);
        tmpIF = tmp.GetComponent<ItemFrame>();
        itemFrames.Add(tmpIF);
        //Debug.Log(playerInventory.inventory[i].name);
        //Debug.Log(playerInventory.inventory[i].value);
        tmpIF.name = it.name;
        tmpIF.value = it.value;
        tmpIF.item = it;
        tmpIF.setValues();
        //tmp.SetActive(true);
        //gameObject.SetActive(true);
        listItemFrame.Add(tmpIF);
        //Debug.Log("updateuje menu");
        rectSize++;
    }
	/**
	* Method which disable icons. (show that they are not active)
	*/
    public void disableIcons()
	{
		foreach (InventoryIcon ic in icons)
		{
			ic.changeColor(iconNotActive);
		}
	}
	/**
	* Method which disables frames.
	*/
    public void disableFrame()
	{
		foreach (ItemFrame frame in listItemFrame)
		{
			frame.changeColor(Color.white);
		}
	}
	/**
	* Method which show actived icons.
	*/
	public void activeIcons(int iconNumber)
	{
		icons[iconNumber].changeColor(iconActive);

        switch (iconNumber) {
            case 0:
                iconFilter = IconFilter.all;
                break;
            case 1:
                iconFilter = IconFilter.weapon;
                break;
            case 2:
                iconFilter = IconFilter.potion;
                break;
            default:
                break;
        }
        updateInventory();

    }
	/**
	* Method which highlight current picked item
	*/
    public void highlightCurrentWeapon()
	{
		Player_weapons playerWeapons = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_weapons>();
		string weaponName=playerWeapons.getCurrentWeaponName();
		foreach (ItemFrame frame in listItemFrame)
		{
            if (frame.name.Equals(weaponName))
			    frame.changeColor(Color.cyan);
		}
	}

}
