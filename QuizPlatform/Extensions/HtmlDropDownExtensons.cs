using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace QuizPlatform.Extensions
{
  public static class HtmlDropDownExtensons
  {
    public static MvcHtmlString EnumDropDownList<TEnum>(this HtmlHelper htmlHelper, string name, TEnum selectedValue)
    {
      IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

      IEnumerable<SelectListItem> items = values.Select(
        x => new SelectListItem
        {
          Selected = x.Equals(selectedValue),
          Text = x.ToString(),
          Value = x.ToString()
        });

      return htmlHelper.DropDownList(name, items);
    }

    public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper,
      Expression<Func<TModel, TEnum>> expression)
    {
      ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
      IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

      IEnumerable<SelectListItem> items = values.Select(
        x => new SelectListItem
        {
          Selected = x.Equals(metadata.Model),
          Text = x.ToString(),
          Value = x.ToString()
        });

      return htmlHelper.DropDownListFor(expression, items);
    }
  }
}