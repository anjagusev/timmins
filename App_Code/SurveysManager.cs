using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Anja's class for the survey feature
/// </summary>
public class SurveysManager
{
	

    public enum QuestionTyeps
    {
        SingleLineTextBox, //will render a textbox
        MultiLineTextBox, //will render a text area
        YesOrNo, // will render a checkbox
        SingleSelect, //will render a dropdownlist
        MultiSelect // will render a lsitbox
    }
}