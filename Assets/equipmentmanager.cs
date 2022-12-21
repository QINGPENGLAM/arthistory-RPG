using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipmentmanager : MonoBehaviour
{
    #region singleton

    public static equipmentmanager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion
    public equipment[] defaultItems;
    equipment[] currentEquipment;
    Inventary inventory;
    SkinnedMeshRenderer[] currentMeshes;

    public delegate void OnEquipmentChanged(equipment newItem, equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    public SkinnedMeshRenderer targetMesh;
    private void Start()
    {
        inventory = Inventary.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];

        EquipDefaultItems();
    }

    public void Equip (equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        
        equipment oldItem = Unequip(slotIndex);

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        SetEquipmentBlendShapes(newItem, 150);

        currentEquipment[slotIndex] = newItem;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform;

        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[slotIndex] = newMesh;
    }

    public equipment Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            if (currentEquipment[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }
            equipment oldItem = currentEquipment[slotIndex];
            SetEquipmentBlendShapes(oldItem, 0);
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
            return oldItem;
        }
        return null;

    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
        EquipDefaultItems();
    }
    void SetEquipmentBlendShapes(equipment item, int weight)
    {
        foreach(EquipmentMeshRegion blendShape in item.coverMeshRegions)
        {
            targetMesh.SetBlendShapeWeight((int)blendShape,weight);
        }
    }

    void EquipDefaultItems()
    {
        foreach (equipment item in defaultItems)
        {
            Equip(item);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }
}

