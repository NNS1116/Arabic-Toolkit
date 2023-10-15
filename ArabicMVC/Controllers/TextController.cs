using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ArabicMVC.Models;


public class TextController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ReverseText(TextModel model)
    {
        if (model.ArabicText == null)
        {
            return RedirectToAction("Index");
        }

        var reversedText = new string(model.ArabicText.Reverse().ToArray());
        ViewData["ReversedText"] = reversedText;
        return View("Index");
    }

    [HttpPost]
    public IActionResult CountWords(TextModel model)
    {
        if (model.ArabicText == null)
        {
            return RedirectToAction("Index");
        }

        var words = model.ArabicText.Split(new char[] { ' ', '\t', '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        ViewData["WordCount"] = words.Length;
        return View("Index");
    }

    [HttpPost]
    public IActionResult CountLetters(TextModel model)
    {
        if (model.ArabicText == null)
        {
            return RedirectToAction("Index");
        }

        var letterCount = model.ArabicText.Count(char.IsLetter);
        ViewData["LetterCount"] = letterCount;
        return View("Index");
    }
}
