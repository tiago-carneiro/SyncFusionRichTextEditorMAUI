namespace SyncFusionRichTextEditorMAUI;

public partial class HybridRichTextEditor
{
    public static BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(HybridRichTextEditor),
            string.Empty,
            BindingMode.TwoWay,
            propertyChanged: TextPropertyChanged);

    static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is HybridRichTextEditor element)
        {
            var oldText = oldValue as string ?? string.Empty;
            var newText = newValue as string ?? string.Empty;

            if (!oldText.Equals(newText))
                element.UpdateHtml();
        }
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public HybridRichTextEditor()
    {
        InitializeComponent();
        hybridWebView.JSInvokeTarget = new HybridRichTextEditorJSInvoke(this);
        hybridWebView.RawMessageReceived += hybridWebView_RawMessageReceived;
    }

    private void hybridWebView_RawMessageReceived(object sender, HybridWebView.HybridWebViewRawMessageReceivedEventArgs e)
    {
        hybridWebView.RawMessageReceived -= hybridWebView_RawMessageReceived;
        UpdateHtml();
    }

    //Send HTML value to richtexteditor
    void UpdateHtml()
        => hybridWebView.InvokeJsMethodAsync("updateHtml", Text ?? string.Empty);
}

public class HybridRichTextEditorJSInvoke
{
    readonly HybridRichTextEditor _hybridRichTextEditor;

    public HybridRichTextEditorJSInvoke(HybridRichTextEditor hybridRichTextEditor)
        => _hybridRichTextEditor = hybridRichTextEditor;

    //Receive HTML value from richtexteditor
    public void OnHTMLChanged(string html)
        => _hybridRichTextEditor.Text = html;
}