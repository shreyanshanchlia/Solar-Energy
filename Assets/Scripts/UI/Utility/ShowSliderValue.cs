using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowSliderValue : MonoBehaviour
{
	[SerializeField] private string suffixText; 
	[Space]
    [SerializeField] TextMeshProUGUI sliderText;
    [SerializeField] TMP_InputField inputField;
    
    public void ValueChange(float value)
	{
		GetComponent<Slider>().value = value;
        sliderText.text = GetComponent<Slider>().value.ToString() + suffixText;
        inputField.text = GetComponent<Slider>().value.ToString();
	}
    public void UpdateSliderValue(string inputValue)
	{
		try
		{
			GetComponent<Slider>().value = float.Parse(inputValue);
			sliderText.text = GetComponent<Slider>().value.ToString() + suffixText;
			inputField.text = GetComponent<Slider>().value.ToString();
		}
		catch { }
	}
}
