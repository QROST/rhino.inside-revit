using System;
using DB = Autodesk.Revit.DB;

namespace RhinoInside.Revit.GH.Types
{
  public class View : Element
  {
    public override string TypeDescription => "Represents a Revit view";
    protected override Type ScriptVariableType => typeof(DB.View);
    public static explicit operator DB.View(View value) =>
      value.IsValid ? value.Document?.GetElement(value) as DB.View : default;

    public View() { }
    public View(DB.View view) : base(view) { }

    public override string DisplayName
    {
      get
      {
        var element = (DB.View) this;
        if (element is object && !string.IsNullOrEmpty(element.Title))
          return element.Title;

        return base.DisplayName;
      }
    }
  }
}
