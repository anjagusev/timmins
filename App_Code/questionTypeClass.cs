﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This is anja's class for the survey feature
/// </summary>
public class questionTypeClass
{

    private List<string> _questiontype = new List<string>();
               
      public questionTypeClass()
      {
          _questiontype.Add("multiline");
          _questiontype.Add("singlelinetextbox");
          _questiontype.Add("singleselect");
          _questiontype.Add("multiselect");
          _questiontype.Add("yesorno");

      }

      public List<string> getQuestionTypes()
      {
          return _questiontype;
      }
}