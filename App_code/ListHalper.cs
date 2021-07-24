using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProgrammingArticles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingArticles.App_code
{
    public static class ListHalper
    {
        public static HtmlString CreateArticleList(this IHtmlHelper htmlHelper, IEnumerable<Article> articles)
        {
            string result = "<ul>";
            foreach (var article in articles)
            {
                result += $"<li>{article.Name} {article.Content.Text} Autor: {article?.Creator?.UserName ?? "Unknow"}</li>";
            }
            result += $"</ul>";
            return new HtmlString(result);
        }
    }
}
