
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class PopupPanel : MonoBehaviour
{
    [SerializeField] private Image _bgIMG;
    [SerializeField] private Image _alertIMG;
    [SerializeField] private Image _desctIMG;
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _descText;

    private CanvasGroup _canvasGroup;

    
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        HidePopup();
    }

    public void ShowPopup(string title, string text,Sprite img)
    {
        _bgIMG.DOFade(0.15f, 0.2f);
        Sequence seq = DOTween.Sequence();
        seq.Append(_alertIMG.transform.DOScale(1.1f, 0.15f));
        seq.Append(_alertIMG.transform.DOScale(1f, 0.07f));
        //_desctIMG.sprite = img;

        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;

        _titleText.text = title;
        _descText.text = text;
        if (img != null)
        {
            _desctIMG.enabled = true;
            _desctIMG.sprite = img;
        }
        else _desctIMG.enabled = false;
    }

    public void HidePopup()
    {
        //_bgIMG.DOFade(0f, 1f);
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }
}
