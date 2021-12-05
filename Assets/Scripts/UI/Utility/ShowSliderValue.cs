using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowSliderValue : MonoBehaviour
{
	[SerializeField] private uint precision = 2;
	[SerializeField] private string suffixText; 
	[Space]
    [SerializeField] TextMeshProUGUI sliderText;
    [SerializeField] TMP_InputField inputField;
    
    public void ValueChange(float value)
    {
	    value = ((int)(value * Mathf.Pow(10, precision))) / Mathf.Pow(10f, precision);
		GetComponent<Slider>().value = value;
		sliderText.text = GetComponent<Slider>().value.ToString() + suffixText;
        inputField.text = GetComponent<Slider>().value.ToString();
	}
    public void UpdateSliderValue(string inputValue)
	{
		try
		{
			float value = float.Parse(inputValue);
			value = ((int)(value * Mathf.Pow(10, precision))) / Mathf.Pow(10f, precision);
			GetComponent<Slider>().value = value;
			sliderText.text = GetComponent<Slider>().value.ToString() + suffixText;
			inputField.text = GetComponent<Slider>().value.ToString();
		}
		catch { }
	}
}
