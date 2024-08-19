using Godot;
using System;

public partial class WebsiteNameButton : Button
{
    [Export]
    private TextEdit NameField;
    
    [Export]
    private TextEdit DomainField;
    
    private void OnClick()
    {
        string name = this.NameField.GetText();
        string domain = this.DomainField.GetText();
        GameLoop.Instance.UpdateWebsiteName(name, domain);
    }
}
