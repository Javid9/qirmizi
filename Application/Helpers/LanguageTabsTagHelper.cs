using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace Application.Helpers;

public class LanguageTabsTagHelper : TagHelper
{

    public required IEnumerable<object> Languages { get; set; }
    public List<FormField> FormFields { get; set; } = [];
    public string? TabId { get; set; } = "pills";

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var tabBuilder = new StringBuilder();

        tabBuilder.Append($"<ul class='nav nav-pills mb-3' id='{TabId}-tab' role='tablist'>");

        int count = 0;
        foreach (var language in Languages)
        {
            var lang = language.GetType().GetProperty("Code")?.GetValue(language, null);
            var Name = language.GetType().GetProperty("Name")?.GetValue(language, null);
            var activeClass = count == 0 ? "active" : "";
            var selected = count == 0 ? "true" : "false";
            tabBuilder.Append($@"
                <li class='nav-item' role='presentation'>
                    <button class='nav-link {activeClass}' id='{TabId}-lang-tab-{lang}'
                            data-bs-toggle='pill' data-bs-target='#{TabId}-lang-{lang}'
                            type='button' role='tab' aria-controls='{TabId}-lang-{lang}'
                            aria-selected='{selected}'>{Name}</button>
                </li>");
            count++;
        }
        tabBuilder.Append("</ul>");

        //Tab Content
        var contentBuilder = new StringBuilder();
        contentBuilder.Append($"<div class='tab-content' id='{TabId}-TabContent'>");
        int panelCount = 0;
        foreach (var item in Languages)
        {
            var activeClass = panelCount == 0 ? "active show" : "";
            var language = item.GetType().GetProperty("Code")?.GetValue(item, null);
            contentBuilder.Append($@"
                <div class='tab-pane fade {activeClass}' id='{TabId}-lang-{language}' role='tabpanel' aria-labelledby='{TabId}-lang-tab-{language}'>
                    {GetFieldsHtml(language?.ToString())}
                </div>");

            panelCount++;

        }
        contentBuilder.Append("</div>");

        output.TagName = "div";
        output.Attributes.SetAttribute("class", "multi");
        output.Content.SetHtmlContent(tabBuilder.ToString() + contentBuilder.ToString());
        output.TagMode = TagMode.StartTagAndEndTag;

    }
    private string GetFieldsHtml(string? language)
    {
        var stringBuilder = new StringBuilder();
        var required = "";
        foreach (var field in FormFields.Where(x => x.LangCode == language))
        {
            stringBuilder.Append("<div class='mb-3'>");

            if (!string.IsNullOrEmpty(field.Label))
                stringBuilder.Append($"<label class='form-label' for='{field.Id}'>{field.Label} - {language}</label>");

            if (field.Required)
                required = "required";

            switch (field.Type)
            {
                case "text":
                    stringBuilder.Append($"<input type='text' {required} class='form-control {field.ClassNames}' id='{field.Id}' name='{field.Name}' value='{field.Value}' />");
                    break;
                case "textarea":
                    stringBuilder.Append($"<textarea rows='5' cols='5' {required} class='form-control {field.ClassNames}' id='{field.Id}' name='{field.Name}'>{field.Value}</textarea>");
                    break;
                case "hidden":
                    stringBuilder.Append($"<input type='hidden' id='{field.Id}' name='{field.Name}' value='{field.Value}' />");
                    break;
                default:
                    break;
            }
            stringBuilder.Append("</div>");
        }

        return stringBuilder.ToString();
    }


}
public class FormField
{
    public string? LangCode { get; set; } = string.Empty;
    public string? Id { get; set; } = string.Empty;
    public string? Name { get; set; } = string.Empty;
    public string? Type { get; set; } = string.Empty;
    public string? Value { get; set; } = string.Empty;
    public string? Label { get; set; } = string.Empty;
    public string? ClassNames { get; set; } = string.Empty;
    public bool Required { get; set; }
}