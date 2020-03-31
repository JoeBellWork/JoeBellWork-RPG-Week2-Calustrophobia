using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Scriptable : ScriptableObject
{
    public float maxHealth;
    public float speed;
    public string unitName;

    public Sprite image;

    public Color color;
}
