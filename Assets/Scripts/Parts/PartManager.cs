using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartManager : MonoBehaviour
{
    private static PartManager instance;
    public Part[] parts;
    private Dictionary<Part, bool> partDic = new Dictionary<Part, bool>();
    public static Action<Part> partAcquired;
    public Image[] uiIcons;
    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        instance = this;
    }

    private void Start()
    {
        foreach (var part in parts)
        {
            partDic.Add(part, false);
        }

        for (int i = 0; i < uiIcons.Length; i++)
        {
            var img = uiIcons[i];
            img.color = Color.gray;
            img.sprite = parts[i]._sprite;
        }
    }

    public static PartManager GetInstance()
    {
        return instance;
    }

    public bool HasAllParts()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            if (!partDic[parts[i]]) return false;
        }

        return true;
    }
    
    public void AddPart(Part part)
    {
        for (int i = 0; i < parts.Length; i++)
        {
            Part p = parts[i];
            if (p.id != part.id) continue;
            if (partDic[p]) return;
            partDic[p] = true;
            partAcquired?.Invoke(p);
            uiIcons[i].color = Color.white;
            return;
        }
    }

}
