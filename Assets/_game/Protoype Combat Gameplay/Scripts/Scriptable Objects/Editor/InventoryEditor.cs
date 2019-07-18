using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Inventory))]
public class InventoryEditor : Editor
{
    bool wantsToClear = false;

    //NO EDITEN PARA NADA ESTE SCRIPT PORQUE SE BORRAN LAS CONFIGURACIONES DE LOS INVENTARIOS, mejor busquen porque pasa e intenten arreglarlo si no tienen miedo de perder las configuraciones

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Inventory inventory = (Inventory)target;

        if (inventory.items != null)
        {
            for (int i = 0; i < inventory.items.Count; i++)
            {
                if(inventory.items[i].item == null)
                {
                    inventory.items.RemoveAt(i);
                    break;
                }

                GUILayout.BeginHorizontal();
                GUILayout.Label(inventory.items[i].item.name + ": ");
                inventory.items[i].item = EditorGUILayout.ObjectField("", inventory.items[i].item, typeof(Item), true) as Item;
                GUILayout.Label("x");
                inventory.items[i].quantity = EditorGUILayout.IntField(inventory.items[i].quantity);
                if (GUILayout.Button("+"))
                {
                    inventory.items[i].quantity++;
                    inventory.items[i].quantity = Mathf.Min(inventory.items[i].quantity, 99);
                }
                if (GUILayout.Button("-"))
                {
                    inventory.items[i].quantity--;
                    inventory.items[i].quantity = Mathf.Max(inventory.items[i].quantity, 0);
                }
                if (GUILayout.Button("x"))
                {
                    inventory.items.RemoveAt(i);
                }
                GUILayout.EndHorizontal();
            }

            if (GUILayout.Button("Add Item"))
            {
                inventory.items.Add(new Inventory.InventorySlot());
            }
            if (wantsToClear == false)
            {
                if (GUILayout.Button("Clear inventory"))
                {
                    wantsToClear = true;
                }
            }
            else
            {
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Yes"))
                {
                    inventory.items = new List<Inventory.InventorySlot>();
                    wantsToClear = false;
                }
                if(GUILayout.Button("No"))
                {
                    wantsToClear = false;
                }
                GUILayout.EndHorizontal();
            }
        }
        else
        {
            if(GUILayout.Button("Initialize inventory"))
            {
                inventory.items = new List<Inventory.InventorySlot>();
            }
        }
    }
}
