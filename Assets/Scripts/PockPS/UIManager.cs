using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private List<ActionButton> actionButtons = new();
    private List<Image> playerStatusEffects = new();
    [SerializeField]private RectTransform playerEffectsPivot;
    private List<Image> enemyStatusEffects = new();
    [SerializeField] private RectTransform enemyEffectsPivot;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI enemyHealthText;
    public TextMeshProUGUI playerEnergyText;
    public TextMeshProUGUI enemyEnergyText;
    private RectTransform canvas;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        canvas = GetComponent<RectTransform>();
    }
    private void Update()
    {
        playerHealthText.text = GameManager.Instance.Player.CurrentHealth.ToString();
        playerEnergyText.text = GameManager.Instance.Player.energy.ToString();
        
        
        Fighter enemy = null;
        foreach(var f in GameManager.Instance.fighters)
        {
            if(f is Enemy)
            {
                enemy = (Enemy)f;
            }
        }
        enemyHealthText.text = enemy.CurrentHealth.ToString();
        enemyEnergyText.text = enemy.energy.ToString();
    }

    public void AddStatusEffect(StatusEffect effect, Fighter fighter)
    {
        //GameObject obj = new GameObject(effect.effectName);
        if(fighter is Player)
        {
            Image im = effect.GetComponent<Image>();
            //im.sprite = effect.effectImage;
            im.transform.SetParent(canvas); // assumes UI manager is on canvas object!
            float posXAdditive = playerStatusEffects.Count * 32;
            Vector3 newPos = playerEffectsPivot.localPosition; 
            newPos.x += posXAdditive;

            im.rectTransform.localPosition = newPos;
            playerStatusEffects.Add(im);

        }
        if (fighter is Enemy)
        {
            Image im = effect.GetComponent<Image>();
            //im.sprite = effect.effectImage;
            im.transform.SetParent(canvas); // assumes UI manager is on canvas object!
            float posXAdditive = enemyStatusEffects.Count * -32;
            Vector3 newPos = enemyEffectsPivot.localPosition;
            newPos.x += posXAdditive;
            
            im.rectTransform.localPosition = newPos;
            enemyStatusEffects.Add(im);

        }
    }
    public void RemoveStatusEffect(StatusEffect eff, Fighter owner)
    {
        if(owner is Player)
        {
            Image im = null;
            foreach(var image in playerStatusEffects)
            {
                if(eff.effectImage == image)
                {
                    im = image; break;
                }
            }
            if(im != null)
            {
                playerStatusEffects.Remove(im);
                for (int i = 0; i < playerStatusEffects.Count; i++)
                {
                    Vector3 newPos = playerEffectsPivot.localPosition;
                    newPos.x += i * 32;
                    playerStatusEffects[i].rectTransform.localPosition = newPos;
                }
            }
            else
            {
                Debug.LogError("Ui manager did not find " + eff.ToString() + " in " + playerStatusEffects.ToString());
            }
        }
        else
        {
            Image im = null;
            foreach (var image in enemyStatusEffects)
            {
                if (eff.effectImage == image)
                {
                    im = image; break;
                }
            }
            if (im != null)
            {
                enemyStatusEffects.Remove(im);
                for(int i = 0; i < enemyStatusEffects.Count; i++)
                {
                    Vector3 newPos = enemyEffectsPivot.localPosition;
                    newPos.x += i * -32;
                    enemyStatusEffects[i].rectTransform.localPosition = newPos;
                }
            }
            else
            {
                Debug.LogError("Ui manager did not find " + eff.ToString() + " in " + enemyStatusEffects.ToString());
            }
        }
    }
}
