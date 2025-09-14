using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DamageFlash : MonoBehaviour
{
    [SerializeField] private Color _flashColor = Color.white;
    [SerializeField] private float _flashDuration = 0.25f;

    private SpriteRenderer[] _spriteRenderers;
    private Material[] _materials;
    
    private Coroutine _flashCoroutine;
    
    private void Awake()
    {
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        
        Init();
    }

    private void Init()
    {
        _materials = new Material[_spriteRenderers.Length];

        for (int i = 0; i < _spriteRenderers.Length; i++)
        {
            _materials[i] = _spriteRenderers[i].material;
        }
    }

    public void CallDamageFlash()
    {
        _flashCoroutine = StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        SetFlashColor();
        
        float currentFlashAmount = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < _flashDuration)
        {
            elapsedTime += Time.deltaTime;
            
            currentFlashAmount = Mathf.Lerp(1f, 0f, elapsedTime / _flashDuration);
            SetFlashAmount(currentFlashAmount);
            
            yield return null;
        }
    }

    private void SetFlashColor()
    {
        for (int i = 0; i < _materials.Length; i++)
        {
            _materials[i].SetColor("_FlashColor", _flashColor);
        }
    }

    private void SetFlashAmount(float amount)
    {
        for (int i = 0; i < _materials.Length; i++)
        {
            _materials[i].SetFloat("_FlashAmount", amount);
        }
    }
}
