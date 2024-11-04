using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Model.Items;
using DG.Tweening;

public class WorldSpacePickup : MonoBehaviour
{
    [SerializeField]
    private Canvas _canvas;
    [SerializeField]
    private TMP_Text _text;
    [SerializeField]
    private Image _icon;

    public void PlayAnimation(ItemData data, Vector3 position)
    {
        transform.position = position;
        transform.eulerAngles = Vector3.zero;

        _text.text = "+ " + data.Name;
        _icon.sprite = data.Sprite;
        

        _canvas.transform.DOMoveY(transform.position.y + 3, 2f).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            Destroy(gameObject);
        });
        _canvas.transform.DOScale(1, 2f).SetEase(Ease.InOutQuad);
    }
}
