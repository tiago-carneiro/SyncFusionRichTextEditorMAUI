namespace SyncFusionRichTextEditorMAUI;

public class MainViewModel : BindableObject
{
    string _htmlValue;
    public string HtmlValue
    {
        get => _htmlValue;
        set
        {
            _htmlValue = value;
            OnPropertyChanged();
        }
    }
}