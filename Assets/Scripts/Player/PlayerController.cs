using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speedMovement = 3f;

    public int MoneyAmount = 0;

    private Menu menu;

    private void Start()
    {
        menu = FindObjectOfType<Menu>();
        Debug.Log("menu: " + menu != null);
    }

    private void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            if(touch.fingerId == 0)
            {
                if (IsUIElementClicked()) return;

                UpdatePosition(Input.GetTouch(0).position);
            }
        }
    }

    private bool IsUIElementClicked()
    {
        GameObject go = EventSystem.current.currentSelectedGameObject;
        
        if(go != null)
        {
            if (go.name == menu.StopButton.name || go.name == menu.ShieldButton.name || go.name == menu.GunButton.name)
                return true;
        }
        return false;
    }

    private void UpdatePosition(Vector3 position)
    {
        Vector3 pos = Camera.main.ScreenToViewportPoint(position);
        pos.x = Mathf.Clamp(pos.x, 0.05f, 0.95f);
        pos.y = Mathf.Clamp(pos.y, 0.05f, 0.95f);

        Vector3 worldSpaceCoord = Camera.main.ViewportToWorldPoint(pos);
        worldSpaceCoord.z = 10f;
        transform.position = Vector3.Lerp(transform.position, worldSpaceCoord, speedMovement * Time.deltaTime);
    }

    public void HandleMoney(int value)
    {
        MoneyAmount += value;

        menu.MoneyText.text = "Money: " + MoneyAmount + "$";
    }
}
