using UnityEngine;

public class inventaryui : MonoBehaviour
{
    Inventary inventary;

    public Transform itemsParent;
    public GameObject inventaryUI;

    inventaryslot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventary = Inventary.instance;
        inventary.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<inventaryslot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventary"))
        {
            inventaryUI.SetActive(!inventaryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventary.items.Count)
            {
                slots[i].Additem(inventary.items[i]);
            }
            else
            {
                slots[i].Clearslot();
            }
        }
    }
}
