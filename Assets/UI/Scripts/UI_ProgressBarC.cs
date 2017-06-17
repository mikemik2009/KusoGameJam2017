using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public enum ProgressbarCTypes
{
    Text = 0,
    NoText = 1,
}

public enum ProgressbarCTextTypes
{
    None = 0,
    Percent = 1,
    Range = 2,
}

public class UI_ProgressBarC : MonoBehaviour {

    [SerializeField]
    private long _max;

    private bool _canExceedMax = false;

    public bool CanExceedMax
    {
        get
        {
            return _canExceedMax;
        }
        set
        {
            _canExceedMax = value;
            UpdateProgressbar();
        }
    }

    public long Max
    {
        get
        {
            return _max;
        }
        set
        {
            _max = value;
            UpdateProgressbar();
        }
    }

    [SerializeField]
    private long _value;
    
    public long Value
    {
        get
        {
            return _value;
        }
        set
        {
            if (value > Max && !_canExceedMax)
            {
                value = Max;
            }
            _value = value;
            UpdateProgressbar();
        }
    }

    [SerializeField]
    private Image barImage;

    public Image BarImage
    {
        get
        {
            return barImage;
        }
        set
        {
            barImage = value;
        }
    }

    [SerializeField]
    private ProgressbarCTypes type = ProgressbarCTypes.Text;
    
    public ProgressbarCTypes Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
            ToggleType();
        }
    }

    [SerializeField]
    public Text BarText;

    [SerializeField]
    private ProgressbarCTextTypes textType = ProgressbarCTextTypes.None;

    [SerializeField]
    public ProgressbarCTextTypes TextType
    {
        get
        {
            return textType;
        }
        set
        {
            textType = value;
            ToggleTextType();
        }
    }

    [SerializeField]
    public bool showMax = false;

    Func<UI_ProgressBarC, string> textFunc = TextPercent;
    
    public Func<UI_ProgressBarC, string> TextFunc
    {
        get
        {
            return textFunc;
        }
        set
        {
            textFunc = value;
            UpdateText();
        }
    }

    public static string TextNone(UI_ProgressBarC bar)
    {
        return string.Empty;
    }
    
    public static string TextPercent(UI_ProgressBarC bar)
    {
        return string.Format("{0:P0}", (double)bar.Value / bar.Max);
    }
    
    public static string TextRange(UI_ProgressBarC bar)
    {
        return string.Format("{0} / {1}", (int)bar.Value, (int)bar.Max);
    }

    public static string TextMax(UI_ProgressBarC bar)
    {
        return string.Format("{0}", "MAX");
    }

    // Use this for initialization
    void Start () {

    }

    public void Refresh()
    {
        ToggleType();
        ToggleTextType();
        UpdateProgressbar();
    }

    // Update is called once per frame
    void UpdateProgressbar () {
	    if(Max <= 0)
        {
            return;
        }

        if(barImage != null)
        {
            float percentage = ((float)Value) / ((float)Max);
            if (percentage > 1f) percentage = 1f;
            barImage.fillAmount = percentage;
        }

        UpdateText();
    }

    void UpdateText()
    {
        if((int)(Value) >= (int)Max && showMax == true)
        {
            textFunc = TextMax;
        }

        var text = textFunc(this);
        if (BarText != null)
        {
            BarText.text = text;
        }
    }

    void ToggleType()
    {
        bool is_deterimate = (type == ProgressbarCTypes.Text);

        if (BarText != null)
        {
            BarText.gameObject.SetActive(is_deterimate);
        }
    }

    void ToggleTextType()
    {
        if (TextType == ProgressbarCTextTypes.None)
        {
            textFunc = TextNone;
            return;
        }
        if (TextType == ProgressbarCTextTypes.Percent)
        {
            textFunc = TextPercent;
            return;
        }
        if (TextType == ProgressbarCTextTypes.Range)
        {
            textFunc = TextRange;
            return;
        }
    }
}
