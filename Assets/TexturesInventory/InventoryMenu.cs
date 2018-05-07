using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryMenu : MonoBehaviour {

	public GameObject itemFrame;
	public Color iconActive, iconNotActive;
	public enum IconFilter {all, weapon, potion,armor};
	public IconFilter iconFilter;
	public InventoryIcon[] icons;
    GameObject tmp;

    List<ItemFrame> listItemFrame=new List<ItemFrame>();
    RectTransform item_frame_rt, tmp_rt, rect_trans;
    ItemFrame tmpIF;
    PlayerInventory playerInventory;
    [HideInInspector]
    public List<ItemFrame> itemFrames;
    int rectSize;

    void Awake ()
    {
        playerInventory = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerInventory>();
        item_frame_rt = itemFrame.GetComponent<RectTransform>();
      //  rect_trans = gameObject.GetComponent<RectTransform>();
    }   
    void Start ()
    {
        disableIcons();
        activeIcons(1);
    }

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
    public void disableIcons()
	{
		foreach (InventoryIcon ic in icons)
		{
			ic.changeColor(iconNotActive);
		}
	}
    public void disableFrame()
	{
		foreach (ItemFrame frame in listItemFrame)
		{
			frame.changeColor(Color.white);
		}
	}
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
