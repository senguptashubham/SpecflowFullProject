using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstractions
{
  public  interface IUiElementBuilder
    {
        IUiElementBuilder BuildFromNames(params string[] locators);
        IUiElement Build();
    }
}
