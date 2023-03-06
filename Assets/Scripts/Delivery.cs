using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(0, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage = false;
    SpriteRenderer spriteRenderer;


    int totalDelivered = 0;
    [SerializeField] public TMP_Text packageObtained;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        packageObtained.text = $"Packages Delivered: " + totalDelivered;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hit");
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package Picked up!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            

            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Customer" && hasPackage == true)
        {
            totalDelivered++;
            Debug.Log($"You delivered: " + totalDelivered + " packages.");
            packageObtained.text = $"Packages Delivered: " + totalDelivered;
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }

        if (totalDelivered >= 8)
        {
            packageObtained.text = $"Game Over! Packages Collected: " + totalDelivered;
        }
    }

}
