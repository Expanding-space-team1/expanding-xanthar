using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

    private static EffectManager Instance;

    public static EffectManager GetInstance()
    {
        return Instance;
    }
    
    public List<EffectObject> effectObjects;

    private ObjectPool objectPool;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        objectPool = ObjectPool.Instance;
    }

    public void Play(EffectType effectType, Vector2 position)
    {
        foreach (EffectObject effectObject in effectObjects)
        {
            if (effectObject.effectType == effectType)
            {
                GameObject gameObject = objectPool.GetObject(effectObject.name, true);

                if (gameObject == null)
                {
                    Debug.LogWarning("Effect: " + effectObject.effectType + " not found in ObjectPool!");
                    return;
                }
                
                gameObject.transform.position = position;

                return;
            }
        }
        
    }

    public enum EffectType
    {
        EXPLOSION, DEATH, PLAYER_DEATH, ENEMY_DEATH
    }
}
