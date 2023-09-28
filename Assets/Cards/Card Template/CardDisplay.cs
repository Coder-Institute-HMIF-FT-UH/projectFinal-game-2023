using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public Image artworkImage;
    public Text nameText;
    public Text descriptionText;
    public Text costText;
    public Text attackText;
    public Text defendText;
    public Text buffText;
    public Text debuffText;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.cardName;
        descriptionText.text = card.description;
        artworkImage.sprite = card.artwork;
        costText.text = card.cost.ToString();
        attackText.text = card.atk.ToString();
        defendText.text = card.def.ToString();
        buffText.text = card.buff.ToString();
        debuffText.text = card.debuff.ToString();
    }

}
