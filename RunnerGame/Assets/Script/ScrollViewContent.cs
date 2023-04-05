using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewContent : MonoBehaviour
{
    public RectTransform itemPrefab;

    [System.Serializable]
    public class ItemData
    {
        public int number;
        public float distance;

        public ItemData ( int number, float distance )
        {
            this.number = number;
            this.distance = distance;
        }
    }

    private List<ItemData> itemsData = new List<ItemData> ( );  // список для хранения объектов ItemDat
    private void Start ( )
    {
        itemsData.Add ( new ItemData ( 1, 2.0f ) );
        itemsData.Add ( new ItemData ( 2, 4.0f ) );
        UpdateContent ( );
        // добавление нового объекта в список
    }

    public void UpdateContent ( )
    {
        // Remove all previous items
        foreach ( Transform child in transform )
        {
            Destroy ( child.gameObject );
        }

        // Create new items for each data element
        foreach ( ItemData data in itemsData )
        {
            // Instantiate new item from prefab
            RectTransform item = Instantiate ( itemPrefab, transform );

            // Set text values for item
            TMP_Text [] texts = item.GetComponentsInChildren<TMP_Text> ( );
            texts [0].text = data.number.ToString ( );
            texts [1].text = data.distance.ToString ( );
        }
    }
}



