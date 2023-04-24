using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BookshelfPuzzle : MonoBehaviour
{
    public List<Color> colorList;
    
    private List<GameObject> snaps = new List<GameObject>();
    private Dictionary<GameObject, List<GameObject>> bookListByColor = new Dictionary<GameObject, List<GameObject>>();
    private Dictionary<Color, List<GameObject>> bookListByColors = new Dictionary<Color, List<GameObject>>();
    void Start()
    {
        // Get all GameObjects with the "Book" tag
        GameObject[] snapObjects = GameObject.FindObjectsOfType<BookSnap>().OrderBy(snap => snap.snapNumber).Select(snap => snap.gameObject).ToArray();

        // Add each book to the list
        foreach (GameObject snap in snapObjects)
        {
            snaps.Add(snap);
            GameObject bookColor = snap.GetComponent<BookSnap>().book;
            if (!bookListByColor.ContainsKey(bookColor))
            {
                bookListByColor[bookColor] = new List<GameObject>();
            }
            bookListByColor[bookColor].Add(snap);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check the color of each book and update the dictionary if necessary
        foreach (GameObject snap in snaps)
        {
            GameObject snapBook = snap.GetComponent<BookSnap>().book;
            if (!bookListByColor.ContainsKey(snapBook))
            {
                bookListByColor[snapBook] = new List<GameObject>();
            }
            if (!bookListByColor[snapBook].Contains(snap))
            {
                bookListByColor[snapBook].Add(snap);
            }
            Color bookColor = snap.GetComponent<Renderer>().material.color;
            if (!bookListByColors.ContainsKey(bookColor))
            {
                bookListByColors[bookColor] = new List<GameObject>();
            }
            if (!bookListByColors[bookColor].Contains(snap))
            {
                bookListByColors[bookColor].Add(snap);
            }
        }

        // Print the names of all books in the list
        foreach (KeyValuePair<GameObject, List<GameObject>> pair in bookListByColor)
        {
            Debug.Log("Book " + pair.Key + ":");
            foreach (GameObject book in pair.Value)
            {
                Debug.Log("- " + book.name);
            }
        }
        List<Color> colorListConverted = new List<Color>(bookListByColors.Keys);
        Debug.Log(colorListConverted);
        Debug.Log(colorList);
        if (colorListConverted == colorList)
        {
            Debug.Log("yayaya");
        }
        // Print the order of the predefined color list
        Debug.Log("Predefined color order: " + string.Join(", ", colorList.Select(c => c.ToString()).ToArray()));

        // Print the order of the books' color list
        Debug.Log("not Predefined color order: " + string.Join(", ", colorListConverted.Select(c => c.ToString()).ToArray()));
    }
}
