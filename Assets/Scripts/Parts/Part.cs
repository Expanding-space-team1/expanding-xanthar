using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Part", menuName = "Part", order = 0)]
public class Part : ScriptableObject
{
    public Sprite _sprite;
    public int id;
    public string name;
}
