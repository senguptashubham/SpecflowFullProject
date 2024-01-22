using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.UiObject
{
   public class UiElementBuilder : IUiElementBuilder
    {
        IUiElement _iuiElement;
        ILogging _ilogging;
        IList<string> objectMaps;
        public UiElementBuilder(IUiElement iuiElement, ILogging ilogging)
        {
            this._iuiElement = iuiElement;
            this._ilogging = ilogging;
        }

        public void BuildObjectMap(string map)
        {
            string[] arr = map.Split('.');
            if (arr.Length != 2)
            {
                this._ilogging.Error("Object locator :" + map + " is incomplete. Please provide locator information in format Page.Element");
                throw new AutomationException(ErrorItems.InvalidParameterException + " Object locator :" + map + " is incomplete. Please provide locator information in format Page.Element");
            }
        }

        public IUiElementBuilder BuildFromNames(params string[] locators)
        {
            objectMaps = new List<string>();
            foreach (string locator in locators)
            {
                BuildObjectMap(locator);
                objectMaps.Add(locator);
            }

            _iuiElement.BuildFromElements(objectMaps);
            return this;
        }

        public IUiElement Build()
        {
            return _iuiElement;
        }
    }
}
