ej.base.registerLicense('[syncfusion key - MAUI and JS]');

// initialize Rich Text Editor component
defaultRTE = new ej.richtexteditor.RichTextEditor({
    fontSize: {
        default: '14 pt'
    },
    toolbarSettings: {
        items: ['Bold', 'Italic', 'Underline',
            'FontSize', 'OrderedList',
            'UnorderedList', 'Undo',
            'Redo', 'ClearFormat', 'CreateLink'
        ]
    },
    saveInterval: 500,
    change: onHTMLChanged,
});
defaultRTE.appendTo('#defaultRTE');

// Send to MAUI page when HTML value changed
function onHTMLChanged() {
    HybridWebView.SendInvokeMessageToDotNet('OnHTMLChanged', defaultRTE.value);
}

// Update HTML value from MAUI
function updateHtml(value) {
    defaultRTE.value = value;
}

// Send simple message to MAUI
HybridWebView.SendRawMessageToDotNet('INIT');